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
        Assert.Equals("LAST EXILE 第 1 話|Caption Present From 베르커드|burkut@hufs.ac.kr, http://burkut.pe.kr", SamiSubtitles.Item(0).CaptionTitle)
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
        Assert.Equals("다음 이야기, 라스트 엑자일 제 2화|Luft Vanship, 기대하세요!", SamiSubtitles.Item(SamiSubtitles.Count - 1).CaptionTitle)
        Assert.Equals(1452736, SamiSubtitles.Item(SamiSubtitles.Count - 1).EnterTiming)
        Assert.Equals(1458028, SamiSubtitles.Item(SamiSubtitles.Count - 1).LeaveTiming)
        SamiLoader.Dispose()
    End Sub
End Class
