Enum ParsingState
    EndOfToken
    InvalidStructure
    ParsingOK
    NotExpected
End Enum

Class ParsingResult
    Private m_ParsingState As ParsingState
    Private m_ParsingErrorMsg As String

    Public Property ParsingErrorMsg() As String
        Get
            Return m_ParsingErrorMsg
        End Get
        Set(ByVal Value As String)
            m_ParsingErrorMsg = Value
        End Set
    End Property

    Public Property ParsingState() As ParsingState
        Get
            Return m_ParsingState
        End Get
        Set(ByVal Value As ParsingState)
            m_ParsingState = Value
        End Set
    End Property
End Class

Public Class SubFileParsingException
    Inherits Exception

    Public Sub New(ByVal Message As String)
        MyBase.New(Message)
    End Sub
End Class
