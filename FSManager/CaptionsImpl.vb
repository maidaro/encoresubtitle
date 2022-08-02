Public Class CaptionsImpl
    Implements ICaptions

    Private m_Captions As New Collection

    Public ReadOnly Property Count() As Integer Implements ICaptions.Count
        Get
            Return m_Captions.Count
        End Get
    End Property

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements ICaptions.GetEnumerator
        Return New CaptionTitleIterator(Me)
    End Function

    Public Function Item(ByVal Index As Integer) As ICaption Implements ICaptions.Item
        If Index < 0 Or Index >= m_Captions.Count Then Throw New IndexOutOfRangeException("Index Rance(" & 0 & " to " & m_Captions.Count & ") , SetIndex(" & Index & ")")
        Return CType(m_Captions.Item(Index + 1), ICaption)
    End Function

    Public Sub Append(ByVal Item As ICaption)
        m_Captions.Add(Item)
    End Sub

    Public Function Clone() As Object Implements ICaptions.Clone
        Dim CloneObj As New CaptionsImpl

        For Each Item As CaptionImpl In m_Captions
            CloneObj.m_Captions.Add(Item.Clone())
        Next
        Return CloneObj
    End Function
End Class

Public Class CaptionTitleIterator
    Implements IEnumerator

    Private m_Source As CaptionsImpl
    Private m_CurIndex As Integer

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

    Public Sub New(ByVal Source As CaptionsImpl)
        m_Source = Source
        Reset()
    End Sub
End Class