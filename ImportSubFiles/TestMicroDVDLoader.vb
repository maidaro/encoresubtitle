Imports csUnit
Imports EncoreSubtitlesCommon

<TestFixture()> _
Public Class TestMicroDVDLoader
    Private Shared TestFile As String = "..\..\Samples\『 やまとなでしこ 』Vol.01.sub"
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
            Assert.Equals("야마토 나데시코(일본 여성을 아름답게 칭함)|번역자막:하나넷 드라마/영화동pacey77&edwiz@hanmail.net", Captions.Item(0).CaptionTitle)
            Assert.Equals(1153754, Captions.Item(239).EnterTiming)
            Assert.Equals(1156290, Captions.Item(239).LeaveTiming)
            Assert.Equals("사라브릿드(마종)의 마주는 년수입 5000만엔이상으로..", Captions.Item(239).CaptionTitle)
            Assert.Equals(2739139, Captions.Item(614).EnterTiming)
            Assert.Equals(2741141, Captions.Item(614).LeaveTiming)
            Assert.Equals("최종자막수정 : Korea.com 일본드라마동호회 |juni@korea.com", Captions.Item(614).CaptionTitle)
        Catch e As SubFileParsingException
            Assert.Fail(e.Message)
        End Try
    End Sub

End Class
