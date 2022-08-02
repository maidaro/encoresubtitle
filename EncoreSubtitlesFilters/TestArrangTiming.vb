Imports csUnit
Imports EncoreSubtitlesCommon
Imports ImportSubFiles

<TestFixture()> _
Public Class TestArrangeTiming
    Private Shared TestFile As String = "..\..\Samples\�� ��ުȪʪǪ��� ��Vol.01.smi"


    <Test()> _
    Sub TestArrangeTiming()
        Dim SamiLoader As isubfile
        Dim SamiSubtitles As ICaptions

        SamiLoader = SubFileLoader.Load(TestFile)
        SamiSubtitles = SamiLoader.GetSubTitles
        Assert.Equals(615, SamiSubtitles.Count)
        Assert.Equals(2828, SamiSubtitles.Item(0).EnterTiming)
        Assert.Equals(12895, SamiSubtitles.Item(0).LeaveTiming)
        Assert.Equals("�߸��� ��������(�Ϻ� ������ �Ƹ���� Ī��)|�����ڸ�:�ϳ��� ���/��ȭ��pacey77&edwiz@hanmail.net", SamiSubtitles.Item(0).CaptionTitle)
        Assert.Equals(1446613, SamiSubtitles.Item(327).EnterTiming)
        Assert.Equals(1449613, SamiSubtitles.Item(327).LeaveTiming)
        Assert.Equals("���������� ���� ������ ���麸�������ٰ� ���迡�� �������", SamiSubtitles.Item(327).CaptionTitle)
        Assert.Equals(2739152, SamiSubtitles.Item(614).EnterTiming)
        Assert.Equals(2741152, SamiSubtitles.Item(614).LeaveTiming)
        Assert.Equals("�����ڸ����� : Korea.com �Ϻ���󸶵�ȣȸ |juni@korea.com", SamiSubtitles.Item(614).CaptionTitle)

        Assert.Equals(255267, SamiSubtitles.Item(21).EnterTiming)
        Assert.Equals(256712, SamiSubtitles.Item(21).LeaveTiming)
        Assert.Equals("���� �ֽ��ϴ�", SamiSubtitles.Item(21).CaptionTitle)

        Dim TimingArrange As New TimingArrangeOP
        Dim ArrangedSubtitles As ICaptions = TimingArrange.ApplyFilter(SamiSubtitles, Nothing)
        Assert.Equals(249938, ArrangedSubtitles.Item(20).EnterTiming)
        Assert.Equals(255267, ArrangedSubtitles.Item(20).LeaveTiming)
        Assert.Equals("� ���ڰ� ��¥ �������� �ִܽð��ȿ� ��Ȯ�ϰ� �˾�ç �� ����|", ArrangedSubtitles.Item(20).CaptionTitle)
    End Sub
End Class
