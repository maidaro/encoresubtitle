Imports EncoreSubtitlesCommon

Public Class TimingArrangeOP
    Implements IFilter

    Private m_Output As ICaptions

    Private Function ArrangeTiming(ByVal Input As ICaptions) As ICaptions
        If Input Is Nothing Then Return Nothing
        If Input.Count <= 0 Then Return Input.Clone
        m_Output = Input.Clone
        FirstPassing()
        SecondPassing()
        Return m_Output
    End Function

    Private Sub FirstPassing()
        For i As Integer = 0 To m_Output.Count - 1
            If m_Output.Item(i).EnterTiming > m_Output.Item(i).LeaveTiming Then
                m_Output.Item(i).LeaveTiming = m_Output.Item(i).EnterTiming + 2000
                If i < m_Output.Count - 1 And m_Output.Item(i + 1).EnterTiming < m_Output.Item(i).LeaveTiming Then
                    m_Output.Item(i + 1).EnterTiming = m_Output.Item(i).LeaveTiming
                End If
            End If
        Next
    End Sub

    Private Sub SecondPassing()
        For i As Integer = 0 To m_Output.Count - 2
            If m_Output.Item(i).LeaveTiming > m_Output.Item(i + 1).EnterTiming Then
                Dim j As Integer = i + 1
                While m_Output.Item(i).LeaveTiming > m_Output.Item(j).EnterTiming
                    AppendCaptionTitleSpace(m_Output.Item(i), m_Output.Item(j))
                    j = j + 1
                End While
                m_Output.Item(i).LeaveTiming = m_Output.Item(i + 1).EnterTiming
            End If
        Next
    End Sub

    Private Sub AppendCaptionTitleSpace(ByVal Caption As ICaption, ByVal OverlappedCaption As ICaption)
        Caption.CaptionTitle = Caption.CaptionTitle + FormattingCaptionTitlesSpace(OverlappedCaption.CaptionTitle)
    End Sub

    Private Function FormattingCaptionTitlesSpace(ByVal CaptionTitle As String) As String
        Dim SpaceString As String = ""

        For i As Integer = 0 To CaptionTitle.Length - 1
            If CaptionTitle.Chars(i) = "|" Then SpaceString = SpaceString + "|"
        Next
        Return SpaceString + "|"
    End Function

    Public Function ApplyFilter(ByVal Input As EncoreSubtitlesCommon.ICaptions, ByVal Properties As System.Collections.Specialized.StringDictionary) As EncoreSubtitlesCommon.ICaptions Implements IFilter.ApplyFilter
        Return ArrangeTiming(Input)
    End Function
End Class
