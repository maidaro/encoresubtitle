Imports csUnit

<TestFixture(), Ignore("Implementing Sub Type")> _
Public Class TestSamiTokenParser
    Private Shared SamiTestFile As String = "..\..\Samples\LAST EXILE 01.smi"

    <Test()> _
    Sub TestParsingTree()
        Dim SamiParser As New SamiTokenParser(SamiTestFile)

        Assert.True(SamiParser.ExpressRootNode())
        Assert.Equals(2, SamiParser.RootNode.ChildNodes.Count)
        Assert.Equals("BODY", SamiParser.RootNode.ChildNodes.Item(1).Name)
        Assert.Equals("SYNC", SamiParser.RootNode.ChildNodes.Item(1).ChildNodes.Item(0).Name)
        Assert.Equals(1, SamiParser.RootNode.ChildNodes.Item(1).ChildNodes.Item(0).Attributes.Count)
        Assert.Equals(421, SamiParser.RootNode.ChildNodes.Item(1).ChildNodes.Count)
        SamiParser.Close()
    End Sub
End Class
