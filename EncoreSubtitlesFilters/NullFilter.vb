Public Class NullFilter
    Implements IFilter

    Public Function ApplyFilter(ByVal Input As EncoreSubtitlesCommon.ICaptions, ByVal Properties As System.Collections.Specialized.StringDictionary) As EncoreSubtitlesCommon.ICaptions Implements IFilter.ApplyFilter
        Return Input
    End Function
End Class
