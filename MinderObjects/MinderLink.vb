'
' Minder - a sort of mindmapping 
'
' License    GPL 2 (http://www.gnu.org/licenses/gpl.html)
' Author     Håkan Sandell <hakan.sandell@home.se>
'

Public Class MinderLink

    Private _link As String
    Private _description As String
    Private _created As DateTime = DateTime.Now
    Private _touched As Boolean = False
    Private _parent As MinderNode

    Public Sub New()
    End Sub

    Public Sub New(ByVal link As String)
        _link = link
    End Sub

    Public Property Link() As String
        Get
            Return _link
        End Get
        Set(ByVal value As String)
            _link = value
            _touched = True
        End Set
    End Property

    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
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

    Friend Property Parent() As MinderNode
        Get
            Return _parent
        End Get
        Set(ByVal value As MinderNode)
            _parent = value
        End Set
    End Property

    Public Function Touched() As Boolean
        Return _touched
    End Function

    Public Sub ResetTouched()
        _touched = False
    End Sub

    Friend Sub Draw(ByVal g As Graphics, ByVal x As Integer, ByVal y As Integer, ByVal selected As Boolean)
        ' TODO: find link icon ?
        If selected Then
            g.FillRectangle(Brushes.Blue, x, y - 16, 16, 16)
        End If
        g.DrawImage(New Icon(GetType(MainForm), "NOTE03.ICO").ToBitmap, x, y - 16, 16, 16)
    End Sub

    Friend Sub Open()
        Try
            Process.Start(_link)

        Catch ex As System.ComponentModel.Win32Exception
            MsgBox("Broken link." & vbNewLine & "   " & _link & vbNewLine & vbNewLine & _
                   "Link description: " & _description, MsgBoxStyle.Critical)
        End Try
    End Sub

    Friend Function ListViewItem() As ListViewItem
        Dim retval As New ListViewItem(New String() {"Link", _description, _link})
        retval.Tag = Me
        Return retval
    End Function
End Class



Public Class MinderLinkCollection
    Inherits CollectionBase

    Private _touched As Boolean = False
    Private _parent As MinderNode

    Public Sub New(ByVal parent As MinderNode)
        _parent = parent
    End Sub

    Public Shadows Function Add(ByVal link As MinderLink) As Integer
        _touched = True
        _parent.Modified = DateTime.Now
        link.Parent = _parent
        Return list.Add(link)
    End Function

    Default Public ReadOnly Property Item(ByVal index As Integer) As MinderLink
        Get
            Return DirectCast(InnerList.Item(index), MinderLink)
        End Get
    End Property

    Public Sub Remove(ByVal link As MinderLink)
        For itr As Integer = 0 To Me.Count - 1
            If Me.Item(itr).Equals(link) Then
                RemoveAt(itr)
                Return
            End If
        Next
    End Sub

    Public Function Touched() As Boolean
        For Each link As MinderLink In Me.InnerList
            If link.Touched Then
                Return True
            End If
        Next
        Return _touched
    End Function

    Public Sub ResetTouched()
        _touched = False
        For Each link As MinderLink In Me.InnerList
            link.ResetTouched()
        Next
    End Sub

    Friend Sub Draw(ByVal g As Graphics, ByVal x As Integer, ByVal y As Integer)
        For Each link As MinderLink In Me.InnerList
            link.Draw(g, x, y, link.Equals(_parent.SelectedLink))
            x += 16
        Next
    End Sub

    Friend Function ListViewItems() As ListViewItem()
        Dim items As New ArrayList
        For Each link As MinderLink In Me.InnerList
            items.Add(link.ListViewItem())
        Next
        Return DirectCast(items.ToArray(GetType(ListViewItem)), ListViewItem())
    End Function

End Class
