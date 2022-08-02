Imports csUnit
Imports EncoreSubtitlesCommon

<TestFixture()> _
Public Class TestWordWrap
    <Test()> _
    Sub TestArrangeTiming()
        Dim WordWrapFilter As New AutoWordWrap
        Dim Captions As New CaptionsImpl
        Dim Caption As CaptionImpl

        Caption = New CaptionImpl
        Caption.CaptionTitle = "�߸��� ��������(�Ϻ� ������ �Ƹ���� Ī��)|�����ڸ�:�ϳ��� ���/��ȭ��pacey77&edwiz@hanmail.net"
        Captions.Append(Caption)
        Caption = New CaptionImpl
        Caption.CaptionTitle = "�߸��䳪������(�Ϻ��������Ƹ����Ī��XYZ"
        Captions.Append(Caption)

        Dim ModifiedSubtitle As ICaptions = WordWrapFilter.ApplyFilter(Captions, Nothing)
        Assert.Equals("�߸��� ��������(�Ϻ� ������ �Ƹ����|Ī��)|�����ڸ�:�ϳ��� ���|/��ȭ��pacey77&edwiz|@hanmail.net", ModifiedSubtitle.Item(0).CaptionTitle)
        Assert.Equals("�߸��䳪������(�Ϻ��������Ƹ����Ī��XYZ", ModifiedSubtitle.Item(1).CaptionTitle)
    End Sub
End Class
