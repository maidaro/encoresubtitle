Class ESTWorkList
    Implements IEnumerable

    Private m_WorkList As New Collection

    Public Sub Append(ByVal Item As ESTWorkItem)
        m_WorkList.Add(Item, Item.SourceFullPath)
    End Sub

    Public Sub Delete(ByVal ItemSource As String)
        m_WorkList.Remove(ItemSource)
    End Sub

    Public Sub Clear()
        Dim Count As Integer = m_WorkList.Count
        For i As Integer = 1 To Count
            m_WorkList.Remove(1)
        Next
    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Return m_WorkList.Count
        End Get
    End Property

    Public Function Item(ByVal Index As Integer) As ESTWorkItem
        If Index < 0 Or Index >= m_WorkList.Count Then Throw New IndexOutOfRangeException("Index Rance(" & 0 & " to " & m_WorkList.Count & ") , SetIndex(" & Index & ")")
        Return CType(m_WorkList.Item(Index + 1), ESTWorkItem)
    End Function

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return New ESTWorkListIterator(Me)
    End Function
End Class

Class ESTWorkListIterator
    Implements IEnumerator

    Private m_Source As ESTWorkList
    Private m_CurIndex As Integer


    Public Sub New(ByVal Source As ESTWorkList)
        m_Source = Source
        Reset()
    End Sub

    Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
            Return m_Source.Item(m_CurIndex)
        End Get
    End Property

    Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        m_CurIndex = m_CurIndex + 1
        Return m_CurIndex < m_Source.Count
    End Function

    Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        m_CurIndex = -1
    End Sub
End Class
