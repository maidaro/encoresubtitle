Imports EncoreSubtitlesCommon

Delegate Sub AppendSubtitle(ByVal Source As Object, ByVal Args As ESTWorkItem)
Delegate Sub DeleteSubtitle(ByVal Source As Object, ByVal Key As Integer)
Delegate Sub ClearAllSubtitles(ByVal Source As Object)
Delegate Sub ProjectnameChanged(ByVal NewProjectname As String)

Class ESTProject
    Implements IEnumerable

    Private m_WorkList As New ESTWorkList
    Private m_Projectname As String

    Private m_IsSaved As Boolean
    Private m_Filepath As String
    Private m_IsDirty As Boolean

    Public Event OnAppendSubtitle As AppendSubtitle
    Public Event OnDeleteSubtitle As DeleteSubtitle
    Public Event OnClearAllSubtitls As ClearAllSubtitles
    Public Event OnProjectnameChanged As ProjectnameChanged

    Public Sub AppendSubtitleFiles(ByVal FilePath As String)
        Dim WorkItem As New ESTWorkItem

        WorkItem.SourceFullPath = FilePath
        m_WorkList.Append(WorkItem)
        m_IsDirty = True
        RaiseEvent OnAppendSubtitle(Me, WorkItem)
    End Sub

    Public Sub DeleteSubtitleFiles(ByVal Index As Integer)
        m_WorkList.Delete(m_WorkList.Item(Index).SourceFullPath())
        m_IsDirty = True
        RaiseEvent OnDeleteSubtitle(Me, Index)
    End Sub

    Public Sub ShowUI()
        Dim ProjectWnd As New Mainfrm(Me)

        ProjectWnd.ShowDialog()
    End Sub

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        m_WorkList.GetEnumerator()
    End Function

    Public ReadOnly Property Count() As Integer
        Get
            Return m_WorkList.Count
        End Get
    End Property

    Public Function Item(ByVal Index As Integer) As ESTWorkItem
        Return m_WorkList.Item(Index)
    End Function

    Public ReadOnly Property Projectname() As String
        Get
            Return m_Projectname
        End Get
    End Property

    Public Sub Clear()
        m_WorkList.Clear()
        RaiseEvent OnClearAllSubtitls(Me)
    End Sub

    Public Sub New()
        m_Projectname = "Untitled"
        m_IsSaved = False
        m_IsDirty = False
    End Sub

    Public Function Load(ByVal Filepath As String) As Boolean
        Dim Persistor As New ESTProjectPersist

        If Persistor.Load(Filepath) = False Then Return False
        m_Projectname = Persistor.Projectname
        m_Filepath = Filepath
        m_WorkList.Clear()
        For Each Workitem As ESTWorkItem In Persistor.Worklist
            AppendSubtitleFiles(Workitem.SourceFullPath)
        Next
        m_IsSaved = True
        m_IsDirty = False
        Return True
    End Function

    Public Function Save() As Boolean
        Dim Persistor As New ESTProjectPersist

        Persistor.Projectname = m_Projectname
        Persistor.Worklist = m_WorkList
        If Persistor.Save(m_Filepath) = False Then Return False
        m_IsSaved = True
        m_IsDirty = False
        Return True
    End Function

    Public Function SaveAs(ByVal Filepath As String) As Boolean
        Dim Persistor As New ESTProjectPersist

        Persistor.Projectname = FSUtils.EliminateFileTypes(FSUtils.ExtractFilename(Filepath))
        Persistor.Worklist = m_WorkList
        If Persistor.Save(Filepath) = False Then Return False
        m_Projectname = Persistor.Projectname
        m_Filepath = Filepath
        m_IsSaved = True
        m_IsDirty = False
        RaiseEvent OnProjectnameChanged(m_Projectname)
        Return True
    End Function

    Public ReadOnly Property IsSaved() As Boolean
        Get
            Return m_IsSaved
        End Get
    End Property

    Public ReadOnly Property IsDirty() As Boolean
        Get
            Return m_IsDirty
        End Get
    End Property
End Class
