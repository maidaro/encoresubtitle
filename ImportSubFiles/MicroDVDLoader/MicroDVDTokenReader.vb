Public Enum MicroDVDTokenType
    EndOfToken
    Delimiter
    Text
    UnkownToken
    LineBraker
End Enum

Class MicroDVDToken
    Private m_TokenString As String
    Private m_TokenType As MicroDVDTokenType

    Public ReadOnly Property TokenString() As String
        Get
            Return m_TokenString
        End Get
    End Property

    Public ReadOnly Property TokenType() As MicroDVDTokenType
        Get
            Return m_TokenType
        End Get
    End Property

    Public Sub New(ByVal Value As String, ByVal Type As MicroDVDTokenType)
        m_TokenString = Value
        m_TokenType = Type
    End Sub

    Public Sub New(ByVal Value As Char, ByVal Type As MicroDVDTokenType)
        m_TokenString = Value
        m_TokenType = Type
    End Sub
End Class

Class MicroDVDTokenReader
    Private m_StreamReader As System.IO.StreamReader
    Private m_UndoChars As Stack
    Private m_TextContext As Boolean
    Private m_UndoTokens As Stack

    Public Property TextContext() As Boolean
        Get
            Return m_TextContext
        End Get
        Set(ByVal Value As Boolean)
            m_TextContext = Value
        End Set
    End Property

    Private Function IsDelimiter(ByVal ch As Char) As Boolean
        If ch = "{" Then Return True
        If ch = "}" And m_TextContext = False Then Return True
        Return False
    End Function

    Private Function IsWhiteSpace(ByVal ch As Char) As Boolean
        If ch = " " And m_TextContext = False Then Return True
        If ch = vbTab Then Return True
        If ch = vbLf Then Return True
        Return False
    End Function

    Private Function IsLineBreaker(ByVal ch As Char) As Boolean
        If ch = vbCr Then Return True
    End Function

    Private Function IsEndOfStream(ByVal ch As Char) As Boolean
        Return ch = vbNullChar
    End Function

    Public Function GetToken() As MicroDVDToken
        If m_UndoTokens.Count <> 0 Then Return RedoToken()

        Dim ch As Char = GetCharFromStream()
        While IsWhiteSpace(ch) And Not IsEndOfStream(ch)
            ch = GetCharFromStream()
        End While
        If IsEndOfStream(ch) Then Return New MicroDVDToken(vbNullChar, MicroDVDTokenType.EndOfToken)
        If IsDelimiter(ch) Then Return New MicroDVDToken(ch, MicroDVDTokenType.Delimiter)
        If IsLineBreaker(ch) Then Return New MicroDVDToken(ch, MicroDVDTokenType.LineBraker)
        Return New MicroDVDToken(ExtractText(ch), MicroDVDTokenType.Text)
    End Function

    Private Function ExtractText(ByVal ch As Char) As String
        Dim TokenString As String

        While Not (IsWhiteSpace(ch) Or IsEndOfStream(ch) Or IsDelimiter(ch) Or IsLineBreaker(ch))
            TokenString = TokenString + ch
            ch = GetCharFromStream()
        End While
        UndoChar(ch)
        Return TokenString
    End Function

    Private Function GetCharFromStream() As Char
        If m_UndoChars.Count <> 0 Then Return RedoChar()
        If m_StreamReader.Peek() = -1 Then Return vbNullChar

        Dim tmpCh(0) As Char
        m_StreamReader.ReadBlock(tmpCh, 0, 1)
        Return tmpCh(0)
    End Function

    Private Sub UndoString(ByVal Value As String)
        For i As Integer = Value.Length - 1 To 0 Step -1
            UndoChar(Value.Chars(i))
        Next
    End Sub

    Private Sub UndoChar(ByVal ch As Char)
        m_UndoChars.Push(ch)
    End Sub

    Private Function RedoChar() As Char
        Return CType(m_UndoChars.Pop(), Char)
    End Function

    Public Sub UndoToken(ByVal Token As MicroDVDToken)
        m_UndoTokens.Push(Token)
    End Sub

    Private Function RedoToken() As MicroDVDToken
        Return CType(m_UndoTokens.Pop(), MicroDVDToken)
    End Function

    Public Sub New(ByVal Stream As System.IO.Stream)
        m_StreamReader = New System.IO.StreamReader(Stream, System.Text.Encoding.GetEncoding(0))
        m_UndoChars = New Stack
        m_UndoTokens = New Stack
        m_TextContext = False
    End Sub

    Public Sub Close()
        m_StreamReader.Close()
    End Sub
End Class
