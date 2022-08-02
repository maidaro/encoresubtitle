Imports csUnit
Imports EncoreSubtitlesCommon

<TestFixture()> _
Public Class TestWorklist
    Private Shared SamiTestFile As String = "..\Samples\LAST EXILE 01.smi"

    <Test()> _
    Sub TestAppendConversionWork()
        Dim WorkItem As New ESTWorkItem
        Dim WorkList As New ESTWorkList

        WorkItem.SourceFullPath = SamiTestFile
        WorkList.Append(WorkItem)
        Assert.Equals(1, WorkList.Count)
        Assert.Equals(SamiTestFile, WorkList.Item(0).SourceFullPath)
    End Sub

    <Test()> _
    Sub TestExtractPathFromFullPath()
        Assert.Equals("..\Samples\", FSUtils.ExtractPath(SamiTestFile))
    End Sub

    <Test()> _
    Sub TestDeleteConversionWork()
        Dim WorkItem As New ESTWorkItem
        Dim WorkList As New ESTWorkList

        WorkItem.SourceFullPath = SamiTestFile
        WorkList.Append(WorkItem)
        WorkList.Delete(SamiTestFile)
        Assert.Equals(0, WorkList.Count)
    End Sub
End Class
