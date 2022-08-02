Imports csUnit
Imports EncoreSubtitlesCommon

<TestFixture()> _
Public Class TestExportOptionsUI
    Private Options As ExportOptions
    Private OptionsUI As ExportOptionsUI

    <FixtureSetUp()> _
    Sub CreateObject()
        Options = New ExportOptions
        OptionsUI = New ExportOptionsUI(Options)
        OptionsUI.Show() ' For testing even Form will operate as Modal, It must be open as Modaless Dialog
    End Sub

    <Test()> _
    Sub TestAutoArrangeTimingCheck()
        Assert.True(Options.ArrangeTiming)
        Assert.True(OptionsUI.EnableArrangeTiming.Checked)
        OptionsUI.EnableArrangeTiming.Checked = False
        Assert.False(Options.ArrangeTiming)
    End Sub

    <Test()> _
    Sub TestAutoWordWrapCheck()
        Assert.True(Options.WordWrap)
        Assert.True(OptionsUI.EnableWordWrap.Checked)
        OptionsUI.EnableWordWrap.Checked = False
        Assert.False(Options.WordWrap)
    End Sub

    <Test()> _
    Sub TestMaxLineLengthText()
        Assert.Equals(23, Options.LineLength)
        Assert.Equals("23", OptionsUI.MaxLineLength.Text)
        OptionsUI.MaxLineLength.Text = "40"
        Assert.Equals(40, Options.LineLength)
    End Sub

    <Test()> _
    Sub TestVideoSystemCombo()
        Assert.Equals(VideoSystemTypes.NTSC, Options.VideoSystem)
        Assert.Equals(0, OptionsUI.VideoSystemCombo.SelectedIndex)
        OptionsUI.VideoSystemCombo.SelectedIndex = 1
        Assert.Equals(VideoSystemTypes.PAL, Options.VideoSystem)
    End Sub
End Class
