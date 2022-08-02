Imports csUnit
Imports EncoreSubtitlesCommon
Imports ImportSubFiles

<TestFixture()> _
Public Class TestArrangeTiming
    Private Shared TestFile As String = "..\..\Samples\『 やまとなでしこ 』Vol.01.smi"


    <Test()> _
    Sub TestArrangeTiming()
        Dim SamiLoader As isubfile
        Dim SamiSubtitles As ICaptions

        SamiLoader = SubFileLoader.Load(TestFile)
        SamiSubtitles = SamiLoader.GetSubTitles
        Assert.Equals(615, SamiSubtitles.Count)
        Assert.Equals(2828, SamiSubtitles.Item(0).EnterTiming)
        Assert.Equals(12895, SamiSubtitles.Item(0).LeaveTiming)
        Assert.Equals("야마토 나데시코(일본 여성을 아름답게 칭함)|번역자막:하나넷 드라마/영화동pacey77&edwiz@hanmail.net", SamiSubtitles.Item(0).CaptionTitle)
        Assert.Equals(1446613, SamiSubtitles.Item(327).EnterTiming)
        Assert.Equals(1449613, SamiSubtitles.Item(327).LeaveTiming)
        Assert.Equals("샴페인으로 손을 씻으면 보들보들해진다고 선배에게 배웠서요", SamiSubtitles.Item(327).CaptionTitle)
        Assert.Equals(2739152, SamiSubtitles.Item(614).EnterTiming)
        Assert.Equals(2741152, SamiSubtitles.Item(614).LeaveTiming)
        Assert.Equals("최종자막수정 : Korea.com 일본드라마동호회 |juni@korea.com", SamiSubtitles.Item(614).CaptionTitle)

        Assert.Equals(255267, SamiSubtitles.Item(21).EnterTiming)
        Assert.Equals(256712, SamiSubtitles.Item(21).LeaveTiming)
        Assert.Equals("여기 있습니다", SamiSubtitles.Item(21).CaptionTitle)

        Dim TimingArrange As New TimingArrangeOP
        Dim ArrangedSubtitles As ICaptions = TimingArrange.ApplyFilter(SamiSubtitles, Nothing)
        Assert.Equals(249938, ArrangedSubtitles.Item(20).EnterTiming)
        Assert.Equals(255267, ArrangedSubtitles.Item(20).LeaveTiming)
        Assert.Equals("어떤 남자가 진짜 부자인지 최단시간안에 정확하게 알아챌 수 있지|", ArrangedSubtitles.Item(20).CaptionTitle)
    End Sub
End Class
