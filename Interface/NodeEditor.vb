'
' Minder - a sort of mindmapping 
'
' License    GPL 2 (http://www.gnu.org/licenses/gpl.html)
' Author     Håkan Sandell <hakan.sandell@home.se>
'

Public Class NodeEditor
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private WithEvents txtText As System.Windows.Forms.TextBox
    Private WithEvents grpLinks As System.Windows.Forms.GroupBox
    Private WithEvents lvwLinks As Minder.Controls.SortedListview
    Private WithEvents btnAddLink As System.Windows.Forms.Button
    Private WithEvents btnRemoveLink As System.Windows.Forms.Button
    Private WithEvents lblTextPrompt As System.Windows.Forms.Label
    Private WithEvents txtCaption As System.Windows.Forms.TextBox
    Private WithEvents cboIcon As System.Windows.Forms.ComboBox
    Private WithEvents lblCaptionPrompt As System.Windows.Forms.Label
    Private WithEvents lblIconPrompt As System.Windows.Forms.Label
    Private WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Private WithEvents btnEditLink As System.Windows.Forms.Button
    Private WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpLinks = New System.Windows.Forms.GroupBox
        Me.btnEditLink = New System.Windows.Forms.Button
        Me.lvwLinks = New Minder.Controls.SortedListview
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.btnAddLink = New System.Windows.Forms.Button
        Me.btnRemoveLink = New System.Windows.Forms.Button
        Me.lblTextPrompt = New System.Windows.Forms.Label
        Me.txtCaption = New System.Windows.Forms.TextBox
        Me.cboIcon = New System.Windows.Forms.ComboBox
        Me.txtText = New System.Windows.Forms.TextBox
        Me.lblCaptionPrompt = New System.Windows.Forms.Label
        Me.lblIconPrompt = New System.Windows.Forms.Label
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.grpLinks.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpLinks
        '
        Me.grpLinks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpLinks.Controls.Add(Me.btnEditLink)
        Me.grpLinks.Controls.Add(Me.lvwLinks)
        Me.grpLinks.Controls.Add(Me.btnAddLink)
        Me.grpLinks.Controls.Add(Me.btnRemoveLink)
        Me.grpLinks.Location = New System.Drawing.Point(352, 0)
        Me.grpLinks.Name = "grpLinks"
        Me.grpLinks.Size = New System.Drawing.Size(568, 104)
        Me.grpLinks.TabIndex = 6
        Me.grpLinks.TabStop = False
        Me.grpLinks.Text = "Links"
        '
        'btnEditLink
        '
        Me.btnEditLink.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditLink.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnEditLink.Location = New System.Drawing.Point(480, 40)
        Me.btnEditLink.Name = "btnEditLink"
        Me.btnEditLink.TabIndex = 3
        Me.btnEditLink.Text = "Edit..."
        '
        'lvwLinks
        '
        Me.lvwLinks.AllowDrop = True
        Me.lvwLinks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwLinks.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader5, Me.ColumnHeader4})
        Me.lvwLinks.FullRowSelect = True
        Me.lvwLinks.GridLines = True
        Me.lvwLinks.Location = New System.Drawing.Point(8, 17)
        Me.lvwLinks.Name = "lvwLinks"
        Me.lvwLinks.Size = New System.Drawing.Size(464, 79)
        Me.lvwLinks.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvwLinks.TabIndex = 0
        Me.lvwLinks.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Description"
        Me.ColumnHeader5.Width = 215
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Link"
        Me.ColumnHeader4.Width = 228
        '
        'btnAddLink
        '
        Me.btnAddLink.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddLink.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddLink.Location = New System.Drawing.Point(480, 8)
        Me.btnAddLink.Name = "btnAddLink"
        Me.btnAddLink.TabIndex = 1
        Me.btnAddLink.Text = "Add..."
        '
        'btnRemoveLink
        '
        Me.btnRemoveLink.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveLink.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRemoveLink.Location = New System.Drawing.Point(480, 72)
        Me.btnRemoveLink.Name = "btnRemoveLink"
        Me.btnRemoveLink.TabIndex = 2
        Me.btnRemoveLink.Text = "Remove"
        '
        'lblTextPrompt
        '
        Me.lblTextPrompt.Location = New System.Drawing.Point(16, 42)
        Me.lblTextPrompt.Name = "lblTextPrompt"
        Me.lblTextPrompt.Size = New System.Drawing.Size(56, 16)
        Me.lblTextPrompt.TabIndex = 2
        Me.lblTextPrompt.Text = "Text"
        '
        'txtCaption
        '
        Me.txtCaption.Location = New System.Drawing.Point(80, 16)
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.Size = New System.Drawing.Size(264, 20)
        Me.txtCaption.TabIndex = 1
        Me.txtCaption.Text = ""
        '
        'cboIcon
        '
        Me.cboIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIcon.Location = New System.Drawing.Point(80, 76)
        Me.cboIcon.Name = "cboIcon"
        Me.cboIcon.Size = New System.Drawing.Size(264, 21)
        Me.cboIcon.TabIndex = 5
        '
        'txtText
        '
        Me.txtText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtText.Location = New System.Drawing.Point(80, 40)
        Me.txtText.Multiline = True
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(264, 32)
        Me.txtText.TabIndex = 3
        Me.txtText.Text = ""
        '
        'lblCaptionPrompt
        '
        Me.lblCaptionPrompt.Location = New System.Drawing.Point(16, 18)
        Me.lblCaptionPrompt.Name = "lblCaptionPrompt"
        Me.lblCaptionPrompt.Size = New System.Drawing.Size(56, 16)
        Me.lblCaptionPrompt.TabIndex = 0
        Me.lblCaptionPrompt.Text = "Caption"
        '
        'lblIconPrompt
        '
        Me.lblIconPrompt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblIconPrompt.Location = New System.Drawing.Point(16, 78)
        Me.lblIconPrompt.Name = "lblIconPrompt"
        Me.lblIconPrompt.Size = New System.Drawing.Size(56, 16)
        Me.lblIconPrompt.TabIndex = 4
        Me.lblIconPrompt.Text = "Icon"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        Me.ColumnHeader1.Width = 0
        '
        'NodeEditor
        '
        Me.Controls.Add(Me.grpLinks)
        Me.Controls.Add(Me.lblTextPrompt)
        Me.Controls.Add(Me.txtCaption)
        Me.Controls.Add(Me.txtText)
        Me.Controls.Add(Me.lblCaptionPrompt)
        Me.Controls.Add(Me.cboIcon)
        Me.Controls.Add(Me.lblIconPrompt)
        Me.Name = "NodeEditor"
        Me.Size = New System.Drawing.Size(928, 104)
        Me.grpLinks.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Event NodeChanged As EventHandler
    Public Event LinksChanged As EventHandler
    Public Event EnterPressed As EventHandler

    Private _selectedNode As MinderNode
    Private _updateInProgress As Boolean = False

    Public Sub SetIconDefinitions(ByVal defs As Specialized.StringCollection)
        cboIcon.Items.Clear()
        For Each text As String In defs
            cboIcon.Items.Add(text)
        Next
    End Sub

    Public Property SelectedNode() As MinderNode
        Get
            Return _selectedNode
        End Get
        Set(ByVal value As MinderNode)
            _selectedNode = value
            UpdateEditorInterface()
        End Set
    End Property

    Private Sub UpdateEditorInterface()
        _updateInProgress = True

        If _selectedNode Is Nothing Then
            txtCaption.Text = ""
            txtText.Text = ""
            cboIcon.SelectedIndex = -1
            lvwLinks.Items.Clear()
            Me.Enabled = False
        Else
            txtCaption.Text = _selectedNode.Caption
            txtText.Text = _selectedNode.Text
            cboIcon.SelectedIndex = _selectedNode.Icon
            lvwLinks.Items.Clear()
            lvwLinks.Items.AddRange(_selectedNode.Links.ListViewItems)
            Me.Enabled = True
        End If

        _updateInProgress = False
    End Sub

    Public Sub EditFocus()
        txtCaption.Focus()
    End Sub

    Private Sub btnAddLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddLink.Click
        AddLink()
    End Sub

    Public Sub AddLink()
        Dim dialog As New OpenFileDialog
        With dialog
            .Filter = "All files (*.*)|*.*"
            .DereferenceLinks = True
            .Multiselect = True

            If .ShowDialog = DialogResult.OK AndAlso .FileNames.Length > 0 Then

                For Each filename As String In .FileNames
                    Dim link As MinderLink = _selectedNode.AddLink(filename)
                    lvwLinks.Items.Add(link.ListViewItem)
                Next
                RaiseEvent LinksChanged(Me, EventArgs.Empty)
            End If
        End With
    End Sub

    Private Sub btnEditLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditLink.Click

    End Sub

    Private Sub btnRemoveLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveLink.Click
        For Each item As ListViewItem In lvwLinks.SelectedItems
            _selectedNode.Links.Remove(DirectCast(item.Tag, MinderLink))
            lvwLinks.Items.Remove(item)
        Next
        RaiseEvent LinksChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub txtCaption_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCaption.TextChanged
        If _updateInProgress Then Return

        _selectedNode.Caption = txtCaption.Text
        Dim g As Graphics = Me.CreateGraphics
        Dim textsize As SizeF = g.MeasureString(txtCaption.Text, Me.Font)
        If textsize.Width > _selectedNode.Width Then
            _selectedNode.Width = CInt(textsize.Width)
        End If
        RaiseEvent NodeChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub txtCaption_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCaption.KeyPress
        If e.KeyChar = Chr(13) Then
            RaiseEvent EnterPressed(Me, New EventArgs)
            ' txtText.Focus() 
            ' TODO: EnterPressed kanske valbart via option?
        End If
    End Sub

    Private Sub txtText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtText.TextChanged
        If _updateInProgress Then Return
        _selectedNode.Text = txtText.Text
        RaiseEvent NodeChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub cboIcon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIcon.SelectedIndexChanged
        If _updateInProgress Then Return
        _selectedNode.Icon = cboIcon.SelectedIndex
        RaiseEvent NodeChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub lvwLinks_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwLinks.DoubleClick
        If lvwLinks.SelectedItems.Count = 0 Then Return
        DirectCast(lvwLinks.SelectedItems(0).Tag, MinderLink).Open()
    End Sub

    Private Sub lvwLinks_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwLinks.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lvwLinks_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwLinks.DragDrop
        If Not e.Data.GetDataPresent(DataFormats.FileDrop) Then Return
        DragDropLinks(e)
    End Sub

    Public Sub DragDropLinks(ByVal e As System.Windows.Forms.DragEventArgs)
        Dim files As System.Array = DirectCast(e.Data.GetData(DataFormats.FileDrop), System.Array)

        For Each file As Object In files
            Dim link As MinderLink = _selectedNode.AddLink(file.ToString)
            lvwLinks.Items.Add(link.ListViewItem)
        Next
        EditFocus()
        RaiseEvent NodeChanged(Me, EventArgs.Empty)
    End Sub
End Class
