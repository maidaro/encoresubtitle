Public Module FSUtils
    Public Function ExtractFileTypes(ByVal FullPath As String) As String
        Dim iExtTypeIndex As Integer = FullPath.LastIndexOf(".") + 1
        Dim iExtLength As Integer = FullPath.Length - iExtTypeIndex
        Return FullPath.Substring(iExtTypeIndex, iExtLength)
    End Function

    Public Function ExtractPath(ByVal FullPath As String) As String
        Dim iIndexOfStartFileName As Integer = FullPath.LastIndexOf("\") + 1
        Return FullPath.Substring(0, iIndexOfStartFileName)
    End Function

    Public Function ExtractFilename(ByVal FullPath As String) As String
        Dim iIndexOfStartFileName As Integer = FullPath.LastIndexOf("\") + 1
        Dim iFilenameLegnth As Integer = FullPath.Length - iIndexOfStartFileName
        Return FullPath.Substring(iIndexOfStartFileName, iFilenameLegnth)
    End Function

    Public Function EliminateFileTypes(ByVal FullPath As String) As String
        Dim iExtTypeIndex As Integer = FullPath.LastIndexOf(".")
        Return FullPath.Substring(0, iExtTypeIndex)
    End Function
End Module
