Public Class CaptionImpl
    Implements ICaption

    Private m_EnterTiming As Integer
    Private m_LeaveTiming As Integer
    Private m_Title As String

    Public Property CaptionTitle() As String Implements ICaption.CaptionTitle
        Get
            Return m_Title
        End Get
        Set(ByVal Value As String)
            m_Title = Value
        End Set
    End Property

    Public Property EnterTiming() As Integer Implements ICaption.EnterTiming
        Get
            Return m_EnterTiming
        End Get
        Set(ByVal Value As Integer)
            m_EnterTiming = Value
        End Set
    End Property

    Public Property LeaveTiming() As Integer Implements ICaption.LeaveTiming
        Get
            Return m_LeaveTiming
        End Get
        Set(ByVal Value As Integer)
            m_LeaveTiming = Value
        End Set
    End Property

    Public Function Clone() As Object Implements ICaption.Clone
        Dim CloneObj As New CaptionImpl

        CloneObj.m_Title = m_Title
        CloneObj.m_EnterTiming = m_EnterTiming
        CloneObj.m_LeaveTiming = m_LeaveTiming
        Return CloneObj
    End Function
End Class
