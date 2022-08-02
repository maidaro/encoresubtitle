Imports System.IO
Imports EncoreSubtitlesCommon

Class MicroDVDLoader
    Implements ISubFile

    Private m_SubTitles As CaptionsImpl
    Private m_TokenReader As MicroDVDTokenReader
    Private m_ParsingResult As SubFileParsingException
    Private m_Framerates As Single

    Private Function ReplaceTag(ByVal Original As String) As String
        Dim RetString As String = ""
        Dim IsInsidetag As Boolean = False
        For i As Integer = 0 To Original.Length - 1
            If Original.Chars(i) = "{" Then
                IsInsidetag = True
            ElseIf Original.Chars(i) = "}" Then
                IsInsidetag = False
            ElseIf IsInsidetag = False Then
                RetString = RetString + Original.Chars(i)
            End If
        Next
        Return RetString
    End Function

    Private Function ExpressText() As String
        Dim CaptionString As String = ""

        m_TokenReader.TextContext = True
        Dim Token As MicroDVDToken = m_TokenReader.GetToken()
        While Token.TokenType <> MicroDVDTokenType.LineBraker
            CaptionString = CaptionString + Token.TokenString
            Token = m_TokenReader.GetToken()
        End While
        m_TokenReader.TextContext = False
        Return ReplaceTag(CaptionString)
    End Function

    Private Function ExpressTiming() As Integer
        If m_TokenReader.GetToken().TokenType <> MicroDVDTokenType.Delimiter Then
            Throw New SubFileParsingException("Missing {")
        End If
        Dim TimingValue As MicroDVDToken = m_TokenReader.GetToken()
        If TimingValue.TokenType <> MicroDVDTokenType.Text Then
            Throw New SubFileParsingException("Missing Timing Value")
        End If
        If m_TokenReader.GetToken().TokenType <> MicroDVDTokenType.Delimiter Then
            Throw New SubFileParsingException("Missing }")
        End If
        Return TimingValue.TokenString
    End Function

    Private Function ExpressCaptionLine() As ICaption
        Dim CaptionItem As New CaptionImpl
        Dim Token As MicroDVDToken = m_TokenReader.GetToken()
        If Token.TokenType = MicroDVDTokenType.EndOfToken Then Return Nothing

        m_TokenReader.UndoToken(Token)
        CaptionItem.EnterTiming = ExpressTiming() * 1000 / m_Framerates
        CaptionItem.LeaveTiming = ExpressTiming() * 1000 / m_Framerates
        CaptionItem.CaptionTitle() = ExpressText()
        Return CaptionItem
    End Function

    Private Function ExpressFramerates() As Single
        ExpressTiming()
        ExpressTiming()
        Return ExpressText()
    End Function

    Public Function GetSubTitles() As ICaptions Implements ISubFile.GetSubTitles
        If m_SubTitles Is Nothing Then Throw m_ParsingResult
        Return m_SubTitles
    End Function

    Public Sub Load(ByVal Filename As String) Implements ISubFile.Load
        m_TokenReader = New MicroDVDTokenReader(New FileStream(Filename, FileMode.Open))
        Dim Captions As New CaptionsImpl
        Try
            m_Framerates = ExpressFramerates()
            Dim CaptionItem As ICaption = ExpressCaptionLine()
            While Not (CaptionItem Is Nothing)
                Captions.Append(CaptionItem)
                CaptionItem = ExpressCaptionLine()
            End While
        Catch e As SubFileParsingException
            m_ParsingResult = e
            m_SubTitles = Nothing
            Exit Sub
        Finally
            m_TokenReader.Close()
        End Try
        m_SubTitles = Captions
    End Sub

    Public Sub Dispose() Implements System.IDisposable.Dispose
    End Sub
End Class
