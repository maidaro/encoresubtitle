Imports EncoreSubtitlesCommon
Imports System.Collections.Specialized

Public Interface IFilter
    Function ApplyFilter(ByVal Input As ICaptions, ByVal Properties As StringDictionary) As ICaptions
End Interface
