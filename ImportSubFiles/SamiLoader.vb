Imports System.IO
Imports EncoreSubtitlesCommon

Class SamiLoader
    Implements ISubFile

    Private m_SubTitles As CaptionsImpl
    Private m_ParsingResult As String

    Public Sub Load(ByVal Filename As String) Implements ISubFile.Load
        Dim SamiParser As New SamiTokenParser(Filename)
        If SamiParser.ExpressRootNode() = True Then
            ImportSamiFiles(SamiParser.RootNode)
            m_ParsingResult = "Parsing OK"
        Else
            m_SubTitles = Nothing
            If SamiParser.State.ParsingState = ParsingState.EndOfToken Then
                m_ParsingResult = Filename & " has corrupted structure"
            Else
                m_ParsingResult = SamiParser.State.ParsingErrorMsg
            End If
        End If
        SamiParser.Close()
    End Sub

    Public Sub ImportSamiFiles(ByVal RootNode As ISamiElement)
        Dim SyncNode As ISamiElement
        Dim Caption As CaptionImpl = Nothing

        m_SubTitles = New CaptionsImpl
        For i As Integer = 0 To RootNode.ChildNodes.Item(1).ChildNodes.Count - 1
            SyncNode = RootNode.ChildNodes.Item(1).ChildNodes.Item(i)
            Caption = ReadSyncNode(Caption, SyncNode)
            If Not Caption Is Nothing Then m_SubTitles.Append(Caption)
        Next
    End Sub

    Private Function ReadSyncCaptionTitles(ByVal SyncNode As ISamiElement) As String
        Dim CaptionTitle As String = ""

        For i As Integer = 0 To SyncNode.ChildNodes.Count - 1
            Dim ExpectedText As ISamiElement = SyncNode.ChildNodes.Item(i)
            If String.Compare(ExpectedText.Name, "BR", True) = 0 Then
                CaptionTitle = CaptionTitle + "|"
            Else
                CaptionTitle = CaptionTitle + ExpectedText.Value
            End If
        Next
        Return CaptionTitle
    End Function

    Private Function ReadSyncTiming(ByVal SyncNode As ISamiElement) As Integer
        Dim CaptionTiming As String = SyncNode.Attributes.Item(0).Value()
        If CaptionTiming.EndsWith("ms") = True Then
            CaptionTiming = CaptionTiming.Substring(0, CaptionTiming.Length - 2)
        End If
        Return Convert.ToInt32(CaptionTiming)
    End Function

    Public Function ReadSyncNode(ByVal PreviousSync As CaptionImpl, ByVal SyncNode As ISamiElement) As ICaption
        Dim CaptionTiming As Integer = ReadSyncTiming(SyncNode)
        Dim CaptionTitle As String = ReadSyncCaptionTitles(SyncNode)

        If Not (PreviousSync Is Nothing) Then
            PreviousSync.LeaveTiming = CaptionTiming
        End If
        CaptionTitle = CaptionTitle.Replace("&nbsp;", " ")
        If CaptionTitle.Trim().Length = 0 Then
            Return Nothing
        Else
            Dim RetObj As CaptionImpl = New CaptionImpl

            RetObj.CaptionTitle = CaptionTitle
            RetObj.EnterTiming = CaptionTiming
            RetObj.LeaveTiming = CaptionTiming + 2000
            Return RetObj
        End If
    End Function

    Public Sub Dispose() Implements System.IDisposable.Dispose

    End Sub

    Public Function GetSubTitles() As ICaptions Implements ISubFile.GetSubTitles
        If m_SubTitles Is Nothing Then
            Throw New SubFileParsingException(m_ParsingResult)
        End If
        Return m_SubTitles
    End Function
End Class
