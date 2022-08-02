Imports csUnit
Imports EncoreSubtitlesCommon
Imports ImportSubFiles

<TestFixture()> _
Public Class TestLoadSamitype
    Private Shared SamiTestFile As String = "..\Samples\LAST EXILE 01.smi"

    <Test()> _
    Sub TestFirstSubtitles()
        Dim SamiLoader As ISubFile
        Dim SamiSubtitles As ICaptions

        SamiLoader = SubFileLoader.Load(SamiTestFile)
        SamiSubtitles = SamiLoader.GetSubTitles()
        Assert.Equals("LAST EXILE � 1 ��|Caption Present From ����Ŀ��|burkut@hufs.ac.kr, http://burkut.pe.kr", SamiSubtitles.Item(0).CaptionTitle)
        Assert.Equals(1, SamiSubtitles.Item(0).EnterTiming)
        Assert.Equals(8351, SamiSubtitles.Item(0).LeaveTiming)
        SamiLoader.Dispose()
    End Sub

    <Test()> _
    Sub TestSubtitleCaptionCount()
        Dim SamiLoader As ISubFile
        Dim SamiSubtitles As ICaption

        SamiLoader = SubFileLoader.Load(SamiTestFile)
        Assert.Equals(237, SamiLoader.GetSubTitles.Count)
    End Sub

    <Test()> _
    Sub TestLastCaptionTitle()
        Dim SamiLoader As ISubFile
        Dim SamiSubtitles As ICaptions

        SamiLoader = SubFileLoader.Load(SamiTestFile)
        SamiSubtitles = SamiLoader.GetSubTitles()
        Assert.Equals("���� �̾߱�, ��Ʈ ������ �� 2ȭ|Luft Vanship, ����ϼ���!", SamiSubtitles.Item(SamiSubtitles.Count - 1).CaptionTitle)
        Assert.Equals(1452736, SamiSubtitles.Item(SamiSubtitles.Count - 1).EnterTiming)
        Assert.Equals(1458028, SamiSubtitles.Item(SamiSubtitles.Count - 1).LeaveTiming)
        SamiLoader.Dispose()
    End Sub
End Class
