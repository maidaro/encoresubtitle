Imports csUnit
Imports System.IO

<TestFixture()> _
Public Class TestMicroDVDTokenReader
    Private Shared SamiTestFile As String = "..\..\Samples\¡º ªäªÞªÈªÊªÇª·ª³ ¡»Vol.01.sub"

    <Test()> _
    Sub TestAllProcessing()
        Dim FileStream As New FileStream(SamiTestFile, FileMode.Open)
        Dim TokenReader As New MicroDVDTokenReader(FileStream)
        Dim Token As MicroDVDToken

        Try
            Token = TokenReader.GetToken()
            While (Token.TokenType <> MicroDVDTokenType.EndOfToken)
                If Token.TokenType = MicroDVDTokenType.Text Then
                    '                    Debug.WriteLine(Token.TokenString)
                End If
                Token = TokenReader.GetToken()
            End While
        Catch E As Exception
            Assert.Fail("Exception must not be expected")
        End Try
        TokenReader.Close()
    End Sub

    <Test()> _
    Sub TestHeadTagName()
        Dim FileStream As New FileStream(SamiTestFile, FileMode.Open)
        Dim TokenReader As New MicroDVDTokenReader(FileStream)
        Dim Token As MicroDVDToken

        Assert.Equals(MicroDVDTokenType.Delimiter, TokenReader.GetToken().TokenType)
        Token = TokenReader.GetToken()
        Assert.Equals(MicroDVDTokenType.Text, Token.TokenType)
        Assert.Equals("1", Token.TokenString)
        Assert.Equals(MicroDVDTokenType.Delimiter, TokenReader.GetToken().TokenType)
        TokenReader.GetToken()
        TokenReader.Close()
    End Sub

    <Test()> _
    Sub TestFrameRates()
        Dim FileStream As New FileStream(SamiTestFile, FileMode.Open)
        Dim TokenReader As New MicroDVDTokenReader(FileStream)
        Dim Token As MicroDVDToken

        Token = TokenReader.GetToken()
        Token = TokenReader.GetToken()
        Token = TokenReader.GetToken()
        Token = TokenReader.GetToken()
        Token = TokenReader.GetToken()
        Token = TokenReader.GetToken()
        Assert.Equals("29.970", TokenReader.GetToken.TokenString)
        Assert.Equals(MicroDVDTokenType.LineBraker, TokenReader.GetToken.TokenType)
        TokenReader.Close()
    End Sub


End Class
