Imports csUnit
Imports System.IO

<TestFixture(), Ignore("Implementing Sub Type")> _
Public Class TestSamiTokenReader
    Private Shared SamiTestFile As String = "..\..\Samples\LAST EXILE 01.smi"

    <Test(), Ignore("This test is not need anymore. This is replaced with TestHeadTagName")> _
    Sub TestFirstToken()
        Dim SamiFileStream As New FileStream(SamiTestFile, FileMode.Open)
        Dim SamiInputStream As New SamiTokenReader(SamiFileStream)

        Assert.Equals(SamiTokenType.Delimiter, SamiInputStream.GetToken().TokenType)
        SamiInputStream.Close()
    End Sub

    <Test()> _
    Sub TestAllProcessing()
        Dim SamiFileStream As New FileStream(SamiTestFile, FileMode.Open)
        Dim SamiInputStream As New SamiTokenReader(SamiFileStream)
        Dim Token As SamiToken

        Try
            Token = SamiInputStream.GetToken()
            While (Token.TokenType <> SamiTokenType.EndOfToken)
                If Token.TokenType = SamiTokenType.Text Then
                    '                    Debug.WriteLine(Token.TokenString)
                End If
                Token = SamiInputStream.GetToken()
            End While
        Catch E As Exception
            Assert.Fail("Exception must not be expected")
        End Try
        SamiInputStream.Close()
    End Sub

    <Test(), Ignore("This test is not need anymore. This is replaced with TestEndTagName")> _
    Sub TestLastToken()
        Dim SamiFileStream As New FileStream(SamiTestFile, FileMode.Open)
        Dim SamiInputStream As New SamiTokenReader(SamiFileStream)
        Dim SamiLastestValidToken As SamiTokenType
        Dim SamiTokenType As SamiTokenType

        SamiTokenType = SamiInputStream.GetToken().TokenType
        SamiLastestValidToken = SamiTokenType
        While (SamiTokenType <> SamiTokenType.EndOfToken)
            SamiLastestValidToken = SamiTokenType
            SamiTokenType = SamiInputStream.GetToken.TokenType
        End While
        Assert.Equals(SamiTokenType.Delimiter, SamiLastestValidToken)
        SamiInputStream.Close()
    End Sub

    <Test()> _
    Sub TestHeadTagName()
        Dim SamiFileStream As New FileStream(SamiTestFile, FileMode.Open)
        Dim SamiInputStream As New SamiTokenReader(SamiFileStream)
        Dim Token As SamiToken

        Assert.Equals(SamiTokenType.Delimiter, SamiInputStream.GetToken().TokenType)
        Token = SamiInputStream.GetToken()
        Assert.Equals(SamiTokenType.Text, Token.TokenType)
        Assert.Equals("SAMI", Token.TokenString)
        Assert.Equals(SamiTokenType.Delimiter, SamiInputStream.GetToken().TokenType)
        SamiInputStream.Close()
    End Sub

    <Test()> _
    Sub TestEndTagName()
        Dim SamiFileStream As New FileStream(SamiTestFile, FileMode.Open)
        Dim SamiInputStream As New SamiTokenReader(SamiFileStream)
        Dim Token As SamiToken

        Token = SamiInputStream.GetToken()
        While (Token.TokenType <> SamiTokenType.EndOfToken)
            Token = SamiInputStream.GetToken()
            If String.Compare(Token.TokenString, "/SAMI", True) = 0 Then
                Assert.Equals(SamiTokenType.Delimiter, SamiInputStream.GetToken().TokenType)
                Assert.Equals(SamiTokenType.EndOfToken, SamiInputStream.GetToken().TokenType)
                SamiInputStream.Close()
                Exit Sub
            End If
        End While
        Assert.Fail("/SAMI(end tag) must exist")
        SamiInputStream.Close()
    End Sub

End Class
