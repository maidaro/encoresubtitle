Imports EncoreSubtitlesCommon

Public Class AutoWordWrap
    Implements IFilter

    Private m_Output As ICaptions
    Private m_MaxLineLength As Integer
    Private m_EnableDelLineBreaker As Boolean

    Private Function DoWordWrap(ByVal Input As ICaptions) As ICaptions
        If Input Is Nothing Then Return Nothing
        If Input.Count <= 0 Then Return Input.Clone
        m_Output = Input.Clone
        For Each Caption As ICaption In m_Output
            If m_EnableDelLineBreaker = True Then
                Caption.CaptionTitle = DelLineBreaker(Caption.CaptionTitle)
            End If
            Caption.CaptionTitle = SplitCaptionTitle(Caption.CaptionTitle)
        Next
        Return m_Output
    End Function

    Private Sub ExtractMaxLineLengthProperty(ByVal Properties As System.Collections.Specialized.StringDictionary)
        If Properties Is Nothing Then
            m_MaxLineLength = PropertyDefaults.DEFAULTMAXLINELENGTH
        Else
            If Properties.ContainsKey(PropertyKeys.WORDWRAP_MAXLINELENGTH) = True Then
                m_MaxLineLength = Properties(PropertyKeys.WORDWRAP_MAXLINELENGTH)
            Else
                m_MaxLineLength = PropertyDefaults.DEFAULTMAXLINELENGTH
            End If
            If Properties.ContainsKey(PropertyKeys.WORDWRAP_DELLINEBREAKER) = True Then
                m_EnableDelLineBreaker = Properties(PropertyKeys.WORDWRAP_DELLINEBREAKER)
            Else
                m_EnableDelLineBreaker = False
            End If
        End If
    End Sub

    Private Function DelLineBreaker(ByVal CaptionTitle As String) As String
        Return CaptionTitle.Replace("|", " ")
    End Function

    Private Function SplitCaptionTitle(ByVal CaptionTitle As String) As String
        Dim CharNum As Integer = 0
        Dim NearestSeparator As Integer = -1
        Dim NewCaptionTitle As String = CaptionTitle
        Dim uni As New System.Text.UnicodeEncoding
        Dim CurCh As Char

        For i As Integer = 0 To NewCaptionTitle.Length - 1
            CurCh = NewCaptionTitle.Chars(i)
            If CurCh = "|" Then
                CharNum = 0
                NearestSeparator = -1
            Else
                If (Char.IsPunctuation(CurCh) Or Char.IsWhiteSpace(CurCh)) And CurCh <> "@"c Then
                    NearestSeparator = i
                End If
                CharNum = CharNum + 1
                If CharNum >= m_MaxLineLength Then
                    If NearestSeparator < 0 Then
                        AppendLineBreak(NewCaptionTitle, i + 1)
                    Else
                        If Char.IsWhiteSpace(NewCaptionTitle.Chars(NearestSeparator)) = True Then
                            NewCaptionTitle = NewCaptionTitle.Remove(NearestSeparator, 1)
                        End If
                        AppendLineBreak(NewCaptionTitle, NearestSeparator)
                        i = NearestSeparator - 1
                        If i >= NewCaptionTitle.Length - 1 Then
                            Return NewCaptionTitle
                        End If
                    End If
                End If
            End If
        Next
        Return NewCaptionTitle
    End Function

    Private Sub AppendLineBreak(ByRef CaptionTitle As String, ByVal Pos As Integer)
        If Pos >= CaptionTitle.Length Then Return
        CaptionTitle = CaptionTitle.Insert(Pos, "|")
    End Sub

    Public Function ApplyFilter(ByVal Input As EncoreSubtitlesCommon.ICaptions, ByVal Properties As System.Collections.Specialized.StringDictionary) As EncoreSubtitlesCommon.ICaptions Implements IFilter.ApplyFilter
        ExtractMaxLineLengthProperty(Properties)
        Return DoWordWrap(Input)
    End Function
End Class
