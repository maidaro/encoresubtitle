Imports System.Collections.Specialized
Imports EncoreSubtitlesCommon

Public Interface ISubFileExporter
    Inherits IDisposable

    Function ExportCaptions(ByVal CaptionTitles As ICaptions, ByVal FileFullpath As String, ByVal Properties As StringDictionary) As Boolean
    ReadOnly Property FileExtension() As String
    ReadOnly Property FileDescription() As String
End Interface
