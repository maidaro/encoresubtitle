Imports System.Collections.Specialized
Imports EncoreSubtitlesCommon

Public Class EncoreDVDProperties
    Private m_FrameRates As Single
    Private m_WordWrap As Boolean
    Private m_MaxLine As Integer
    Private m_ArrangeTiming As Boolean

    Public Sub BindProperties(ByVal Properties As StringDictionary)
        If Properties.ContainsKey(PropertyKeys.VIDEOSYSTEM) = True Then
            m_FrameRates = Properties(PropertyKeys.VIDEOSYSTEM)
        End If
        If Properties.ContainsKey(PropertyKeys.WORDWRAP) = True Then
            m_WordWrap = Properties(PropertyKeys.WORDWRAP)
            If m_WordWrap = True Then
                If Properties.ContainsKey(PropertyKeys.WORDWRAP_MAXLINELENGTH) = True Then
                    m_MaxLine = Properties(PropertyKeys.WORDWRAP_MAXLINELENGTH)
                End If
            End If
        End If
        If Properties.ContainsKey(PropertyKeys.ARRANGETIMING) = True Then
            m_ArrangeTiming = Properties(PropertyKeys.ARRANGETIMING)
        End If
    End Sub

    Public Function BindToStringDictionary() As StringDictionary
        Dim Properties As StringDictionary = New StringDictionary
        Properties.Add(PropertyKeys.VIDEOSYSTEM, m_FrameRates)
        Properties.Add(PropertyKeys.WORDWRAP, m_WordWrap)
        If m_WordWrap = True Then
            Properties.Add(PropertyKeys.WORDWRAP_MAXLINELENGTH, m_MaxLine)
        End If
        Properties.Add(PropertyKeys.ARRANGETIMING, m_ArrangeTiming)
        Return Properties
    End Function

    Public ReadOnly Property FrameRates() As Integer
        Get
            Return m_FrameRates
        End Get
    End Property

    Public Property WordWrap() As Boolean
        Get
            Return m_WordWrap
        End Get
        Set(ByVal Value As Boolean)
            m_WordWrap = Value
        End Set
    End Property

    Public Property MaxLine() As Integer
        Get
            Return m_MaxLine
        End Get
        Set(ByVal Value As Integer)
            m_MaxLine = Value
        End Set
    End Property

    Public Property ArrangeTiming() As Boolean
        Get
            Return m_ArrangeTiming
        End Get
        Set(ByVal Value As Boolean)
            m_ArrangeTiming = Value
        End Set
    End Property

    Public WriteOnly Property VideoSystem() As VideoSystemTypes
        Set(ByVal Value As VideoSystemTypes)
            Select Case Value
                Case VideoSystemTypes.NTSC
                    m_FrameRates = 29.97
                Case VideoSystemTypes.PAL
                    m_FrameRates = 25
            End Select
        End Set
    End Property

    Public Sub New()
        VideoSystem = VideoSystemTypes.NTSC
        m_WordWrap = False
        m_MaxLine = EncoreSubtitlesCommon.DEFAULTMAXLINELENGTH
        m_ArrangeTiming = False
    End Sub
End Class
