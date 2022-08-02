Public Interface ICaption
    Inherits ICloneable

    Property EnterTiming() As Integer
    Property LeaveTiming() As Integer
    Property CaptionTitle() As String
End Interface

Public Interface ICaptions
    Inherits IEnumerable
    Inherits ICloneable

    ReadOnly Property Count() As Integer
    Function Item(ByVal Index As Integer) As ICaption
End Interface
