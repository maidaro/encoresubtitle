Imports csUnit
Imports EncoreSubtitlesCommon

<TestFixture()> _
Public Class TestMicroDVDLoader
    Private Shared TestFile As String = "..\..\Samples\�� ��ުȪʪǪ��� ��Vol.01.sub"
    Private m_MicroDVDLoader As MicroDVDLoader

    <SetUp()> _
    Sub LoadTestFile()
        m_MicroDVDLoader = New MicroDVDLoader
        m_MicroDVDLoader.Load(TestFile)
    End Sub

    <TearDown()> _
    Sub ClearWorklist()
        m_MicroDVDLoader.Dispose()
    End Sub

    <Test()> _
    Sub TestYamatoNadesico()
        Dim Captions As ICaptions

        Try
            Captions = m_MicroDVDLoader.GetSubTitles()

            Assert.Equals(615, Captions.Count)
            Assert.Equals(2836, Captions.Item(0).EnterTiming)
            Assert.Equals(12880, Captions.Item(0).LeaveTiming)
            Assert.Equals("�߸��� ��������(�Ϻ� ������ �Ƹ���� Ī��)|�����ڸ�:�ϳ��� ���/��ȭ��pacey77&edwiz@hanmail.net", Captions.Item(0).CaptionTitle)
            Assert.Equals(1153754, Captions.Item(239).EnterTiming)
            Assert.Equals(1156290, Captions.Item(239).LeaveTiming)
            Assert.Equals("���긴��(����)�� ���ִ� ����� 5000�����̻�����..", Captions.Item(239).CaptionTitle)
            Assert.Equals(2739139, Captions.Item(614).EnterTiming)
            Assert.Equals(2741141, Captions.Item(614).LeaveTiming)
            Assert.Equals("�����ڸ����� : Korea.com �Ϻ���󸶵�ȣȸ |juni@korea.com", Captions.Item(614).CaptionTitle)
        Catch e As SubFileParsingException
            Assert.Fail(e.Message)
        End Try
    End Sub

End Class
