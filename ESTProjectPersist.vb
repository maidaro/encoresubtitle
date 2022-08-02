Imports System.Xml
Imports XMLAccessor
Imports System.IO

Class ESTProjectPersist
    Private m_Projectname As String
    Private m_WorkList As ESTWorkList

    Public Property Projectname() As String
        Get
            Return m_Projectname
        End Get
        Set(ByVal Value As String)
            m_Projectname = Value
        End Set
    End Property

    Public Property Worklist() As ESTWorkList
        Get
            Return m_WorkList
        End Get
        Set(ByVal Value As ESTWorkList)
            m_WorkList = Value
        End Set
    End Property

    Public Function Load(ByVal ProjectFullpath As String) As Boolean
        Dim XMLAccessor As New XMLAccessor.XMLAccessor

        If XMLAccessor.Open(ProjectFullpath) = False Then Return False
        Dim ProjectNode As XmlNode = XMLAccessor.GetDocument("ENCORESUBTITLE")
        Try
            m_WorkList = New ESTWorkList
            m_Projectname = XMLAccessor.GetAttribute(ProjectNode, "PROJECTNAME")
            For Each Item As XmlNode In ProjectNode.ChildNodes
                Dim Workitem As New ESTWorkItem
                Workitem.SourceFullPath = XMLAccessor.GetAttribute(Item, "FILEPATH")
                m_WorkList.Append(Workitem)
            Next
        Catch e As XmlException
            Return False
        Finally
            XMLAccessor.Dispose()
        End Try
        Return True
    End Function

    Public Function Save(ByVal ProjectFullpath As String) As Boolean
        Dim XMLAccessor As New XMLAccessor.XMLAccessor

        Dim XMLDoc As XmlNode = XMLAccessor.NewDocument("ENCORESUBTITLE")
        Dim ProjectNode As XmlNode = XMLAccessor.AppendNode(XMLDoc, "PROJECT")
        XMLAccessor.SetAttribute(ProjectNode, "PROJECTNAME", m_Projectname)
        For Each Item As ESTWorkItem In m_WorkList
            Dim WorkitemNode As XmlNode = XMLAccessor.AppendNode(ProjectNode, "WORKITEM")
            XMLAccessor.SetAttribute(WorkitemNode, "FILEPATH", Item.SourceFullPath)
        Next
        If XMLAccessor.Write(ProjectFullpath) = False Then
            XMLAccessor.Dispose()
            Return False
        End If
        XMLAccessor.Dispose()
        Return True
    End Function
End Class
