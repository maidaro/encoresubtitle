Imports csUnit
Imports ImportSubFiles

<TestFixture()> _
Public Class TestOpenSamiFiles
    Private Shared SamiTestFile As String = "..\..\Samples\LAST EXILE 01.smi"

    <Test(), ExpectedException(GetType(System.IO.FileNotFoundException))> _
    Sub OpenInvalidSamiFile()
        Dim SamiLoader As ISubFile

        SamiLoader = SubFileLoader.Load("*.smi")
        SamiLoader.Dispose()
    End Sub

    <Test()> _
    Sub OpenLastExileVol1()
        Dim SamiLoader As ISubFile

        SamiLoader = SubFileLoader.Load(SamiTestFile)
        SamiLoader.Dispose()
    End Sub

    <Test()> _
    Sub OpenNoneSamiFile()
        Dim SubLoader As ISubFile

        SubLoader = SubFileLoader.Load("E:\예산(환율).txt")
        SubLoader.GetSubTitles()
        SubLoader.Dispose()
    End Sub
End Class
