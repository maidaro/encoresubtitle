Imports EncoreSubtitlesCommon
Imports ImportSubFiles

Class ESTWorkItem
    Private m_SourceFilename As String
    Private m_SourceFullPath As String
    Private m_OutputPath As String
    Private m_Subtitles As ICaptions

    Public Property SourceFullPath() As String
        Get
            Return m_SourceFullPath
        End Get
        Set(ByVal Value As String)
            m_SourceFullPath = Value
            m_OutputPath = FSUtils.ExtractPath(Value)
            m_SourceFilename = FSUtils.ExtractFilename(Value)
        End Set
    End Property

    Public Property SourceFileName() As String
        Get
            Return m_SourceFilename
        End Get
        Set(ByVal Value As String)
            m_SourceFilename = Value
        End Set
    End Property

    Public Property OutputPath() As String
        Get
            Return m_OutputPath
        End Get
        Set(ByVal Value As String)
            m_OutputPath = Value
        End Set
    End Property

    Public Property Captions() As ICaptions
        Get
            If m_Subtitles Is Nothing Then
                Dim SubtitleFile As ISubFile = SubFileLoader.Load(m_SourceFullPath)
                Try
                    m_Subtitles = SubtitleFile.GetSubTitles()
                Catch e As SubFileParsingException
                    Throw e
                Finally
                    SubtitleFile.Dispose()
                End Try
            End If
            Return m_Subtitles
        End Get
        Set(ByVal Value As ICaptions)
            m_Subtitles = Value
        End Set
    End Property
End Class
