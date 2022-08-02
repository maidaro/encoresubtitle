Imports System.Diagnostics
Imports System.XML
Imports System.IO

Public Class XMLAccessor
    Implements IDisposable

    Private m_XMLDoc As XmlDocument

    Public Function Open(ByVal Filename As String) As Boolean
        If File.Exists(Filename) = False Then Return False
        m_XMLDoc = New XmlDocument
        Try
            m_XMLDoc.Load(Filename)
        Catch e As XmlException
            m_XMLDoc = Nothing
            Return False
        End Try
        Return True
    End Function

    Public Function GetDocument(ByVal Nodename As String) As XmlNode
        Return m_XMLDoc.Item(Nodename).ChildNodes(0)
    End Function

    Public Function GetNodes(ByVal Node As XmlNode, ByVal Nodename As String) As XmlElement
        Return Node.Item(Nodename)
    End Function

    Public Function GetAttribute(ByVal Node As XmlNode, ByVal Attributename As String) As String
        Dim Attr As XmlAttribute

        For Each Attr In Node.Attributes
            If String.Compare(Attr.Name, AttributeName, True) = 0 Then
                Return Attr.Value
            End If
        Next
    End Function

    Public Function NewDocument(ByVal Nodename As String) As XmlNode
        m_XMLDoc = New XmlDocument
        m_XMLDoc.AppendChild(m_XMLDoc.CreateXmlDeclaration("1.0", "UTF-8", Nothing))
        Return m_XMLDoc.AppendChild(m_XMLDoc.CreateElement(Nodename))
    End Function

    Public Sub SetAttribute(ByVal Node As XmlNode, ByVal Attributename As String, ByVal Value As String)
        Dim NewAttribute As XmlAttribute = m_XMLDoc.CreateAttribute(Attributename)
        NewAttribute.Value = Value
        Node.Attributes.Append(NewAttribute)
    End Sub

    Public Function AppendNode(ByVal Node As XmlNode, ByVal Nodename As String) As XmlNode
        Dim NewNode As XmlNode = m_XMLDoc.CreateElement(Nodename)
        Node.AppendChild(NewNode)
        Return NewNode
    End Function

    Public Function Write(ByVal Filename As String) As Boolean
        Try
            m_XMLDoc.Save(Filename)
        Catch e As XmlException
            Return False
        End Try
        Return True
    End Function

    Public Sub Dispose() Implements System.IDisposable.Dispose

    End Sub
End Class

