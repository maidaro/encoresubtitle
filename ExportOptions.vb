Imports System.Collections.Specialized
Imports EncoreSubtitlesCommon

Class ExportOptions
    Private _bArrangeTiming As Boolean
    Private _bWordWrap As Boolean
    Private _lLineLength As Integer
    Private _bDelLineBreaker As Boolean
    Private _VideoSystem As VideoSystemTypes

    Public Property ArrangeTiming() As Boolean
        Get
            Return _bArrangeTiming
        End Get
        Set(ByVal Value As Boolean)
            _bArrangeTiming = Value
        End Set
    End Property

    Public Property WordWrap() As Boolean
        Get
            Return _bWordWrap
        End Get
        Set(ByVal Value As Boolean)
            _bWordWrap = Value
        End Set
    End Property

    Public Property LineLength() As Integer
        Get
            Return _lLineLength
        End Get
        Set(ByVal Value As Integer)
            _lLineLength = Value
        End Set
    End Property

    Public Property DelLineBreaker() As Integer
        Get
            Return _bDelLineBreaker
        End Get
        Set(ByVal Value As Integer)
            _bDelLineBreaker = Value
        End Set
    End Property


    Public Property VideoSystem() As VideoSystemTypes
        Get
            Return _VideoSystem
        End Get
        Set(ByVal Value As VideoSystemTypes)
            _VideoSystem = Value
        End Set
    End Property

    Public Sub New()
        _bArrangeTiming = True
        _bWordWrap = True
        _bDelLineBreaker = True
        _lLineLength = PropertyDefaults.DEFAULTMAXLINELENGTH
        _VideoSystem = VideoSystemTypes.NTSC
    End Sub

    Public Function ShowUI() As System.Windows.Forms.DialogResult
        Dim UI As New ExportOptionsUI(Me)

        Return UI.ShowDialog()
    End Function

    Public Function BindToStringDictionary() As StringDictionary
        Dim Properties As StringDictionary = New StringDictionary
        Select Case _VideoSystem
            Case VideoSystemTypes.NTSC
                Properties.Add(PropertyKeys.VIDEOSYSTEM, 29.97)
            Case VideoSystemTypes.PAL
                Properties.Add(PropertyKeys.VIDEOSYSTEM, 25)
        End Select
        Properties.Add(PropertyKeys.ARRANGETIMING, _bArrangeTiming)
        Properties.Add(PropertyKeys.WORDWRAP, _bWordWrap)
        Properties.Add(PropertyKeys.WORDWRAP_MAXLINELENGTH, _lLineLength)
        Properties.Add(PropertyKeys.WORDWRAP_DELLINEBREAKER, _bDelLineBreaker)
        Return Properties
    End Function
End Class
