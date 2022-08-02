Imports ImportSubFiles
Imports EncoreSubtitlesCommon
Imports System.io

Public Class SubFileLoader
    Public Shared Function Load(ByVal Filename As String) As ISubFile
        If File.Exists(Filename) = False Then Throw New FileNotFoundException("File not found", Filename)

        Dim retObj As ISubFile
        Dim FileType As String = FSUtils.ExtractFileTypes(Filename)

        FileType = FileType.ToUpper()
        Select Case FileType
            Case "SMI"
                retObj = New SamiLoader
            Case "SAMI"
                retObj = New SamiLoader
            Case "SUB"
                retObj = New MicroDVDLoader
            Case Else
                retObj = New SubFileLoaderNullObject
        End Select
        retObj.Load(Filename)
        Return retObj
    End Function

    Public Shared Function GetSupportedFileFilters() As String
        Return "Microsoft SAMI files(*.smi;*.sami)|*.smi;*.sami|Micro DVD files(*.sub)|*.sub"
    End Function
End Class
