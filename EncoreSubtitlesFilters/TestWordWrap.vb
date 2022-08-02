Imports csUnit
Imports EncoreSubtitlesCommon

<TestFixture()> _
Public Class TestWordWrap
    <Test()> _
    Sub TestArrangeTiming()
        Dim WordWrapFilter As New AutoWordWrap
        Dim Captions As New CaptionsImpl
        Dim Caption As CaptionImpl

        Caption = New CaptionImpl
        Caption.CaptionTitle = "야마토 나데시코(일본 여성을 아름답게 칭함)|번역자막:하나넷 드라마/영화동pacey77&edwiz@hanmail.net"
        Captions.Append(Caption)
        Caption = New CaptionImpl
        Caption.CaptionTitle = "야마토나데시코(일본여성을아름답게칭함XYZ"
        Captions.Append(Caption)

        Dim ModifiedSubtitle As ICaptions = WordWrapFilter.ApplyFilter(Captions, Nothing)
        Assert.Equals("야마토 나데시코(일본 여성을 아름답게|칭함)|번역자막:하나넷 드라마|/영화동pacey77&edwiz|@hanmail.net", ModifiedSubtitle.Item(0).CaptionTitle)
        Assert.Equals("야마토나데시코(일본여성을아름답게칭함XYZ", ModifiedSubtitle.Item(1).CaptionTitle)
    End Sub
End Class
