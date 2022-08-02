Imports csUnit
Imports EncoreSubtitlesCommon

<TestFixture()> _
Public Class TestESTProjectUI
    Private Shared SamiTestFile As String = "..\Samples\LAST EXILE 01.smi"
    Private Shared SamiTestFile2 As String = "..\Samples\LAST EXILE 02.smi"

    Private Project As ESTProject
    Private ProjectUI As Mainfrm

    <FixtureSetUp()> _
    Sub CreateObject()
        Project = New ESTProject
        ProjectUI = New Mainfrm(Project)
        ProjectUI.Show() ' For testing even Form will operate as Modal, It must be open as Modaless Dialog
    End Sub

    <FixtureTearDown()> _
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        ProjectUI.Dispose()
    End Sub

    <SetUp()> _
    Sub AppendSamiTestFile()
        Dim OpenFileDialog1 = New OpenFileDialog

        OpenFileDialog1.FileName = SamiTestFile
        ProjectUI.AppendWorkItem(OpenFileDialog1)
    End Sub

    <TearDown()> _
    Sub ClearWorklist()
        Project.Clear()
        Assert.Equals(0, Project.Count)
        Assert.Equals(0, ProjectUI.WorkList.Items.Count)
    End Sub

    <Test()> _
    Sub TestAppendNewWorkItem()
        Assert.Equals(1, ProjectUI.WorkList.Items.Count)
        Assert.Equals(ExtractFilename(SamiTestFile), ProjectUI.WorkList.Items(0).SubItems(0).Text)
        Assert.Equals(1, Project.Count)
    End Sub

    <Test()> _
    Sub TestDeleteWorkItem()
        ProjectUI.WorkList.Items(0).Selected = True ' This method only operates well when UI is displayed.
        Assert.True(ProjectUI.mnuRemoveSubtitle.Enabled)
        ProjectUI.RemoveSelectedWorkItem()
        Assert.False(ProjectUI.mnuRemoveSubtitle.Enabled)
        Assert.Equals(0, ProjectUI.WorkList.Items.Count)
        Assert.Equals(0, Project.Count)
    End Sub

    <Test()> _
    Sub TestWorklistSequenceSynchronize()
        Dim OpenFileDialog1 = New OpenFileDialog

        OpenFileDialog1.FileName = SamiTestFile2
        ProjectUI.AppendWorkItem(OpenFileDialog1)
        Assert.Equals(2, ProjectUI.WorkList.Items.Count)
        Assert.Equals(ExtractFilename(SamiTestFile), ProjectUI.WorkList.Items(0).Text)
        Assert.Equals(ExtractFilename(SamiTestFile2), ProjectUI.WorkList.Items(1).Text)
        ProjectUI.WorkList.Items(0).Selected = True ' This method only operates well when UI is displayed.
        ProjectUI.RemoveSelectedWorkItem()
        Assert.Equals(ExtractFilename(SamiTestFile2), ProjectUI.WorkList.Items(0).Text)
    End Sub
End Class
