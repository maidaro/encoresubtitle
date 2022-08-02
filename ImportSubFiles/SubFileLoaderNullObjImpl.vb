Imports EncoreSubtitlesCommon

Class SubFileLoaderNullObject
    Implements ISubFile

    Public Sub Load(ByVal Filename As String) Implements ISubFile.Load

    End Sub

    Public Sub Dispose() Implements System.IDisposable.Dispose

    End Sub

    Public Function GetSubTitles() As ICaptions Implements ISubFile.GetSubTitles
        Return New CaptionsImpl
    End Function
End Class
