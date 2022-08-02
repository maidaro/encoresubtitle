Imports EncoreSubtitlesCommon

Public Interface ISubFile
    Inherits IDisposable

    Sub Load(ByVal Filename As String)
    Function GetSubTitles() As ICaptions
End Interface
