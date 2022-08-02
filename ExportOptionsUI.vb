Class ExportOptionsUI
    Inherits System.Windows.Forms.Form

    Private _Source As ExportOptions

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Source As ExportOptions)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _Source = Source
        BindSource()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents EnableArrangeTiming As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MaxLineLength As System.Windows.Forms.TextBox
    Friend WithEvents EnableWordWrap As System.Windows.Forms.CheckBox
    Friend WithEvents OkBtn As System.Windows.Forms.Button
    Friend WithEvents CancelBtn As System.Windows.Forms.Button
    Friend WithEvents VideoSystemCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents EnableDelLineBreaker As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.EnableArrangeTiming = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.EnableDelLineBreaker = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.MaxLineLength = New System.Windows.Forms.TextBox
        Me.EnableWordWrap = New System.Windows.Forms.CheckBox
        Me.OkBtn = New System.Windows.Forms.Button
        Me.CancelBtn = New System.Windows.Forms.Button
        Me.VideoSystemCombo = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'EnableArrangeTiming
        '
        Me.EnableArrangeTiming.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.EnableArrangeTiming.Location = New System.Drawing.Point(12, 8)
        Me.EnableArrangeTiming.Name = "EnableArrangeTiming"
        Me.EnableArrangeTiming.Size = New System.Drawing.Size(140, 20)
        Me.EnableArrangeTiming.TabIndex = 0
        Me.EnableArrangeTiming.Text = "Auto Arrange Timing"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.EnableDelLineBreaker)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.MaxLineLength)
        Me.GroupBox1.Controls.Add(Me.EnableWordWrap)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(220, 88)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Auto Wordwrap"
        '
        'EnableDelLineBreaker
        '
        Me.EnableDelLineBreaker.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.EnableDelLineBreaker.Location = New System.Drawing.Point(8, 60)
        Me.EnableDelLineBreaker.Name = "EnableDelLineBreaker"
        Me.EnableDelLineBreaker.Size = New System.Drawing.Size(132, 20)
        Me.EnableDelLineBreaker.TabIndex = 9
        Me.EnableDelLineBreaker.Text = "Delete Linebreaker"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(176, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "chars"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Wordwrap over "
        '
        'MaxLineLength
        '
        Me.MaxLineLength.Location = New System.Drawing.Point(128, 32)
        Me.MaxLineLength.MaxLength = 3
        Me.MaxLineLength.Name = "MaxLineLength"
        Me.MaxLineLength.Size = New System.Drawing.Size(40, 21)
        Me.MaxLineLength.TabIndex = 6
        Me.MaxLineLength.Text = ""
        '
        'EnableWordWrap
        '
        Me.EnableWordWrap.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.EnableWordWrap.Location = New System.Drawing.Point(8, 16)
        Me.EnableWordWrap.Name = "EnableWordWrap"
        Me.EnableWordWrap.Size = New System.Drawing.Size(64, 20)
        Me.EnableWordWrap.TabIndex = 5
        Me.EnableWordWrap.Text = "Enable"
        '
        'OkBtn
        '
        Me.OkBtn.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OkBtn.Location = New System.Drawing.Point(34, 160)
        Me.OkBtn.Name = "OkBtn"
        Me.OkBtn.Size = New System.Drawing.Size(68, 28)
        Me.OkBtn.TabIndex = 6
        Me.OkBtn.Text = "Ok"
        '
        'CancelBtn
        '
        Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CancelBtn.Location = New System.Drawing.Point(126, 160)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(68, 28)
        Me.CancelBtn.TabIndex = 7
        Me.CancelBtn.Text = "Cancel"
        '
        'VideoSystemCombo
        '
        Me.VideoSystemCombo.DisplayMember = "NTSC"
        Me.VideoSystemCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.VideoSystemCombo.Items.AddRange(New Object() {"NTSC", "PAL"})
        Me.VideoSystemCombo.Location = New System.Drawing.Point(104, 132)
        Me.VideoSystemCombo.Name = "VideoSystemCombo"
        Me.VideoSystemCombo.Size = New System.Drawing.Size(96, 20)
        Me.VideoSystemCombo.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Video System"
        '
        'ExportOptionsUI
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(228, 196)
        Me.Controls.Add(Me.VideoSystemCombo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.OkBtn)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.EnableArrangeTiming)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ExportOptionsUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Set Export Options"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BindSource()
        EnableArrangeTiming.Checked = _Source.ArrangeTiming
        EnableWordWrap.Checked = _Source.WordWrap
        MaxLineLength.Text = _Source.LineLength
        EnableDelLineBreaker.Checked = _Source.DelLineBreaker
        SetVideoSystemCombo()
    End Sub

    Private Sub SetVideoSystemCombo()
        Select Case _Source.VideoSystem
            Case EncoreSubtitlesCommon.VideoSystemTypes.NTSC
                VideoSystemCombo.SelectedIndex = 0
            Case EncoreSubtitlesCommon.VideoSystemTypes.PAL
                VideoSystemCombo.SelectedIndex = 1
        End Select
    End Sub

    Private Sub EnableArrangeTiming_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableArrangeTiming.CheckedChanged
        _Source.ArrangeTiming = EnableArrangeTiming.Checked
    End Sub

    Private Sub EnableWordWrap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableWordWrap.CheckedChanged
        _Source.WordWrap = EnableWordWrap.Checked
        Label1.Enabled = EnableWordWrap.Checked
        MaxLineLength.Enabled = EnableWordWrap.Checked
        Label2.Enabled = EnableWordWrap.Checked
        EnableDelLineBreaker.Enabled = EnableWordWrap.Checked
    End Sub

    Private Sub MaxLineLength_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaxLineLength.TextChanged
        _Source.LineLength = MaxLineLength.Text
    End Sub

    Private Sub VideoSystemCombo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VideoSystemCombo.SelectedValueChanged
        Select Case VideoSystemCombo.SelectedIndex
            Case 0
                _Source.VideoSystem = EncoreSubtitlesCommon.VideoSystemTypes.NTSC
            Case 1
                _Source.VideoSystem = EncoreSubtitlesCommon.VideoSystemTypes.PAL
        End Select
    End Sub

    Private Sub EnableDelLineBreaker_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableDelLineBreaker.CheckedChanged
        _Source.DelLineBreaker = EnableDelLineBreaker.Checked
    End Sub
End Class
