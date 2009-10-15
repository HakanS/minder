'
' Minder - a sort of mindmapping 
'
' License    GPL 2 (http://www.gnu.org/licenses/gpl.html)
' Author     Håkan Sandell <hakan.sandell@home.se>
'
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Controls

    <ToolboxBitmap(GetType(System.Windows.Forms.ListView))> _
    Public Class SortedListview
        Inherits System.Windows.Forms.ListView

#Region " Component Designer generated code "

        Public Sub New()
            MyBase.New()

            ' This call is required by the Component Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            MyBase.ResizeRedraw = True
        End Sub

        'Control overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Control Designer
        Private components As System.ComponentModel.IContainer

        ' NOTE: The following procedure is required by the Component Designer
        ' It can be modified using the Component Designer.  Do not modify it
        ' using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

#End Region

        Private _sortingColumn As ColumnHeader
        Private _sortOrder As System.Windows.Forms.SortOrder

        Protected Overrides Sub OnPaint(ByVal pe As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(pe)

            'Add your custom paint code here
        End Sub

        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            Const WM_PAINT As Integer = &HF

            ' if the control is in details view mode and columns
            ' have been added, then intercept the WM_PAINT message
            ' and reset the last column width to fill the list view
            Select Case m.Msg
                Case WM_PAINT
                    If DesignMode = False AndAlso Me.View = View.Details AndAlso Me.Columns.Count > 0 Then
                        Me.Columns(Me.Columns.Count - 1).Width = -2
                    End If
            End Select
            MyBase.WndProc(m)
        End Sub

        Protected Overrides Sub OnColumnClick(ByVal e As System.Windows.Forms.ColumnClickEventArgs)
            ' Get the new sorting column.
            Dim new_sorting_column As ColumnHeader = Me.Columns(e.Column)

            If _sortingColumn Is Nothing Then
                ' New column. Sort ascending.
                _sortOrder = SortOrder.Ascending
            Else
                ' See if this is the same column.
                If new_sorting_column.Equals(_sortingColumn) Then

                    ' Same column. Switch the sort order.
                    If _sortOrder = SortOrder.Ascending Then
                        _sortOrder = SortOrder.Descending

                    Else
                        _sortOrder = SortOrder.Ascending
                    End If
                Else
                    ' New column. Sort ascending.
                    _sortOrder = SortOrder.Ascending
                End If

            End If

            ' Display the new sort order.
            _sortingColumn = new_sorting_column

            ' Create a comparer.
            Me.ListViewItemSorter = New ListViewComparer(e.Column, _sortOrder)

            ' Sort.
            Me.Sort()
        End Sub
    End Class

    ' Implements a comparer for ListView columns.
    Class ListViewComparer
        Implements IComparer

        Private _columnNumber As Integer
        Private _sortOrder As SortOrder

        Public Sub New(ByVal column_number As Integer, ByVal sort_order As SortOrder)
            _columnNumber = column_number
            _sortOrder = sort_order
        End Sub

        ' Compare the items in the appropriate column
        ' for objects x and y.
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
            Implements System.Collections.IComparer.Compare

            Dim item_x As ListViewItem = DirectCast(x, ListViewItem)
            Dim item_y As ListViewItem = DirectCast(y, ListViewItem)

            ' Get the sub-item values.
            Dim string_x As String
            If item_x.SubItems.Count <= _columnNumber Then
                string_x = ""
            Else
                string_x = item_x.SubItems(_columnNumber).Text
            End If

            Dim string_y As String
            If item_y.SubItems.Count <= _columnNumber Then
                string_y = ""
            Else
                string_y = item_y.SubItems(_columnNumber).Text
            End If

            ' Compare them.
            If _sortOrder = SortOrder.Ascending Then
                Return String.Compare(string_x, string_y)
            Else
                Return String.Compare(string_y, string_x)
            End If
        End Function
    End Class

End Namespace
