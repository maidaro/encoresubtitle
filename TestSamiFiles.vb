Imports csUnit
Imports EncoreSubtitlesCommon

<TestFixture()> _
Public Class TestLoadSamiFiles
    Private Shared TestFile0 As String = "..\Samples\LAST EXILE 01.smi"
    Private Shared TestFile1 As String = "..\Samples\『 やまとなでしこ 』Vol.01.smi"
    Private Shared TestFile2 As String = "..\Samples\춤추는 대수사선 (踊る大搜査線) 第01話.smi"
    Private Shared TestFile3 As String = "..\Samples\FMPH01.smi"
    Private Shared TestFile4 As String = "..\Samples\sutepri24.smi"

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

    Sub LoadSamiFile(ByVal Filename As String)
        Dim OpenFileDialog1 = New OpenFileDialog

        OpenFileDialog1.FileName = Filename
        ProjectUI.AppendWorkItem(OpenFileDialog1)
        ProjectUI.WorkList.Items(0).Selected = True ' This method only operates well when UI is displayed.
        ProjectUI.UpdateSubtitleDetails()
    End Sub

    <TearDown()> _
    Sub ClearWorklist()
        Project.Clear()
        ProjectUI.CaptionList.Items.Clear()
        Assert.Equals(0, Project.Count)
        Assert.Equals(0, ProjectUI.WorkList.Items.Count)
    End Sub

    <Test()> _
    Sub TestLASTEXILE()
        LoadSamiFile(TestFile0)
        Assert.Equals(237, ProjectUI.CaptionList.Items.Count)
        Assert.Equals("1", ProjectUI.CaptionList.Items(0).SubItems(1).Text)
        Assert.Equals("8351", ProjectUI.CaptionList.Items(0).SubItems(2).Text)
        Assert.Equals("LAST EXILE 第 1 話|Caption Present From 베르커드|burkut@hufs.ac.kr, http://burkut.pe.kr", ProjectUI.CaptionList.Items(0).SubItems(3).Text)
        Assert.Equals("644428", ProjectUI.CaptionList.Items(102).SubItems(1).Text)
        Assert.Equals("645891", ProjectUI.CaptionList.Items(102).SubItems(2).Text)
        Assert.Equals("나 수통 들고 올께!", ProjectUI.CaptionList.Items(102).SubItems(3).Text)
        Assert.Equals("1452736", ProjectUI.CaptionList.Items(236).SubItems(1).Text)
        Assert.Equals("1458028", ProjectUI.CaptionList.Items(236).SubItems(2).Text)
        Assert.Equals("다음 이야기, 라스트 엑자일 제 2화|Luft Vanship, 기대하세요!", ProjectUI.CaptionList.Items(236).SubItems(3).Text)
    End Sub

    <Test()> _
    Sub TestYAMATONADESICO()
        LoadSamiFile(TestFile1)
        Assert.Equals(615, ProjectUI.CaptionList.Items.Count)
        Assert.Equals("2828", ProjectUI.CaptionList.Items(0).SubItems(1).Text)
        Assert.Equals("12895", ProjectUI.CaptionList.Items(0).SubItems(2).Text)
        Assert.Equals("야마토 나데시코(일본 여성을 아름답게 칭함)|번역자막:하나넷 드라마/영화동pacey77&edwiz@hanmail.net", ProjectUI.CaptionList.Items(0).SubItems(3).Text)
        Assert.Equals("1446613", ProjectUI.CaptionList.Items(327).SubItems(1).Text)
        Assert.Equals("1449613", ProjectUI.CaptionList.Items(327).SubItems(2).Text)
        Assert.Equals("샴페인으로 손을 씻으면 보들보들해진다고 선배에게 배웠서요", ProjectUI.CaptionList.Items(327).SubItems(3).Text)
        Assert.Equals("2739152", ProjectUI.CaptionList.Items(614).SubItems(1).Text)
        Assert.Equals("2741152", ProjectUI.CaptionList.Items(614).SubItems(2).Text)
        Assert.Equals("최종자막수정 : Korea.com 일본드라마동호회 |juni@korea.com", ProjectUI.CaptionList.Items(614).SubItems(3).Text)
    End Sub

    <Test()> _
    Sub TestOTORUDAISYUSASEN()
        LoadSamiFile(TestFile2)
        Assert.Equals(962, ProjectUI.CaptionList.Items.Count)
        Assert.Equals("16910", ProjectUI.CaptionList.Items(0).SubItems(1).Text)
        Assert.Equals("19748", ProjectUI.CaptionList.Items(0).SubItems(2).Text)
        Assert.Equals("자백해", ProjectUI.CaptionList.Items(0).SubItems(3).Text)
        Assert.Equals("1649710", ProjectUI.CaptionList.Items(429).SubItems(1).Text)
        Assert.Equals("1658272", ProjectUI.CaptionList.Items(429).SubItems(2).Text)
        Assert.Equals("이미 통보를 했듯이, |오늘 아침 유명흥산 빌딩의 임원실에서 ", ProjectUI.CaptionList.Items(429).SubItems(3).Text)
        Assert.Equals("4159829", ProjectUI.CaptionList.Items(961).SubItems(1).Text)
        Assert.Equals("4162112", ProjectUI.CaptionList.Items(961).SubItems(2).Text)
        Assert.Equals("나는 일어난다!!", ProjectUI.CaptionList.Items(961).SubItems(3).Text)
    End Sub

    <Test()> _
    Sub TestFULLMETALPANICHUMOTU()
        LoadSamiFile(TestFile3)
        Assert.Equals(468, ProjectUI.CaptionList.Items.Count)
        Assert.Equals("2120", ProjectUI.CaptionList.Items(0).SubItems(1).Text)
        Assert.Equals("3163", ProjectUI.CaptionList.Items(0).SubItems(2).Text)
        Assert.Equals("교장선생님!", ProjectUI.CaptionList.Items(0).SubItems(3).Text)
        Assert.Equals("644768", ProjectUI.CaptionList.Items(241).SubItems(1).Text)
        Assert.Equals("645729", ProjectUI.CaptionList.Items(241).SubItems(2).Text)
        Assert.Equals("치도리, 뭐 하나?", ProjectUI.CaptionList.Items(241).SubItems(3).Text)
        Assert.Equals("1391481", ProjectUI.CaptionList.Items(467).SubItems(1).Text)
        Assert.Equals("1394848", ProjectUI.CaptionList.Items(467).SubItems(2).Text)
        Assert.Equals("저 멀리 울려퍼지네", ProjectUI.CaptionList.Items(467).SubItems(3).Text)
    End Sub

    <Test()> _
    Sub TestSTERPRI()
        LoadSamiFile(TestFile4)
        Assert.Equals(278, ProjectUI.CaptionList.Items.Count)
        Assert.Equals("850", ProjectUI.CaptionList.Items(0).SubItems(1).Text)
        Assert.Equals("7221", ProjectUI.CaptionList.Items(0).SubItems(2).Text)
        Assert.Equals("스크랩드 프린세스|[SCRAPPED PRINCESS]", ProjectUI.CaptionList.Items(0).SubItems(3).Text)
        Assert.Equals("636018", ProjectUI.CaptionList.Items(130).SubItems(1).Text)
        Assert.Equals("640192", ProjectUI.CaptionList.Items(130).SubItems(2).Text)
        Assert.Equals("인류쪽의 정보를 제공해주기 바란다고..", ProjectUI.CaptionList.Items(130).SubItems(3).Text)
        Assert.Equals("1365471", ProjectUI.CaptionList.Items(277).SubItems(1).Text)
        Assert.Equals("1373311", ProjectUI.CaptionList.Items(277).SubItems(2).Text)
        Assert.Equals("君は彼方へ そして未來へ |그대는 저편으로 그리고 저 미래로 ", ProjectUI.CaptionList.Items(277).SubItems(3).Text)
    End Sub
End Class
