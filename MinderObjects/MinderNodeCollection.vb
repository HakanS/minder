'
' Minder - a sort of mindmapping 
'
' License    GPL 2 (http://www.gnu.org/licenses/gpl.html)
' Author     Håkan Sandell <hakan.sandell@home.se>
'

Public Class MinderNodeCollection
    Inherits CollectionBase

    Private _touched As Boolean = False
    Private _parent As MinderNode

    Public Sub New(ByVal parent As MinderNode)
        _parent = parent
    End Sub

    Public Shadows Function Add(ByVal node As MinderNode) As Integer
        _touched = True
        node.Parent = _parent
        Return list.Add(node)
    End Function

    Default Public ReadOnly Property Item(ByVal index As Integer) As MinderNode
        Get
            Return DirectCast(InnerList.Item(index), MinderNode)
        End Get
    End Property

    Public Sub Remove(ByVal node As MinderNode)
        For itr As Integer = 0 To Me.Count - 1
            If Me.Item(itr).Equals(node) Then
                RemoveAt(itr)
                Return
            End If
        Next
    End Sub

    Public Function Touched() As Boolean
        For Each node As MinderNode In Me.InnerList
            If node.Touched Then
                Return True
            End If
        Next
        Return _touched
    End Function

    Public Sub ResetTouched()
        _touched = False
        For Each node As MinderNode In Me.InnerList
            node.ResetTouched()
        Next
    End Sub

    Public Function HitTest(ByVal x As Integer, ByVal y As Integer) As MinderNode
        Dim retval As MinderNode = Nothing
        For Each node As MinderNode In Me.InnerList
            retval = node.HitTest(x, y)
            If Not retval Is Nothing Then Exit For
        Next
        Return retval
    End Function

    Public Sub MaxBounds(ByRef bounds As Size)
        For Each node As MinderNode In Me.InnerList
            node.MaxBounds(bounds)
        Next
    End Sub


    Public Sub Draw(ByVal g As Graphics, ByVal x As Integer, ByVal y As Integer, ByVal drawBaseLine As Boolean)

        For Each node As MinderNode In Me.InnerList
            Dim nodeYpos As Integer = CInt(y + (node.Level - 0.5) * node.Height)
            Dim nodeXpos As Integer = x
            If drawBaseLine Then
                nodeXpos += Math.Abs(CInt((node.Level - 0.5) * 12))
                g.DrawLine(Pens.Black, x, y, nodeXpos, nodeYpos)
            End If
            node.Draw(g, nodeXpos, nodeYpos)
        Next
    End Sub

End Class
