Imports ExportSubFiles
Imports EncoreSubtitlesCommon

Class Mainfrm
    Inherits System.Windows.Forms.Form

    Private WithEvents m_Source As ESTProject
    Private Shared m_Appname As String = "Encore Subtitles"

#Region " Windows Form Designer generated code "
    Public Sub New(ByVal Source As ESTProject)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeComponentUserCode(Source)
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
    Friend WithEvents WorkList As System.Windows.Forms.ListView
    Friend WithEvents CaptionList As System.Windows.Forms.ListView
    Friend WithEvents WorkspaceSplitter As System.Windows.Forms.Splitter
    Friend WithEvents MainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents WorklistContextMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFileExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFileOpen As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSave As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSaveAs As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAddSubtitle As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRemoveSubtitle As System.Windows.Forms.MenuItem
    Friend WithEvents hdrSource As System.Windows.Forms.ColumnHeader
    Friend WithEvents hdrOutputPath As System.Windows.Forms.ColumnHeader
    Friend WithEvents hdrNumber As System.Windows.Forms.ColumnHeader
    Friend WithEvents hdrEnterTiming As System.Windows.Forms.ColumnHeader
    Friend WithEvents hdrLeaveTiming As System.Windows.Forms.ColumnHeader
    Friend WithEvents hdrCaptionTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents WorkPanel As System.Windows.Forms.Panel
    Friend WithEvents mnuShowCaptions As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExportSubtitle As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFileSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelpSparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelpAbout As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelpUsing As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.WorkList = New System.Windows.Forms.ListView
        Me.hdrSource = New System.Windows.Forms.ColumnHeader
        Me.hdrOutputPath = New System.Windows.Forms.ColumnHeader
        Me.WorklistContextMenu = New System.Windows.Forms.ContextMenu
        Me.mnuAddSubtitle = New System.Windows.Forms.MenuItem
        Me.mnuRemoveSubtitle = New System.Windows.Forms.MenuItem
        Me.mnuShowCaptions = New System.Windows.Forms.MenuItem
        Me.mnuExportSubtitle = New System.Windows.Forms.MenuItem
        Me.WorkspaceSplitter = New System.Windows.Forms.Splitter
        Me.CaptionList = New System.Windows.Forms.ListView
        Me.hdrNumber = New System.Windows.Forms.ColumnHeader
        Me.hdrEnterTiming = New System.Windows.Forms.ColumnHeader
        Me.hdrLeaveTiming = New System.Windows.Forms.ColumnHeader
        Me.hdrCaptionTitle = New System.Windows.Forms.ColumnHeader
        Me.MainMenu = New System.Windows.Forms.MainMenu
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuFileOpen = New System.Windows.Forms.MenuItem
        Me.mnuSave = New System.Windows.Forms.MenuItem
        Me.mnuSaveAs = New System.Windows.Forms.MenuItem
        Me.mnuFileSeparator1 = New System.Windows.Forms.MenuItem
        Me.mnuFileExit = New System.Windows.Forms.MenuItem
        Me.mnuHelp = New System.Windows.Forms.MenuItem
        Me.mnuHelpUsing = New System.Windows.Forms.MenuItem
        Me.mnuHelpSparator1 = New System.Windows.Forms.MenuItem
        Me.mnuHelpAbout = New System.Windows.Forms.MenuItem
        Me.WorkPanel = New System.Windows.Forms.Panel
        Me.WorkPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'WorkList
        '
        Me.WorkList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.hdrSource, Me.hdrOutputPath})
        Me.WorkList.ContextMenu = Me.WorklistContextMenu
        Me.WorkList.Dock = System.Windows.Forms.DockStyle.Top
        Me.WorkList.FullRowSelect = True
        Me.WorkList.HideSelection = False
        Me.WorkList.Location = New System.Drawing.Point(0, 0)
        Me.WorkList.Name = "WorkList"
        Me.WorkList.Size = New System.Drawing.Size(576, 160)
        Me.WorkList.TabIndex = 0
        Me.WorkList.View = System.Windows.Forms.View.Details
        '
        'hdrSource
        '
        Me.hdrSource.Text = "Source Subtitle file"
        Me.hdrSource.Width = 220
        '
        'hdrOutputPath
        '
        Me.hdrOutputPath.Text = "Output Path"
        Me.hdrOutputPath.Width = 351
        '
        'WorklistContextMenu
        '
        Me.WorklistContextMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAddSubtitle, Me.mnuRemoveSubtitle, Me.mnuShowCaptions, Me.mnuExportSubtitle})
        '
        'mnuAddSubtitle
        '
        Me.mnuAddSubtitle.Index = 0
        Me.mnuAddSubtitle.Text = "&Add Subtitle(s)"
        '
        'mnuRemoveSubtitle
        '
        Me.mnuRemoveSubtitle.Index = 1
        Me.mnuRemoveSubtitle.Text = "&Remove Subtitle(s)"
        '
        'mnuShowCaptions
        '
        Me.mnuShowCaptions.Index = 2
        Me.mnuShowCaptions.Text = "&Show Captions"
        '
        'mnuExportSubtitle
        '
        Me.mnuExportSubtitle.Index = 3
        Me.mnuExportSubtitle.Text = "&Export Subtitle(s)"
        '
        'WorkspaceSplitter
        '
        Me.WorkspaceSplitter.Dock = System.Windows.Forms.DockStyle.Top
        Me.WorkspaceSplitter.Location = New System.Drawing.Point(0, 160)
        Me.WorkspaceSplitter.Name = "WorkspaceSplitter"
        Me.WorkspaceSplitter.Size = New System.Drawing.Size(576, 4)
        Me.WorkspaceSplitter.TabIndex = 1
        Me.WorkspaceSplitter.TabStop = False
        '
        'CaptionList
        '
        Me.CaptionList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.hdrNumber, Me.hdrEnterTiming, Me.hdrLeaveTiming, Me.hdrCaptionTitle})
        Me.CaptionList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CaptionList.FullRowSelect = True
        Me.CaptionList.Location = New System.Drawing.Point(0, 164)
        Me.CaptionList.Name = "CaptionList"
        Me.CaptionList.Size = New System.Drawing.Size(576, 210)
        Me.CaptionList.TabIndex = 2
        Me.CaptionList.View = System.Windows.Forms.View.Details
        '
        'hdrNumber
        '
        Me.hdrNumber.Text = "Num"
        Me.hdrNumber.Width = 66
        '
        'hdrEnterTiming
        '
        Me.hdrEnterTiming.Text = "Show"
        Me.hdrEnterTiming.Width = 78
        '
        'hdrLeaveTiming
        '
        Me.hdrLeaveTiming.Text = "Hide"
        Me.hdrLeaveTiming.Width = 80
        '
        'hdrCaptionTitle
        '
        Me.hdrCaptionTitle.Text = "Caption Title"
        Me.hdrCaptionTitle.Width = 347
        '
        'MainMenu
        '
        Me.MainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFileOpen, Me.mnuSave, Me.mnuSaveAs, Me.mnuFileSeparator1, Me.mnuFileExit})
        Me.mnuFile.Text = "&File"
        '
        'mnuFileOpen
        '
        Me.mnuFileOpen.Index = 0
        Me.mnuFileOpen.Text = "&Open Project ..."
        '
        'mnuSave
        '
        Me.mnuSave.Index = 1
        Me.mnuSave.Text = "&Save Project"
        '
        'mnuSaveAs
        '
        Me.mnuSaveAs.Index = 2
        Me.mnuSaveAs.Text = "&Save Project As ..."
        '
        'mnuFileSeparator1
        '
        Me.mnuFileSeparator1.Index = 3
        Me.mnuFileSeparator1.Text = "-"
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Index = 4
        Me.mnuFileExit.Text = "&Exit"
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 1
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuHelpUsing, Me.mnuHelpSparator1, Me.mnuHelpAbout})
        Me.mnuHelp.Text = "&Help"
        '
        'mnuHelpUsing
        '
        Me.mnuHelpUsing.Index = 0
        Me.mnuHelpUsing.Text = "&Using ..."
        '
        'mnuHelpSparator1
        '
        Me.mnuHelpSparator1.Index = 1
        Me.mnuHelpSparator1.Text = "-"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Index = 2
        Me.mnuHelpAbout.Text = "&About Encore Subtitles ..."
        '
        'WorkPanel
        '
        Me.WorkPanel.Controls.Add(Me.CaptionList)
        Me.WorkPanel.Controls.Add(Me.WorkspaceSplitter)
        Me.WorkPanel.Controls.Add(Me.WorkList)
        Me.WorkPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkPanel.Location = New System.Drawing.Point(0, 0)
        Me.WorkPanel.Name = "WorkPanel"
        Me.WorkPanel.Size = New System.Drawing.Size(576, 374)
        Me.WorkPanel.TabIndex = 3
        '
        'Mainfrm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(576, 374)
        Me.Controls.Add(Me.WorkPanel)
        Me.Menu = Me.MainMenu
        Me.MinimumSize = New System.Drawing.Size(448, 408)
        Me.Name = "Mainfrm"
        Me.Text = "Encore Subtitles"
        Me.WorkPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub mnuAddSubtitle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAddSubtitle.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.InitialDirectory = CurDir()
        OpenFileDialog1.Filter = ImportSubFiles.SubFileLoader.GetSupportedFileFilters()
        OpenFileDialog1.Multiselect = True
        If OpenFileDialog1.ShowDialog <> DialogResult.OK Then Exit Sub
        AppendWorkItem(OpenFileDialog1)
    End Sub

    Private Sub mnuFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        Me.Close()
    End Sub

    Private Sub mnuRemoveSubtitle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuRemoveSubtitle.Click
        RemoveSelectedWorkItem()
    End Sub

    Private Sub WorkList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WorkList.SelectedIndexChanged
        UpdateWorklistContextMenuState()
    End Sub

    Sub AppendWorkItem(ByVal ofd As OpenFileDialog)
        For Each Filename As String In ofd.FileNames
            m_Source.AppendSubtitleFiles(Filename)
        Next
    End Sub

    Private Sub UpdateWorklistContextMenuState()
        If WorkList.SelectedItems.Count = 0 Then
            mnuRemoveSubtitle.Enabled = False
            mnuExportSubtitle.Enabled = False
        Else
            mnuRemoveSubtitle.Enabled = True
            mnuExportSubtitle.Enabled = True
        End If
        If WorkList.SelectedItems.Count = 1 Then
            mnuShowCaptions.Enabled = True
        Else
            mnuShowCaptions.Enabled = False
        End If
    End Sub

    Public Sub UpdateSubtitleDetails()
        CaptionList.Items.Clear()
        ShowSubtitleDetails(WorkList.SelectedItems(0).SubItems(1).Text + WorkList.SelectedItems(0).Text)
    End Sub

    Private Sub ShowSubtitleDetails(ByVal FullFilepath As String)
        Dim WorkItem As ESTWorkItem = m_Source.Item(WorkList.SelectedItems(0).Index)
        Dim CaptionsTitles As ICaptions

        Try
            CaptionsTitles = WorkItem.Captions
        Catch e As ImportSubFiles.SubFileParsingException
            MsgBox(e.Message)
            Exit Sub
        End Try
        Cursor.Current = Cursors.WaitCursor
        CaptionList.BeginUpdate()
        For Each CaptionTitle As ICaption In CaptionsTitles
            Dim NewCaptionListItem As System.Windows.Forms.ListViewItem = CaptionList.Items.Add(CaptionList.Items.Count + 1)
            NewCaptionListItem.SubItems.Add(CaptionTitle.EnterTiming)
            NewCaptionListItem.SubItems.Add(CaptionTitle.LeaveTiming)
            NewCaptionListItem.SubItems.Add(CaptionTitle.CaptionTitle)
        Next
        CaptionList.EndUpdate()
        Cursor.Current = Cursors.Default
    End Sub

    Sub RemoveSelectedWorkItem()
        For Each Item As System.Windows.Forms.ListViewItem In WorkList.SelectedItems
            m_Source.DeleteSubtitleFiles(Item.Index)
        Next
    End Sub

    Public Function ExportSubfiles() As String
        Dim ResultMessage As String = ""
        Dim Exporter As New ExportSubFiles.EncoreDVDExporter
        Dim ExportOptions As New ExportOptions

        If ExportOptions.ShowUI() <> DialogResult.OK Then Return ResultMessage
        Cursor.Current = Cursors.WaitCursor
        For Each Item As System.Windows.Forms.ListViewItem In WorkList.SelectedItems
            Dim WorkItem As ESTWorkItem = m_Source.Item(Item.Index)
            Dim ExportFileFullpath As String = FSUtils.EliminateFileTypes(WorkItem.SourceFullPath)
            Try
                Exporter.ExportCaptions(WorkItem.Captions, Exporter.FileExtension.Replace("*", ExportFileFullpath), ExportOptions.BindToStringDictionary())
            Catch e As ImportSubFiles.SubFileParsingException
                ResultMessage = ResultMessage & e.Message & " at " & WorkItem.SourceFileName & vbCrLf
            End Try
        Next
        Cursor.Current = Cursors.Default
        Return ResultMessage
    End Function

    Private Sub InitializeComponentUserCode(ByVal Source As ESTProject)
        m_Source = Source
        Me.Text = m_Appname & " - " & m_Source.Projectname
        UpdateWorklistContextMenuState()
    End Sub

    Private Sub m_Source_OnAppendSubtitle(ByVal Source As Object, ByVal Args As ESTWorkItem) Handles m_Source.OnAppendSubtitle
        WorkList.Items.Add(Args.SourceFileName).SubItems.Add(Args.OutputPath)
    End Sub

    Private Sub m_Source_OnDeleteSubtitle(ByVal Source As Object, ByVal Key As Integer) Handles m_Source.OnDeleteSubtitle
        WorkList.Items.RemoveAt(Key)
    End Sub

    Private Sub m_Source_OnClearAllSubtitls(ByVal Source As Object) Handles m_Source.OnClearAllSubtitls
        WorkList.Items.Clear()
    End Sub

    Private Sub mnuShowCaptions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuShowCaptions.Click
        UpdateSubtitleDetails()
    End Sub

    Private Sub mnuExportSubtitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExportSubtitle.Click
        Dim ResultMessage As String = ExportSubfiles()
        If ResultMessage.Length <> 0 Then
            MsgBox(ResultMessage)
        End If
    End Sub

    Public Function ProjectLoad(ByVal Filepath As String) As Boolean
        Return m_Source.Load(Filepath)
    End Function

    Public Function ProjectSave() As Boolean
        Return m_Source.Save()
    End Function

    Public Function ProjectSaveAs(ByVal Filepath As String) As Boolean
        Return m_Source.SaveAs(Filepath)
    End Function

    Private Function SaveAsWithDialog() As Boolean
        Dim SaveFileDialog1 As New SaveFileDialog
        SaveFileDialog1.InitialDirectory = CurDir()
        SaveFileDialog1.Filter = "Encore Subtitles project files(*.xml)|*.xml"
        SaveFileDialog1.FileName = m_Source.Projectname
        If SaveFileDialog1.ShowDialog() <> DialogResult.OK Then Return True
        Return ProjectSaveAs(SaveFileDialog1.FileName)
    End Function

    Private Sub mnuSaveAs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSaveAs.Click
        If SaveAsWithDialog() = False Then
            MsgBox("Save Failed!", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub mnuSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSave.Click
        If m_Source.IsSaved = True Then
            If ProjectSave() = False Then
                MsgBox("Save Failed!", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical)
            End If
        Else
            If SaveAsWithDialog() = False Then
                MsgBox("Save Failed!", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub mnuFileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpen.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.InitialDirectory = CurDir()
        OpenFileDialog1.Filter = "Encore Subtitles project files(*.xml)|*.xml"
        If OpenFileDialog1.ShowDialog <> DialogResult.OK Then Exit Sub
        If ProjectLoad(OpenFileDialog1.FileName) = False Then
            MsgBox("Load Failed!", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub mnuFile_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile.Popup
        mnuSave.Enabled = m_Source.IsDirty
        mnuSaveAs.Enabled = m_Source.IsDirty
    End Sub

    Private Sub m_Source_OnProjectnameChanged(ByVal NewProjectname As String) Handles m_Source.OnProjectnameChanged
        Me.Text = m_Appname & " - " & NewProjectname
    End Sub


    Private Sub Mainfrm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If m_Source.IsDirty = False Then Exit Sub

        Select Case MsgBox(m_Source.Projectname & " is not saved. Save project before Exit?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Information)
            Case MsgBoxResult.Yes
                If SaveAsWithDialog() = False Then
                    MsgBox("Save Failed!", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical)
                End If
            Case MsgBoxResult.Cancel
                e.Cancel = True
        End Select
    End Sub

    Private Sub mnuHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpAbout.Click
        Dim About As New AboutDialog

        About.ShowDialog(Me)
    End Sub

    Private Sub mnuHelpUsing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpUsing.Click
        Dim UsingHelp As String
        UsingHelp = "1. Click right-button on Worklist Area(above list control)." & vbCrLf
        UsingHelp = UsingHelp & "2. Append Subtitle files." & vbCrLf
        UsingHelp = UsingHelp & "3. Select some files." & vbCrLf
        UsingHelp = UsingHelp & "4. (Optional, but strongly recommended) Arrange Timing." & vbCrLf
        UsingHelp = UsingHelp & "5. Export subtitle files and fun it at Abode EncoreDVD."

        MsgBox(UsingHelp, MsgBoxStyle.OKOnly Or MsgBoxStyle.Information)
    End Sub
End Class
