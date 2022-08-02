Imports csUnit
Imports EncoreSubtitlesCommon

<TestFixture()> _
Public Class TestCaptionListUI
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
        ProjectUI.CaptionList.Items.Clear()
        Assert.Equals(0, Project.Count)
        Assert.Equals(0, ProjectUI.WorkList.Items.Count)
    End Sub

    <Test()> _
    Sub TestUpdateCaptionListState()
        Assert.Equals(0, ProjectUI.CaptionList.Items.Count)
        ProjectUI.WorkList.Items(0).Selected = True ' This method only operates well when UI is displayed.
        ProjectUI.UpdateSubtitleDetails()
        Assert.Equals(237, ProjectUI.CaptionList.Items.Count)
        Assert.Equals("LAST EXILE 第 1 話|Caption Present From 베르커드|burkut@hufs.ac.kr, http://burkut.pe.kr", ProjectUI.CaptionList.Items(0).SubItems(3).Text)
        Assert.Equals("다음 이야기, 라스트 엑자일 제 2화|Luft Vanship, 기대하세요!", ProjectUI.CaptionList.Items(236).SubItems(3).Text)
    End Sub
End Class
