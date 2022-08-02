Imports System.io

Class SamiTokenParser
    Private m_SamiTokenReader As SamiTokenReader
    Private m_ParsingState As ParsingResult
    Private m_RootNode As ISamiElement

    Public ReadOnly Property State() As ParsingResult
        Get
            Return m_ParsingState
        End Get
    End Property

    Private Function GetToken() As SamiToken
        Dim Token As SamiToken = m_SamiTokenReader.GetToken()
        While Token.TokenType = SamiTokenType.Remark
            Token = m_SamiTokenReader.GetToken()
        End While
        Return Token
    End Function

    Private Sub ExpressText(ByVal ParentElement As ISamiElement)
        Dim Token As SamiToken
        Token = GetToken()
        m_SamiTokenReader.TextContext = False
        If Token.TokenType = SamiTokenType.EndOfToken Then
            m_ParsingState.ParsingState = ParsingState.EndOfToken
            Exit Sub
        End If
        If Token.TokenType <> SamiTokenType.Text Then
            m_SamiTokenReader.UndoToken(Token)
            m_ParsingState.ParsingState = ParsingState.NotExpected
            Exit Sub
        End If
        ParentElement.ChildNodes.AddItem(New SamiTextElement(Token.TokenString))
        Debug.WriteLine(Token.TokenString)
        m_ParsingState.ParsingState = ParsingState.ParsingOK
    End Sub

    Private Function IsAssignOperator(ByVal Token As SamiToken) As Boolean
        If Token.TokenType <> SamiTokenType.Operator Then Return False
        If Token.TokenString.Length <> 1 Then Return False
        If Token.TokenString.Chars(0) <> "=" Then Return False
        Return True
    End Function

    Private Sub ExpressAttribute(ByVal ParentElement As ISamiElement)
        Dim Token As SamiToken
        Token = GetToken()
        If Token.TokenType = SamiTokenType.EndOfToken Then
            m_ParsingState.ParsingState = ParsingState.EndOfToken
            Exit Sub
        End If
        If Token.TokenType <> SamiTokenType.Text Then
            m_SamiTokenReader.UndoToken(Token)
            m_ParsingState.ParsingState = ParsingState.NotExpected
            Exit Sub
        End If
        Dim AttributeName As String = Token.TokenString
        If IsAssignOperator(GetToken()) = False Then
            m_ParsingState.ParsingErrorMsg = "Missing = operator at [" & AttributeName & "]"
            m_ParsingState.ParsingState = ParsingState.InvalidStructure
            Exit Sub
        End If
        Token = GetToken()
        If Token.TokenType <> SamiTokenType.Text Then
            m_ParsingState.ParsingErrorMsg = "Missing Value at [" & AttributeName & "]"
            m_ParsingState.ParsingState = ParsingState.InvalidStructure
            Exit Sub
        End If
        Dim AttributeValue As String = Token.TokenString
        ParentElement.Attributes.AddItem(New SamiAttribute(AttributeName, AttributeValue))
        m_ParsingState.ParsingState = ParsingState.ParsingOK
    End Sub

    Private Function IsEnterNodeTag(ByVal Token As SamiToken) As Boolean
        If Token.TokenType <> SamiTokenType.Delimiter Then Return False
        If Token.TokenString.Length <> 1 Then Return False
        If Token.TokenString.Chars(0) <> "<" Then Return False
        Return True
    End Function

    Private Function IsLeaveNodeTag(ByVal Token As SamiToken) As Boolean
        If Token.TokenType <> SamiTokenType.Delimiter Then Return False
        If Token.TokenString.Length <> 1 Then Return False
        If Token.TokenString.Chars(0) <> ">" Then Return False
        Return True
    End Function

    Private Function ExpressNodeTag() As ISamiElement
        Dim Token As SamiToken

        m_SamiTokenReader.TextContext = False
        Token = GetToken()
        If Token.TokenType = SamiTokenType.EndOfToken Then
            m_ParsingState.ParsingState = ParsingState.EndOfToken
            Exit Function
        End If
        If IsEnterNodeTag(Token) = False Then
            m_ParsingState.ParsingState = ParsingState.NotExpected
            m_SamiTokenReader.UndoToken(Token)
            Exit Function
        End If
        Token = GetToken()
        If Token.TokenType <> SamiTokenType.Text Then
            m_ParsingState.ParsingErrorMsg = "Missing Tag-name"
            m_ParsingState.ParsingState = ParsingState.InvalidStructure
            Exit Function
        End If
        Dim NodeName As String = Token.TokenString
        Dim NewNodeElement As ISamiElement = New SamiNodeElement(NodeName)
        m_ParsingState.ParsingState = ParsingState.ParsingOK
        While m_ParsingState.ParsingState = ParsingState.ParsingOK
            ExpressAttribute(NewNodeElement)
        End While
        Token = GetToken()
        If IsLeaveNodeTag(Token) = False Then
            m_ParsingState.ParsingErrorMsg = "Missing > at [" & NodeName & "]"
            m_ParsingState.ParsingState = ParsingState.InvalidStructure
            Exit Function
        End If
        m_ParsingState.ParsingState = ParsingState.ParsingOK
        Return NewNodeElement
    End Function

    Private Function IsInvalidParsingResult() As Boolean
        Return m_ParsingState.ParsingState <> ParsingState.ParsingOK And m_ParsingState.ParsingState <> ParsingState.NotExpected
    End Function

    Private Function IsParsingStateOK() As Boolean
        Return m_ParsingState.ParsingState = ParsingState.ParsingOK
    End Function

    Private Function ExpressTitleNode(ByVal NodeElement As ISamiElement) As Boolean
        If String.Compare(NodeElement.Name, "TITLE", True) <> 0 Then
            m_ParsingState.ParsingState = ParsingState.NotExpected
            Return False
        End If
        m_SamiTokenReader.TextContext = True
        ExpressText(NodeElement)
        If IsInvalidParsingResult() = True Then Return False
        Dim TitleTerminalNode As ISamiElement = ExpressNodeTag()
        If IsParsingStateOK() = False Then Return False
        If String.Compare(TitleTerminalNode.Name, "/TITLE", True) <> 0 Then
            m_ParsingState.ParsingState = ParsingState.InvalidStructure
            m_ParsingState.ParsingErrorMsg = "Missing /TITLE terminal"
            Return False
        End If
        Return True
    End Function

    Private Function ExpressStyleNode(ByVal NodeElement As ISamiElement) As Boolean
        If String.Compare(NodeElement.Name, "STYLE", True) <> 0 Then
            m_ParsingState.ParsingState = ParsingState.NotExpected
            Return False
        End If
        Dim StyleTerminalNode As ISamiElement = ExpressNodeTag()
        If IsParsingStateOK() = False Then Return False
        If String.Compare(StyleTerminalNode.Name, "/STYLE", True) <> 0 Then
            m_ParsingState.ParsingState = ParsingState.InvalidStructure
            m_ParsingState.ParsingErrorMsg = "Missing /STYLE terminal"
            Return False
        End If
        Return True
    End Function

    Private Function ExpressHeadNode(ByVal NodeElement As ISamiElement) As Boolean
        Dim HeadNode As ISamiElement = ExpressNodeTag()
        If IsParsingStateOK() = False Then Return False
        If String.Compare(HeadNode.Name, "HEAD", True) <> 0 Then
            m_ParsingState.ParsingState = ParsingState.InvalidStructure
            m_ParsingState.ParsingErrorMsg = "Missing HEAD tag"
            Return False
        End If
        Dim NestedNode As ISamiElement = ExpressNodeTag()
        While NestedNode.Name <> "/HEAD"
            If ExpressTitleNode(NestedNode) = True Then
                HeadNode.ChildNodes.AddItem(NestedNode)
            ElseIf IsInvalidParsingResult() = True Then
                Return False
            End If
            If ExpressStyleNode(NestedNode) = True Then
                HeadNode.ChildNodes.AddItem(NestedNode)
            ElseIf IsInvalidParsingResult() = True Then
                Return False
            End If
            NestedNode = ExpressNodeTag()
        End While
        NodeElement.ChildNodes.AddItem(HeadNode)
        Return True
    End Function

    Private Function ExpressNestedSyncNode(ByVal BodyNode As ISamiElement, ByVal PrevSyncNode As ISamiElement) As Boolean
        Dim IsParagraph As Boolean = False

        Dim Node As ISamiElement = PrevSyncNode
        While True
            Node = ExpressNodeTag()
            If IsInvalidParsingResult() = True Then Return False
            If Not (Node Is Nothing) Then
                If String.Compare(Node.Name, "/BODY", True) = 0 Then
                    Return True
                ElseIf String.Compare(Node.Name, "SYNC", True) = 0 Then
                    IsParagraph = False
                    PrevSyncNode = Node
                    BodyNode.ChildNodes.AddItem(PrevSyncNode)
                ElseIf String.Compare(Node.Name, "P", True) = 0 Then
                    IsParagraph = True
                ElseIf String.Compare(Node.Name, "/P", True) = 0 Then
                    IsParagraph = False
                Else
                    PrevSyncNode.ChildNodes.AddItem(Node)
                End If
            End If
            If IsParagraph = True Then
                m_SamiTokenReader.TextContext = True
            Else
                m_SamiTokenReader.TextContext = False
            End If
            ExpressText(PrevSyncNode)
            If IsInvalidParsingResult() = True Then Return False
        End While
    End Function

    Private Function ExpressSyncNode(ByVal NodeElement As ISamiElement) As Boolean
        Dim SyncNode As ISamiElement = ExpressNodeTag()
        If IsParsingStateOK() = False Then Return False
        If String.Compare(SyncNode.Name, "SYNC", True) <> 0 Then
            m_ParsingState.ParsingState = ParsingState.InvalidStructure
            m_ParsingState.ParsingErrorMsg = "Missing SYNC tag"
            Return False
        End If
        NodeElement.ChildNodes.AddItem(SyncNode)
        If ExpressNestedSyncNode(NodeElement, SyncNode) = False Then
            m_ParsingState.ParsingState = ParsingState.InvalidStructure
            m_ParsingState.ParsingErrorMsg = "Missing /BODY terminal"
            Return False
        End If
        Return True
    End Function

    Private Function ExpressBodyNode(ByVal NodeElement As ISamiElement) As Boolean
        Dim BodyNode As ISamiElement = ExpressNodeTag()
        If IsParsingStateOK() = False Then Return False
        If String.Compare(BodyNode.Name, "BODY", True) <> 0 Then
            m_ParsingState.ParsingState = ParsingState.InvalidStructure
            m_ParsingState.ParsingErrorMsg = "Missing BODY tag"
            Return False
        End If
        If ExpressSyncNode(BodyNode) = False Then Return False
        NodeElement.ChildNodes.AddItem(BodyNode)
        Return True
    End Function

    Public Function ExpressRootNode() As Boolean
        Dim RootNode As ISamiElement = ExpressNodeTag()
        If IsParsingStateOK() = False Then Return False
        If String.Compare(RootNode.Name, "SAMI", True) <> 0 Then
            m_ParsingState.ParsingState = ParsingState.InvalidStructure
            m_ParsingState.ParsingErrorMsg = "Missing SAMI tag"
            Return False
        End If
        If ExpressHeadNode(RootNode) = False Then Return False
        If ExpressBodyNode(RootNode) = False Then Return False
        Dim RootTerminalNode As ISamiElement = ExpressNodeTag()
        If IsParsingStateOK() = False Then Return False
        If String.Compare(RootTerminalNode.Name, "/SAMI", True) <> 0 Then
            m_ParsingState.ParsingState = ParsingState.InvalidStructure
            m_ParsingState.ParsingErrorMsg = "Missing /SAMI terminal"
            Return False
        End If
        m_RootNode = RootNode
        Return True
    End Function

    Public ReadOnly Property RootNode() As ISamiElement
        Get
            Return m_RootNode
        End Get
    End Property

    Public Sub New(ByVal Filename As String)
        m_SamiTokenReader = New SamiTokenReader(New FileStream(Filename, FileMode.Open))
        m_ParsingState = New ParsingResult
    End Sub

    Public Sub Close()
        m_SamiTokenReader.Close()
    End Sub
End Class
