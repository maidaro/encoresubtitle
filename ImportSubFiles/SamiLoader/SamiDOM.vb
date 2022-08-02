Interface ISamiElement
    ReadOnly Property Value() As String
    ReadOnly Property Name() As String
    ReadOnly Property ChildNodes() As SamiNodeElements
    ReadOnly Property Attributes() As SamiAttributes
End Interface

Class SamiTextElement
    Implements ISamiElement

    Private m_TextValue As String

    Public ReadOnly Property Value() As String Implements ISamiElement.Value
        Get
            Return m_TextValue
        End Get
    End Property

    Public Sub New(ByVal Value As String)
        m_TextValue = Value
    End Sub

    Public ReadOnly Property Attributes() As SamiAttributes Implements ISamiElement.Attributes
        Get
            Return New SamiAttributes
        End Get
    End Property

    Public ReadOnly Property ChildNodes() As SamiNodeElements Implements ISamiElement.ChildNodes
        Get
            Return New SamiNodeElements
        End Get
    End Property

    Public ReadOnly Property Name() As String Implements ISamiElement.Name
        Get
            Return m_TextValue
        End Get
    End Property
End Class

Class SamiNodeElement
    Implements ISamiElement

    Private m_NodeName As String
    Private m_ChildNodes As SamiNodeElements
    Private m_Attributes As SamiAttributes

    Public ReadOnly Property Name() As String Implements ISamiElement.Name
        Get
            Return m_NodeName
        End Get
    End Property

    Public ReadOnly Property ChildNodes() As SamiNodeElements Implements ISamiElement.ChildNodes
        Get
            Return m_ChildNodes
        End Get
    End Property

    Public ReadOnly Property Attributes() As SamiAttributes Implements ISamiElement.Attributes
        Get
            Return m_Attributes
        End Get
    End Property

    Public ReadOnly Property Value() As String Implements ISamiElement.Value
        Get
            Return ""
        End Get
    End Property

    Public Sub New(ByVal NodeName As String)
        m_NodeName = NodeName
        m_ChildNodes = New SamiNodeElements
        m_Attributes = New SamiAttributes
    End Sub
End Class

Class SamiAttribute
    Private m_Name As String
    Private m_Value As String

    Public ReadOnly Property Name() As String
        Get
            Return m_Name
        End Get
    End Property

    Public ReadOnly Property Value() As String
        Get
            Return m_Value
        End Get
    End Property

    Public Sub New(ByVal Name As String, ByVal Value As String)
        m_Name = Name
        m_Value = Value
    End Sub
End Class

Class SamiNodeElements
    Private m_Nodes As Collection

    Public ReadOnly Property Count() As Integer
        Get
            Return m_Nodes.Count
        End Get
    End Property

    Public Function Item(ByVal Index As Integer) As ISamiElement
        Return CType(m_Nodes.Item(Index + 1), ISamiElement)
    End Function

    Public Sub AddItem(ByVal Item As ISamiElement)
        m_Nodes.Add(Item)
    End Sub

    Public Sub New()
        m_Nodes = New Collection
    End Sub
End Class

Class SamiAttributes
    Private m_Attributes As Collection

    Public ReadOnly Property Count() As Integer
        Get
            Return m_Attributes.Count
        End Get
    End Property

    Public Function Item(ByVal Index As Integer) As SamiAttribute
        Return CType(m_Attributes.Item(Index + 1), SamiAttribute)
    End Function

    Public Sub AddItem(ByVal Item As SamiAttribute)
        m_Attributes.Add(Item)
    End Sub

    Public Sub New()
        m_Attributes = New Collection
    End Sub
End Class
