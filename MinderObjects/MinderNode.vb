'
' Minder - a sort of mindmapping 
'
' License    GPL 2 (http://www.gnu.org/licenses/gpl.html)
' Author     Håkan Sandell <hakan.sandell@home.se>
'

Public Class MinderNode

    Private Const LineMargin As Integer = 2
    Private Shared ReadOnly CaptionFont As Font = New Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Private Shared ReadOnly SmallFont As Font = New Font(CaptionFont.FontFamily.Name, 7)

    Private _caption As String = ""
    Private _text As String = ""
    Private _icon As Integer
    Private _created As DateTime = DateTime.Now
    Private _modified As DateTime = DateTime.Now
    Private _width As Integer = 60
    Private _level As Integer
    Private _links As New MinderLinkCollection(Me)
    Private _nodes As New MinderNodeCollection(Me)

    Private _linkXpos As Integer
    Private _selectedLink As MinderLink
    Private _height As Integer
    Private _textboxHeight As Integer
    Private _bounds As Rectangle
    Private _touched As Boolean = False
    Private _parent As MinderNode

    Public Sub New()
        _textboxHeight = CInt(2 * MainFormTextSize("X", SmallFont).Height)
        _height = 17 + 2 * LineMargin + _textboxHeight ' + CInt(MainFormTextSize("X", CaptionFont).Height)
    End Sub

    Public Sub New(ByVal caption As String)
        MyClass.New()
        _caption = caption
    End Sub

#Region " property get/set "

    Public Property Caption() As String
        Get
            Return _caption
        End Get
        Set(ByVal value As String)
            _caption = value
            _modified = DateTime.Now
            _touched = True
        End Set
    End Property

    Public Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
            _modified = DateTime.Now
            _touched = True
        End Set
    End Property

    Public Property Icon() As Integer
        Get
            Return _icon
        End Get
        Set(ByVal value As Integer)
            _icon = value
            _modified = DateTime.Now
            _touched = True
        End Set
    End Property

    Public Property Created() As DateTime
        Get
            Return _created
        End Get
        Set(ByVal value As DateTime)
            _created = value
        End Set
    End Property

    Public Property Modified() As DateTime
        Get
            Return _modified
        End Get
        Set(ByVal value As DateTime)
            _modified = value
        End Set
    End Property

    Public ReadOnly Property Height() As Integer
        Get
            Return _height
        End Get
    End Property

    Public Property Width() As Integer
        Get
            Return _width
        End Get
        Set(ByVal value As Integer)
            If value < 16 Then
                value = 16
            End If
            _width = value
            _touched = True
        End Set
    End Property

    Public Property Level() As Integer
        Get
            Return _level
        End Get
        Set(ByVal value As Integer)
            _level = value
            _touched = True
        End Set
    End Property

    Public Property Links() As MinderLinkCollection
        Get
            Return _links
        End Get
        Set(ByVal value As MinderLinkCollection)
            _links = value
        End Set
    End Property

    Friend Property SelectedLink() As MinderLink
        Get
            Return _selectedLink
        End Get
        Set(ByVal value As MinderLink)
            _selectedLink = value
        End Set
    End Property

    Friend Property Parent() As MinderNode
        Get
            Return _parent
        End Get
        Set(ByVal value As MinderNode)
            _parent = value
        End Set
    End Property

    Public Property Nodes() As MinderNodeCollection
        Get
            Return _nodes
        End Get
        Set(ByVal value As MinderNodeCollection)
            _nodes = value
        End Set
    End Property

    Friend ReadOnly Property Bounds() As Rectangle
        Get
            Return _bounds
        End Get
    End Property

#End Region

    Public Function Touched() As Boolean
        Return _touched OrElse _links.Touched OrElse _nodes.Touched
    End Function

    Public Sub ResetTouched()
        _touched = False
        _links.ResetTouched()
        _nodes.ResetTouched()
    End Sub

    Friend Function HitTest(ByVal x As Integer, ByVal y As Integer) As MinderNode
        If _bounds.Contains(x, y) Then

            _selectedLink = Nothing ' now determine if link selected
            If _links.Count <> 0 AndAlso y + _textboxHeight < _bounds.Bottom Then
                Dim index As Integer = (x - _linkXpos) \ 16
                If index >= 0 AndAlso index < _links.Count Then
                    _selectedLink = _links(index)
                End If
            End If

            Return Me
        Else
            Return _nodes.HitTest(x, y)
        End If
    End Function

    Public Sub MaxBounds(ByRef bounds As Size)
        If Me.Bounds.Right > bounds.Width Then bounds.Width = Me.Bounds.Right
        If Me.Bounds.Bottom > bounds.Height Then bounds.Height = Me.Bounds.Bottom

        Me.Nodes.MaxBounds(bounds)
    End Sub

    Friend Sub Draw(ByVal g As Graphics, ByVal x As Integer, ByVal y As Integer)
        Dim baseLinePen As New Pen(Color.Blue, 2)
        g.DrawLine(baseLinePen, x, y, x + Width, y)
        baseLinePen.Dispose()

        Dim currentX As Integer = x
        Dim currentY As Integer = y - LineMargin
        If _icon > 0 Then
            currentX += 2
            If _icon < Minder.NodeIcons.Images.Count Then
                g.DrawImage(Minder.NodeIcons.Images(_icon), currentX, currentY - 16)
            End If
            currentX += 16
        End If

        Dim textRectAdjust As Integer = 0
        If _level <= 0 Then
            currentX += 4
        Else
            textRectAdjust = 6
        End If

        g.DrawString(_caption, CaptionFont, SystemBrushes.WindowText, currentX, currentY, Me.FormatTopRight)
        currentX += CInt(MainFormTextSize(_caption, CaptionFont).Width)

        _linkXpos = currentX
        _links.Draw(g, currentX, currentY)

        Dim textRect As New RectangleF(x + textRectAdjust, y + LineMargin, _width, _textboxHeight)
        Dim format As Drawing.StringFormat = Me.FormatBottomRight

        format.Trimming = StringTrimming.EllipsisCharacter
        g.DrawString(_text, SmallFont, SystemBrushes.ControlDarkDark, textRect, format)

        _bounds = New Rectangle(x, CInt(textRect.Bottom) - _height, _width, _height)
        'g.DrawRectangle(Pens.LightBlue, _bounds)

        _nodes.Draw(g, x + _width, y, True)
    End Sub

    Private Function FormatBottomRight() As System.Drawing.StringFormat
        Dim format As New StringFormat
        format.Alignment = StringAlignment.Near
        format.LineAlignment = StringAlignment.Near
        Return format
    End Function

    Private Function FormatTopRight() As System.Drawing.StringFormat
        Dim format As New StringFormat
        format.Alignment = StringAlignment.Near
        format.LineAlignment = StringAlignment.Far
        Return format
    End Function

    Public Function AddLink(ByVal filepath As String) As MinderLink
        Dim link As New MinderLink(filepath)
        link.Description = IO.Path.GetFileNameWithoutExtension(filepath)
        _links.Add(link)
        Return link
    End Function

    Friend Function ListViewItem() As ListViewItem
        Dim retval As New ListViewItem(New String() {"Node", _caption, _text}, _icon)
        retval.Tag = Me

        If _icon = 0 Then
            retval.ImageIndex = -1
        End If

        Return retval
    End Function

End Class
