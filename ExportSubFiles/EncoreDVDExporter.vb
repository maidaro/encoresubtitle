Imports EncoreSubtitlesCommon
Imports System.Collections.Specialized
Imports EncoreSubtitlesFilters

Public Class EncoreDVDExporter
    Implements ISubFileExporter

    Private m_OutputStream As System.IO.Stream
    Private m_UTF8Writer As System.IO.StreamWriter
    Private m_Properties As EncoreDVDProperties

    Public ReadOnly Property FileDescription() As String Implements ISubFileExporter.FileDescription
        Get
            Return "Adobe Encore DVD caption files(*.txt)"
        End Get
    End Property

    Public ReadOnly Property FileExtension() As String Implements ISubFileExporter.FileExtension
        Get
            Return "*.txt"
        End Get
    End Property

    Public Sub Dispose() Implements System.IDisposable.Dispose

    End Sub

    Public Function ExportCaptions(ByVal CaptionTitles As ICaptions, ByVal FileFullpath As String, ByVal Properties As StringDictionary) As Boolean Implements ISubFileExporter.ExportCaptions
        m_OutputStream = New System.IO.FileStream(FileFullpath, IO.FileMode.Create)
        If m_OutputStream Is Nothing Then Return False
        m_UTF8Writer = New System.IO.StreamWriter(m_OutputStream, System.Text.Encoding.UTF8)
        m_Properties = New EncoreDVDProperties
        m_Properties.BindProperties(Properties)

        Dim FilterOut As ICaptions
        If m_Properties.ArrangeTiming = True Then
            Dim Filter As New TimingArrangeOP
            FilterOut = Filter.ApplyFilter(CaptionTitles, Nothing)
        Else
            FilterOut = CaptionTitles
        End If
        If m_Properties.WordWrap = True Then
            Dim Filter As New AutoWordWrap
            FilterOut = Filter.ApplyFilter(FilterOut, Properties)
        Else
            FilterOut = FilterOut
        End If
        For i As Integer = 0 To FilterOut.Count - 1
            WriteCaptionCounter(i)
            WriteCaptionTiming(FilterOut.Item(i))
            WriteCaptionTitle(FilterOut.Item(i))
        Next
        m_UTF8Writer.Close()
        m_OutputStream.Close()
    End Function

    Private Sub WriteCaptionCounter(ByVal Counter As Integer)
        m_UTF8Writer.Write(FormattingCounter(Counter))
    End Sub

    Private Function FormattingCounter(ByVal Counter As Integer) As String
        Return String.Format("{0:d} ", Counter)
    End Function

    Private Sub WriteCaptionTiming(ByVal Caption As ICaption)
        m_UTF8Writer.Write(FormattingTiming(Caption.EnterTiming))
        m_UTF8Writer.Write(FormattingTiming(Caption.LeaveTiming))
    End Sub

    Private Function FormattingTiming(ByVal Timing As Integer) As String
        Dim MSeconds As Integer = Timing Mod 1000
        Timing = (Timing - MSeconds) / 1000
        Dim Seconds As Integer = Timing Mod 60
        Timing = (Timing - Seconds) / 60
        Dim Minutes As Integer = Timing Mod 60
        Timing = (Timing - Minutes) / 60
        Dim Hours As Integer = Timing
        Dim Frames As Integer = (MSeconds * m_Properties.FrameRates) / 1000
        Return String.Format("{0,2:d2};{1,2:d2};{2,2:d2};{3,2:d2} ", Hours, Minutes, Seconds, Frames)
    End Function

    Private Sub WriteCaptionTitle(ByVal Caption As ICaption)
        Dim CaptionTitle As String = Caption.CaptionTitle.Replace("|", vbCrLf)
        m_UTF8Writer.WriteLine(CaptionTitle)
    End Sub
End Class
