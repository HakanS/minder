'
' Minder - a sort of mindmapping 
'
' License    GPL 2 (http://www.gnu.org/licenses/gpl.html)
' Author     Håkan Sandell <hakan.sandell@home.se>
'

' TODO: nodo-node links/refs

Public Class MainForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        AddHandler Application.Idle, AddressOf Application_Idle

        ilsToolBarImages.Images.AddStrip(New Bitmap(GetType(MainForm), "ToolBarImages.bmp"))
    End Sub

    'Form overrides dispose to clean up the component list.
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
    Private WithEvents pnlEditPane As System.Windows.Forms.Panel
    Private WithEvents splEditPane As System.Windows.Forms.Splitter
    Private WithEvents pnlScrollContainer As System.Windows.Forms.Panel
    Private WithEvents pnlCanvas As System.Windows.Forms.Panel
    Private WithEvents lvwNavigator As Minder.Controls.SortedListview
    Private WithEvents tabEditPane As System.Windows.Forms.TabControl
    Private WithEvents tabNavigatorPage As System.Windows.Forms.TabPage
    Private WithEvents tabEditorPage As System.Windows.Forms.TabPage
    Private WithEvents ctlNodeEditor As Minder.NodeEditor
    Private WithEvents mnuMain As System.Windows.Forms.MainMenu
    Private WithEvents mnuFile As System.Windows.Forms.MenuItem
    Private WithEvents mnuFileNew As System.Windows.Forms.MenuItem
    Private WithEvents mnuFileOpen As System.Windows.Forms.MenuItem
    Private WithEvents mnuFileSeparator1 As System.Windows.Forms.MenuItem
    Private WithEvents mnuFileSave As System.Windows.Forms.MenuItem
    Private WithEvents mnuFileSaveAs As System.Windows.Forms.MenuItem
    Private WithEvents mnuFileSeparator2 As System.Windows.Forms.MenuItem
    Private WithEvents mnuFileExit As System.Windows.Forms.MenuItem
    Private WithEvents mnuContextMenu As System.Windows.Forms.ContextMenu
    Private WithEvents mnuContextAddNode As System.Windows.Forms.MenuItem
    Private WithEvents mnuContextAddLink As System.Windows.Forms.MenuItem
    Private WithEvents mnuContextSeparator As System.Windows.Forms.MenuItem
    Private WithEvents mnuFileSeparator3 As System.Windows.Forms.MenuItem
    Private WithEvents ctlMenuExtender As Minder.Extenders.MenuExtender
    Private WithEvents mnuFileMRU As System.Windows.Forms.MenuItem
    Private WithEvents mnuContextCut As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Private WithEvents mnuContextPaste As System.Windows.Forms.MenuItem
    Private WithEvents mnuContextDelete As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Private WithEvents mnuFilePrint As System.Windows.Forms.MenuItem
    Private WithEvents mnuFilePreview As System.Windows.Forms.MenuItem
    Private WithEvents mnuFilePageSetup As System.Windows.Forms.MenuItem
    Private WithEvents dlgPrint As System.Windows.Forms.PrintDialog
    Private WithEvents dlgPrintPreview As System.Windows.Forms.PrintPreviewDialog
    Private WithEvents ctlPrintDocument As System.Drawing.Printing.PrintDocument
    Private WithEvents dlgPageSetup As System.Windows.Forms.PageSetupDialog
    Private WithEvents pnlToolbar As System.Windows.Forms.Panel
    Private WithEvents tlbTools As System.Windows.Forms.ToolBar
    Private WithEvents tbbToolSelect As System.Windows.Forms.ToolBarButton
    Private WithEvents tbbToolMarkup As System.Windows.Forms.ToolBarButton
    Private WithEvents ilsToolBarImages As System.Windows.Forms.ImageList
    Private WithEvents tbbToolIconEdit As System.Windows.Forms.ToolBarButton
    Private WithEvents tlbIconEdit As System.Windows.Forms.ToolBar
    Private WithEvents txtEdit As System.Windows.Forms.TextBox
    Private WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents lvwhCaption As System.Windows.Forms.ColumnHeader
    Private WithEvents lvwhText As System.Windows.Forms.ColumnHeader
    Private WithEvents cboFilter As System.Windows.Forms.ComboBox
    Private WithEvents radFilterNone As System.Windows.Forms.RadioButton
    Private WithEvents lblFilterPrompt As System.Windows.Forms.Label
    Private WithEvents radFilterByStatus As System.Windows.Forms.RadioButton
    Private WithEvents radFilterByLinkFiletype As System.Windows.Forms.RadioButton
    Friend WithEvents mnuFileNewContinue As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainForm))
        Me.pnlEditPane = New System.Windows.Forms.Panel
        Me.tabEditPane = New System.Windows.Forms.TabControl
        Me.tabNavigatorPage = New System.Windows.Forms.TabPage
        Me.lblFilterPrompt = New System.Windows.Forms.Label
        Me.radFilterNone = New System.Windows.Forms.RadioButton
        Me.cboFilter = New System.Windows.Forms.ComboBox
        Me.lvwNavigator = New Minder.Controls.SortedListview
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.lvwhCaption = New System.Windows.Forms.ColumnHeader
        Me.lvwhText = New System.Windows.Forms.ColumnHeader
        Me.radFilterByStatus = New System.Windows.Forms.RadioButton
        Me.radFilterByLinkFiletype = New System.Windows.Forms.RadioButton
        Me.tabEditorPage = New System.Windows.Forms.TabPage
        Me.ctlNodeEditor = New Minder.NodeEditor
        Me.ilsToolBarImages = New System.Windows.Forms.ImageList(Me.components)
        Me.splEditPane = New System.Windows.Forms.Splitter
        Me.pnlScrollContainer = New System.Windows.Forms.Panel
        Me.pnlCanvas = New System.Windows.Forms.Panel
        Me.txtEdit = New System.Windows.Forms.TextBox
        Me.mnuMain = New System.Windows.Forms.MainMenu
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuFileNew = New System.Windows.Forms.MenuItem
        Me.mnuFileOpen = New System.Windows.Forms.MenuItem
        Me.mnuFileSeparator1 = New System.Windows.Forms.MenuItem
        Me.mnuFileSave = New System.Windows.Forms.MenuItem
        Me.mnuFileSaveAs = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.mnuFilePageSetup = New System.Windows.Forms.MenuItem
        Me.mnuFilePrint = New System.Windows.Forms.MenuItem
        Me.mnuFilePreview = New System.Windows.Forms.MenuItem
        Me.mnuFileSeparator2 = New System.Windows.Forms.MenuItem
        Me.mnuFileExit = New System.Windows.Forms.MenuItem
        Me.mnuFileSeparator3 = New System.Windows.Forms.MenuItem
        Me.mnuFileMRU = New System.Windows.Forms.MenuItem
        Me.mnuContextMenu = New System.Windows.Forms.ContextMenu
        Me.mnuContextAddNode = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuContextCut = New System.Windows.Forms.MenuItem
        Me.mnuContextPaste = New System.Windows.Forms.MenuItem
        Me.mnuContextDelete = New System.Windows.Forms.MenuItem
        Me.mnuContextSeparator = New System.Windows.Forms.MenuItem
        Me.mnuContextAddLink = New System.Windows.Forms.MenuItem
        Me.ctlMenuExtender = New Minder.Extenders.MenuExtender
        Me.dlgPrint = New System.Windows.Forms.PrintDialog
        Me.ctlPrintDocument = New System.Drawing.Printing.PrintDocument
        Me.dlgPrintPreview = New System.Windows.Forms.PrintPreviewDialog
        Me.dlgPageSetup = New System.Windows.Forms.PageSetupDialog
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.tlbIconEdit = New System.Windows.Forms.ToolBar
        Me.tlbTools = New System.Windows.Forms.ToolBar
        Me.tbbToolSelect = New System.Windows.Forms.ToolBarButton
        Me.tbbToolIconEdit = New System.Windows.Forms.ToolBarButton
        Me.tbbToolMarkup = New System.Windows.Forms.ToolBarButton
        Me.mnuFileNewContinue = New System.Windows.Forms.MenuItem
        Me.pnlEditPane.SuspendLayout()
        Me.tabEditPane.SuspendLayout()
        Me.tabNavigatorPage.SuspendLayout()
        Me.tabEditorPage.SuspendLayout()
        Me.pnlScrollContainer.SuspendLayout()
        Me.pnlCanvas.SuspendLayout()
        CType(Me.ctlMenuExtender, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlToolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEditPane
        '
        Me.pnlEditPane.BackColor = System.Drawing.SystemColors.Control
        Me.pnlEditPane.Controls.Add(Me.tabEditPane)
        Me.pnlEditPane.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEditPane.Location = New System.Drawing.Point(0, 550)
        Me.pnlEditPane.Name = "pnlEditPane"
        Me.pnlEditPane.Size = New System.Drawing.Size(952, 136)
        Me.pnlEditPane.TabIndex = 0
        '
        'tabEditPane
        '
        Me.tabEditPane.Alignment = System.Windows.Forms.TabAlignment.Right
        Me.tabEditPane.Controls.Add(Me.tabNavigatorPage)
        Me.tabEditPane.Controls.Add(Me.tabEditorPage)
        Me.tabEditPane.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabEditPane.Location = New System.Drawing.Point(0, 0)
        Me.tabEditPane.Multiline = True
        Me.tabEditPane.Name = "tabEditPane"
        Me.tabEditPane.SelectedIndex = 0
        Me.tabEditPane.Size = New System.Drawing.Size(952, 136)
        Me.tabEditPane.TabIndex = 0
        '
        'tabNavigatorPage
        '
        Me.tabNavigatorPage.Controls.Add(Me.lblFilterPrompt)
        Me.tabNavigatorPage.Controls.Add(Me.radFilterNone)
        Me.tabNavigatorPage.Controls.Add(Me.cboFilter)
        Me.tabNavigatorPage.Controls.Add(Me.lvwNavigator)
        Me.tabNavigatorPage.Controls.Add(Me.radFilterByStatus)
        Me.tabNavigatorPage.Controls.Add(Me.radFilterByLinkFiletype)
        Me.tabNavigatorPage.Location = New System.Drawing.Point(4, 4)
        Me.tabNavigatorPage.Name = "tabNavigatorPage"
        Me.tabNavigatorPage.Size = New System.Drawing.Size(924, 128)
        Me.tabNavigatorPage.TabIndex = 0
        Me.tabNavigatorPage.Text = "Navigator"
        '
        'lblFilterPrompt
        '
        Me.lblFilterPrompt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFilterPrompt.BackColor = System.Drawing.Color.Transparent
        Me.lblFilterPrompt.Location = New System.Drawing.Point(8, 106)
        Me.lblFilterPrompt.Name = "lblFilterPrompt"
        Me.lblFilterPrompt.Size = New System.Drawing.Size(48, 23)
        Me.lblFilterPrompt.TabIndex = 3
        Me.lblFilterPrompt.Text = "Filter:"
        Me.lblFilterPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'radFilterNone
        '
        Me.radFilterNone.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.radFilterNone.Checked = True
        Me.radFilterNone.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radFilterNone.Location = New System.Drawing.Point(56, 106)
        Me.radFilterNone.Name = "radFilterNone"
        Me.radFilterNone.TabIndex = 2
        Me.radFilterNone.TabStop = True
        Me.radFilterNone.Text = "None"
        '
        'cboFilter
        '
        Me.cboFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilter.Location = New System.Drawing.Point(392, 106)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Size = New System.Drawing.Size(200, 21)
        Me.cboFilter.TabIndex = 1
        '
        'lvwNavigator
        '
        Me.lvwNavigator.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwNavigator.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.lvwhCaption, Me.lvwhText})
        Me.lvwNavigator.FullRowSelect = True
        Me.lvwNavigator.GridLines = True
        Me.lvwNavigator.Location = New System.Drawing.Point(0, 0)
        Me.lvwNavigator.Name = "lvwNavigator"
        Me.lvwNavigator.Size = New System.Drawing.Size(920, 104)
        Me.lvwNavigator.TabIndex = 0
        Me.lvwNavigator.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Status"
        Me.ColumnHeader1.Width = 62
        '
        'lvwhCaption
        '
        Me.lvwhCaption.Text = "Caption"
        Me.lvwhCaption.Width = 561
        '
        'lvwhText
        '
        Me.lvwhText.Text = "Text"
        '
        'radFilterByStatus
        '
        Me.radFilterByStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.radFilterByStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radFilterByStatus.Location = New System.Drawing.Point(160, 106)
        Me.radFilterByStatus.Name = "radFilterByStatus"
        Me.radFilterByStatus.TabIndex = 2
        Me.radFilterByStatus.Text = "By Status"
        '
        'radFilterByLinkFiletype
        '
        Me.radFilterByLinkFiletype.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.radFilterByLinkFiletype.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.radFilterByLinkFiletype.Location = New System.Drawing.Point(264, 106)
        Me.radFilterByLinkFiletype.Name = "radFilterByLinkFiletype"
        Me.radFilterByLinkFiletype.TabIndex = 2
        Me.radFilterByLinkFiletype.Text = "By Link Filetype"
        '
        'tabEditorPage
        '
        Me.tabEditorPage.Controls.Add(Me.ctlNodeEditor)
        Me.tabEditorPage.Location = New System.Drawing.Point(4, 4)
        Me.tabEditorPage.Name = "tabEditorPage"
        Me.tabEditorPage.Size = New System.Drawing.Size(924, 128)
        Me.tabEditorPage.TabIndex = 1
        Me.tabEditorPage.Text = "Editor"
        '
        'ctlNodeEditor
        '
        Me.ctlNodeEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctlNodeEditor.Location = New System.Drawing.Point(0, 0)
        Me.ctlNodeEditor.Name = "ctlNodeEditor"
        Me.ctlNodeEditor.SelectedNode = Nothing
        Me.ctlNodeEditor.Size = New System.Drawing.Size(924, 128)
        Me.ctlNodeEditor.TabIndex = 0
        '
        'ilsToolBarImages
        '
        Me.ilsToolBarImages.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilsToolBarImages.TransparentColor = System.Drawing.Color.Cyan
        '
        'splEditPane
        '
        Me.splEditPane.BackColor = System.Drawing.SystemColors.Control
        Me.splEditPane.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.splEditPane.Location = New System.Drawing.Point(0, 546)
        Me.splEditPane.Name = "splEditPane"
        Me.splEditPane.Size = New System.Drawing.Size(952, 4)
        Me.splEditPane.TabIndex = 1
        Me.splEditPane.TabStop = False
        '
        'pnlScrollContainer
        '
        Me.pnlScrollContainer.AutoScroll = True
        Me.pnlScrollContainer.Controls.Add(Me.pnlCanvas)
        Me.pnlScrollContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlScrollContainer.Location = New System.Drawing.Point(24, 0)
        Me.pnlScrollContainer.Name = "pnlScrollContainer"
        Me.pnlScrollContainer.Size = New System.Drawing.Size(928, 546)
        Me.pnlScrollContainer.TabIndex = 2
        '
        'pnlCanvas
        '
        Me.pnlCanvas.AllowDrop = True
        Me.pnlCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCanvas.Controls.Add(Me.txtEdit)
        Me.pnlCanvas.Location = New System.Drawing.Point(0, 0)
        Me.pnlCanvas.Name = "pnlCanvas"
        Me.pnlCanvas.Size = New System.Drawing.Size(1000, 504)
        Me.pnlCanvas.TabIndex = 0
        '
        'txtEdit
        '
        Me.txtEdit.Location = New System.Drawing.Point(184, 120)
        Me.txtEdit.Name = "txtEdit"
        Me.txtEdit.TabIndex = 0
        Me.txtEdit.Text = ""
        Me.txtEdit.Visible = False
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFileNew, Me.mnuFileNewContinue, Me.mnuFileOpen, Me.mnuFileSeparator1, Me.mnuFileSave, Me.mnuFileSaveAs, Me.MenuItem1, Me.mnuFilePageSetup, Me.mnuFilePrint, Me.mnuFilePreview, Me.mnuFileSeparator2, Me.mnuFileExit, Me.mnuFileSeparator3, Me.mnuFileMRU})
        Me.mnuFile.Text = "File"
        '
        'mnuFileNew
        '
        Me.mnuFileNew.Index = 0
        Me.mnuFileNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        Me.mnuFileNew.Text = "&New"
        '
        'mnuFileOpen
        '
        Me.mnuFileOpen.Index = 2
        Me.mnuFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.mnuFileOpen.Text = "&Open..."
        '
        'mnuFileSeparator1
        '
        Me.mnuFileSeparator1.Index = 3
        Me.mnuFileSeparator1.Text = "-"
        '
        'mnuFileSave
        '
        Me.mnuFileSave.Index = 4
        Me.mnuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.mnuFileSave.Text = "&Save"
        '
        'mnuFileSaveAs
        '
        Me.mnuFileSaveAs.Index = 5
        Me.mnuFileSaveAs.Text = "Save &As..."
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 6
        Me.MenuItem1.Text = "-"
        '
        'mnuFilePageSetup
        '
        Me.mnuFilePageSetup.Index = 7
        Me.mnuFilePageSetup.Text = "Page Setup..."
        '
        'mnuFilePrint
        '
        Me.mnuFilePrint.Index = 8
        Me.mnuFilePrint.Text = "Print..."
        '
        'mnuFilePreview
        '
        Me.mnuFilePreview.Index = 9
        Me.mnuFilePreview.Text = "Print Preview"
        '
        'mnuFileSeparator2
        '
        Me.mnuFileSeparator2.Index = 10
        Me.mnuFileSeparator2.Text = "-"
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Index = 11
        Me.mnuFileExit.Text = "E&xit"
        '
        'mnuFileSeparator3
        '
        Me.mnuFileSeparator3.Index = 12
        Me.mnuFileSeparator3.Text = "-"
        '
        'mnuFileMRU
        '
        Me.mnuFileMRU.Enabled = False
        Me.mnuFileMRU.Index = 13
        Me.mnuFileMRU.Text = "MRU"
        Me.mnuFileMRU.Visible = False
        '
        'mnuContextMenu
        '
        Me.mnuContextMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuContextAddNode, Me.MenuItem2, Me.mnuContextCut, Me.mnuContextPaste, Me.mnuContextDelete, Me.mnuContextSeparator, Me.mnuContextAddLink})
        '
        'mnuContextAddNode
        '
        Me.mnuContextAddNode.Index = 0
        Me.mnuContextAddNode.Text = "Add Node"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "-"
        '
        'mnuContextCut
        '
        Me.mnuContextCut.Index = 2
        Me.mnuContextCut.Text = "Cut"
        '
        'mnuContextPaste
        '
        Me.mnuContextPaste.Index = 3
        Me.mnuContextPaste.Text = "Paste"
        '
        'mnuContextDelete
        '
        Me.mnuContextDelete.Index = 4
        Me.mnuContextDelete.Text = "Delete"
        '
        'mnuContextSeparator
        '
        Me.mnuContextSeparator.Index = 5
        Me.mnuContextSeparator.Text = "-"
        '
        'mnuContextAddLink
        '
        Me.mnuContextAddLink.Index = 6
        Me.mnuContextAddLink.Text = "Add Link..."
        '
        'ctlMenuExtender
        '
        Me.ctlMenuExtender.MruMenuItem = Me.mnuFileMRU
        Me.ctlMenuExtender.StatusBarText = Nothing
        '
        'dlgPrint
        '
        Me.dlgPrint.AllowPrintToFile = False
        Me.dlgPrint.Document = Me.ctlPrintDocument
        '
        'ctlPrintDocument
        '
        Me.ctlPrintDocument.DocumentName = "Minder Project"
        Me.ctlPrintDocument.OriginAtMargins = True
        '
        'dlgPrintPreview
        '
        Me.dlgPrintPreview.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.dlgPrintPreview.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.dlgPrintPreview.ClientSize = New System.Drawing.Size(400, 300)
        Me.dlgPrintPreview.Document = Me.ctlPrintDocument
        Me.dlgPrintPreview.Enabled = True
        Me.dlgPrintPreview.Icon = CType(resources.GetObject("dlgPrintPreview.Icon"), System.Drawing.Icon)
        Me.dlgPrintPreview.Location = New System.Drawing.Point(499, 17)
        Me.dlgPrintPreview.MinimumSize = New System.Drawing.Size(375, 250)
        Me.dlgPrintPreview.Name = "dlgPrintPreview"
        Me.dlgPrintPreview.TransparencyKey = System.Drawing.Color.Empty
        Me.dlgPrintPreview.Visible = False
        '
        'dlgPageSetup
        '
        Me.dlgPageSetup.Document = Me.ctlPrintDocument
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Control
        Me.pnlToolbar.Controls.Add(Me.tlbIconEdit)
        Me.pnlToolbar.Controls.Add(Me.tlbTools)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(24, 546)
        Me.pnlToolbar.TabIndex = 5
        '
        'tlbIconEdit
        '
        Me.tlbIconEdit.DropDownArrows = True
        Me.tlbIconEdit.Location = New System.Drawing.Point(0, 72)
        Me.tlbIconEdit.Name = "tlbIconEdit"
        Me.tlbIconEdit.ShowToolTips = True
        Me.tlbIconEdit.Size = New System.Drawing.Size(24, 42)
        Me.tlbIconEdit.TabIndex = 4
        Me.tlbIconEdit.Visible = False
        '
        'tlbTools
        '
        Me.tlbTools.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbToolSelect, Me.tbbToolIconEdit, Me.tbbToolMarkup})
        Me.tlbTools.DropDownArrows = True
        Me.tlbTools.ImageList = Me.ilsToolBarImages
        Me.tlbTools.Location = New System.Drawing.Point(0, 0)
        Me.tlbTools.Name = "tlbTools"
        Me.tlbTools.ShowToolTips = True
        Me.tlbTools.Size = New System.Drawing.Size(24, 72)
        Me.tlbTools.TabIndex = 5
        '
        'tbbToolSelect
        '
        Me.tbbToolSelect.ImageIndex = 0
        Me.tbbToolSelect.Pushed = True
        Me.tbbToolSelect.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.tbbToolSelect.ToolTipText = "Select Tool"
        '
        'tbbToolIconEdit
        '
        Me.tbbToolIconEdit.ImageIndex = 1
        Me.tbbToolIconEdit.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.tbbToolIconEdit.ToolTipText = "Icon Edit"
        '
        'tbbToolMarkup
        '
        Me.tbbToolMarkup.ImageIndex = 2
        Me.tbbToolMarkup.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.tbbToolMarkup.ToolTipText = "Markup Pen"
        '
        'mnuFileNewContinue
        '
        Me.mnuFileNewContinue.Index = 1
        Me.mnuFileNewContinue.Text = "Ne&w cont."
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(952, 686)
        Me.Controls.Add(Me.pnlScrollContainer)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.splEditPane)
        Me.Controls.Add(Me.pnlEditPane)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuMain
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Minder"
        Me.pnlEditPane.ResumeLayout(False)
        Me.tabEditPane.ResumeLayout(False)
        Me.tabNavigatorPage.ResumeLayout(False)
        Me.tabEditorPage.ResumeLayout(False)
        Me.pnlScrollContainer.ResumeLayout(False)
        Me.pnlCanvas.ResumeLayout(False)
        CType(Me.ctlMenuExtender, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlToolbar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Enum EditMode
        [Select]
        IconEdit
        Markup
    End Enum

    Private _filePath As String = ""
    Private _projectData As New MinderProject
    Private _editMode As EditMode = EditMode.Select
    Private _lastAutoSave As DateTime = Now
    Private _projectNameRect As Rectangle

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        pnlCanvas.Size = pnlScrollContainer.Size

        ' TODO: persist MRU list

        Dim args() As String = Environment.GetCommandLineArgs
        If args.Length > 1 Then
            OpenProject(args(1))
        Else
            CreateNewProject()
        End If

        tlbIconEdit.ImageList = Minder.NodeIcons
        For itr As Integer = 0 To Minder.NodeIcons.Images.Count - 1
            Dim button As New ToolBarButton
            button.ImageIndex = itr
            button.Tag = itr
            If itr = 0 Then
                button.ToolTipText = "No icon"
            End If
            tlbIconEdit.Buttons.Add(button)
        Next
        lvwNavigator.SmallImageList = Minder.NodeIcons

    End Sub

    Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        SaveAsNeeded()
    End Sub

    Private Sub Application_Idle(ByVal sender As Object, ByVal e As System.EventArgs)
        If _filePath.Length = 0 OrElse Not _projectData.Touched Then Exit Sub

        If _lastAutoSave.AddMinutes(5) < Now Then
            _lastAutoSave = Now
            Dim filename As String = _filePath.Substring(0, _filePath.LastIndexOf("."c)) & ".autosave.mxm"
            _projectData.Save(filename)
        End If
    End Sub

#Region " File Menu "

    Private Sub mnuFile_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile.Popup
        mnuFileSave.Enabled = (_filePath.Length <> 0)
    End Sub

    Private Sub mnuFileNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNew.Click
        SaveAsNeeded()
        CreateNewProject()
        pnlCanvas.Invalidate()
    End Sub

    Private Sub mnuFileNewContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewContinue.Click
        Dim selectedNode As MinderNode = ctlNodeEditor.SelectedNode
        Dim filepath As String = _filePath
        SaveAsNeeded()

        CreateNewProject()
        selectedNode.Parent = Nothing
        selectedNode.AddLink(filepath)
        _projectData.Nodes.RemoveAt(0)
        _projectData.Nodes.Add(selectedNode)
        pnlCanvas.Invalidate()
    End Sub

    Private Sub CreateNewProject()
        _projectData = New MinderProject
        _projectData.Nodes.Add(New MinderNode("Start"))

        Me.Text = "Minder - New Project"
        _filePath = ""
        _projectData.ResetTouched()
        ctlNodeEditor.SetIconDefinitions(_projectData.IconDefinition)
        ctlNodeEditor.SelectedNode = Nothing

        pnlCanvas.Height = pnlScrollContainer.Height - pnlCanvas.Top + 20
        pnlCanvas.Width = pnlScrollContainer.Width - pnlCanvas.Left + 20
        UpdateNavigator()
    End Sub

    Private Sub mnuFileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpen.Click
        SaveAsNeeded()
        Dim dialog As New OpenFileDialog
        With dialog
            .Filter = "Minder project files|*.mxm"

            If .ShowDialog = DialogResult.OK Then
                OpenProject(.FileName)
                pnlCanvas.Invalidate()
            End If
        End With
    End Sub

    Private Sub OpenProject(ByVal filepath As String)
        Try
            _projectData = _projectData.Load(filepath)
            ctlMenuExtender.MruAddFile(filepath)

            Me.Text = "Minder - " & IO.Path.GetFileName(filepath)
            _filePath = filepath
            _projectData.ResetTouched()
            ctlNodeEditor.SetIconDefinitions(_projectData.IconDefinition)
            ctlNodeEditor.SelectedNode = Nothing

            pnlCanvas.Height = _projectData.CanvasHeight
            pnlCanvas.Width = _projectData.CanvasWidth
            UpdateNavigator()

        Catch ex As Exception
            HandleError(ex)
            CreateNewProject()
        End Try
    End Sub

    Private Sub mnuFileSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileSave.Click
        SaveProject()
    End Sub

    Public Sub SaveProject()
        If WarnLaterProjectVersion() Then Return

        If _filePath.Length <> 0 Then
            _projectData.Save(_filePath)
            _projectData.ResetTouched()
        Else
            SaveProjectDialog()
        End If
    End Sub

    Private Sub mnuFileSaveAs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileSaveAs.Click
        SaveProjectDialog()
    End Sub

    Private Function WarnLaterProjectVersion() As Boolean
        If _projectData.FileVersion > MinderProject.CurrentFileVersion Then
            Return MessageBox.Show("Project file contains elements from an later version of Minder that not will be saved. Save anyway?", "Minder", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No
        End If
        Return False
    End Function

    Public Sub SaveProjectDialog()
        If WarnLaterProjectVersion() Then Return

        Dim dialog As New SaveFileDialog
        With dialog
            .Filter = "Minder project files|*.mxm"
            .FileName = _filePath

            If .ShowDialog = DialogResult.OK Then
                _projectData.Save(.FileName)
                _projectData.ResetTouched()
                ctlMenuExtender.MruAddFile(.FileName)
                Me.Text = "Minder - " & IO.Path.GetFileName(.FileName)
            End If
        End With
    End Sub

    Private Sub SaveAsNeeded()
        If _projectData.Touched AndAlso _
           MsgBox("Save changes", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then

            SaveProject()
        End If
    End Sub

    Private Sub mnuFilePageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilePageSetup.Click
        dlgPageSetup.ShowDialog()
    End Sub

    Private Sub mnuFilePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilePrint.Click
        If dlgPrint.ShowDialog = DialogResult.OK Then
            dlgPrint.Document.Print()
        End If
    End Sub

    Private Sub mnuFilePreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilePreview.Click
        With dlgPrintPreview
            If .Document.DefaultPageSettings.Landscape Then
                .Height = CInt(SystemInformation.PrimaryMonitorSize.Height * 0.95)
                .Width = CInt(SystemInformation.PrimaryMonitorSize.Width * 0.95)
                .StartPosition = FormStartPosition.CenterParent
            Else
                .Height = CInt(SystemInformation.PrimaryMonitorSize.Height * 0.95)
                .Width = CInt(.Height * 0.72)
                .StartPosition = FormStartPosition.Manual
            End If
            .ShowDialog()
        End With
    End Sub

    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        Me.Close()
    End Sub

#End Region

#Region " Print support "

    Private _printImage As Image
    Private _printHeight As Integer
    Private _printWidth As Integer
    Private _lastPrintPosition As Point
    Private _printDirection As PrintDirection
    Private _pageNumber As Integer

    Private Enum PrintDirection
        Horizontal
        Vertical
    End Enum

    Private Sub ctlPrintDocument_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles ctlPrintDocument.BeginPrint
        _lastPrintPosition = New Point(0, 0)
        _printDirection = PrintDirection.Horizontal
        _pageNumber = 0
    End Sub

    Private Sub ctlPrintDocument_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles ctlPrintDocument.PrintPage
        Dim g As Graphics = e.Graphics

        _pageNumber += 1

        'Dim destRect As Rectangle = e.MarginBounds
        'Dim sourceRect As New Rectangle(_lastPrintPosition, destRect.Size)

        _projectData.Nodes.Draw(g, 10, 300, False)
        'g.DrawRectangle(Pens.Blue, e.MarginBounds)

        'If _printHeight > sourceRect.Bottom OrElse _printWidth > sourceRect.Right Then
        '    e.HasMorePages = True
        'End If

        'If _printDirection = PrintDirection.Horizontal Then
        '    If sourceRect.Right < _printWidth Then
        '        ' still need to print horizontally
        '        _lastPrintPosition.X += (sourceRect.Width + 1)
        '    Else
        '        _lastPrintPosition.X = 0
        '        _lastPrintPosition.Y += (sourceRect.Height + 1)
        '        _printDirection = PrintDirection.Vertical
        '    End If
        'Else
        '    If sourceRect.Right < _printWidth Then
        '        _printDirection = PrintDirection.Horizontal
        '        _lastPrintPosition.X += (sourceRect.Width + 1)
        '    Else
        '        _lastPrintPosition.Y += (sourceRect.Height + 1)
        '    End If
        'End If

        ' print footer
        Dim textBrush As New SolidBrush(Color.Black)
        Dim textFont As New Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Bold, GraphicsUnit.Point)

        g.DrawString(_projectData.Name, textFont, textBrush, 10, 10)

        Dim footerText As String = _pageNumber.ToString
        Dim footerSize As SizeF = g.MeasureString(footerText, textFont)
        Dim pageBottomCenter As New PointF(CSng(e.PageBounds.Width / 2), CSng(e.MarginBounds.Bottom + ((e.PageBounds.Bottom - e.MarginBounds.Bottom) / 2)))
        Dim footerLocation As New PointF(pageBottomCenter.X - (footerSize.Width / 2), pageBottomCenter.Y - (footerSize.Height / 2))

        g.DrawString(footerText, textFont, textBrush, footerLocation)
        textFont.Dispose()
        textBrush.Dispose()
    End Sub

#End Region

    Private Sub tlbTools_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbTools.ButtonClick
        If e.Button.Equals(tbbToolSelect) Then
            _editMode = EditMode.Select
            tbbToolSelect.Pushed = True
            tbbToolIconEdit.Pushed = False
            tbbToolMarkup.Pushed = False
            tlbIconEdit.Visible = False

        ElseIf e.Button.Equals(tbbToolIconEdit) Then
            _editMode = EditMode.IconEdit
            tbbToolSelect.Pushed = False
            tbbToolIconEdit.Pushed = True
            tbbToolMarkup.Pushed = False
            tlbIconEdit.Visible = True

        ElseIf e.Button.Equals(tbbToolMarkup) Then
            _editMode = EditMode.Markup
            tbbToolSelect.Pushed = False
            tbbToolIconEdit.Pushed = False
            tbbToolMarkup.Pushed = True
            tlbIconEdit.Visible = False
        End If
    End Sub

    Private Sub tlbIconEdit_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbIconEdit.ButtonClick
        If Not ctlNodeEditor.SelectedNode Is Nothing Then
            ctlNodeEditor.SelectedNode.Icon = CInt(e.Button.Tag)
            pnlCanvas.Invalidate()
        End If
    End Sub

    Private Sub ctlMenuExtender_MruClick(ByVal number As Integer, ByVal filename As String) Handles ctlMenuExtender.MruClick
        SaveAsNeeded()
        OpenProject(filename)
        pnlCanvas.Invalidate()
    End Sub

#Region " Context menu "

    Private _clipboardNode As MinderNode

    Private Sub AddToSelectedNode(ByVal newNode As MinderNode)
        Dim parentNodes As MinderNodeCollection
        If ctlNodeEditor.SelectedNode Is Nothing Then
            parentNodes = _projectData.Nodes
        Else
            parentNodes = ctlNodeEditor.SelectedNode.Nodes
        End If

        ' find insert point
        Dim maxLevel As Integer = -999
        For Each node As MinderNode In parentNodes
            If node.Level > maxLevel Then
                maxLevel = node.Level
            End If
        Next
        If maxLevel = -999 Then
            maxLevel = -1
        End If

        ' add node
        newNode.Level = maxLevel + 1
        parentNodes.Add(newNode)
        ctlNodeEditor.SelectedNode = newNode

        ' prepare to edit
        tabEditPane.SelectedTab = tabEditorPage
        ctlNodeEditor.EditFocus()
        pnlCanvas.Invalidate()
    End Sub

    Private Sub RemoveSelectedNode()
        If ctlNodeEditor.SelectedNode.Parent Is Nothing Then
            _projectData.Nodes.Remove(ctlNodeEditor.SelectedNode)
        Else
            ctlNodeEditor.SelectedNode.Parent.Nodes.Remove(ctlNodeEditor.SelectedNode)
        End If
        ctlNodeEditor.SelectedNode = Nothing
        pnlCanvas.Invalidate()
    End Sub

    Private Sub mnuContextAddNode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextAddNode.Click
        AddToSelectedNode(New MinderNode)
    End Sub

    Private Sub mnuContextCut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextCut.Click
        _clipboardNode = ctlNodeEditor.SelectedNode
        RemoveSelectedNode()
    End Sub

    Private Sub mnuContextPaste_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextPaste.Click
        AddToSelectedNode(_clipboardNode)
        _clipboardNode = Nothing
    End Sub

    Private Sub mnuContextDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuContextDelete.Click
        RemoveSelectedNode()
    End Sub

    Private Sub mnuContextAddLink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextAddLink.Click
        tabEditPane.SelectedTab = tabEditorPage
        ctlNodeEditor.AddLink()
    End Sub

#End Region

    Private Sub splEditPane_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles splEditPane.Paint
        Dim p As New Pen(SystemColors.InactiveCaption)
        e.Graphics.DrawLine(p, pnlToolbar.Right, 0, splEditPane.Width, 0)
        p.Dispose()
    End Sub

#Region " Canvas & Scrollcontainer Event Handlers "

    Private Sub pnlScrollContainer_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlScrollContainer.Resize
        If pnlCanvas.Height + pnlCanvas.Top < pnlScrollContainer.Height + 20 Then
            pnlCanvas.Height = pnlScrollContainer.Height - pnlCanvas.Top + 20
        End If
        If pnlCanvas.Width + pnlCanvas.Left < pnlScrollContainer.Width + 20 Then
            pnlCanvas.Width = pnlScrollContainer.Width - pnlCanvas.Left + 20
        End If
    End Sub

    Private Sub pnlCanvas_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCanvas.LocationChanged
        If pnlScrollContainer.Height - pnlCanvas.Top + 40 > pnlCanvas.Height Then
            pnlCanvas.Height = pnlScrollContainer.Height - pnlCanvas.Top + 40
        End If
        If pnlScrollContainer.Width - pnlCanvas.Left + 40 > pnlCanvas.Width Then
            pnlCanvas.Width = pnlScrollContainer.Width - pnlCanvas.Left + 40
        End If
    End Sub

    Private Sub pnlCanvas_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCanvas.Resize
        _projectData.CanvasHeight = pnlCanvas.Height
        _projectData.CanvasWidth = pnlCanvas.Width
    End Sub

    Private Sub MainForm_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseWheel
        pnlCanvas.Top += e.Delta \ 10
        If pnlCanvas.Top > 0 Then
            pnlCanvas.Top = 0
        End If
    End Sub

#End Region

    Private Sub pnlCanvas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlCanvas.Paint
        Dim g As Graphics = e.Graphics

        '
        ' project name
        '
        g.DrawString(_projectData.Name, Font, SystemBrushes.ControlDarkDark, 10, 10)
        _projectNameRect.Size = Size.Round(g.MeasureString(_projectData.Name, Font))
        _projectNameRect.X = 10
        _projectNameRect.Y = 10
        _projectNameRect.Inflate(3, 3)

        If _projectData.Name.Length = 0 Then
            g.DrawRectangle(SystemPens.ControlDark, _projectNameRect)
        End If

        '
        ' nodes
        '
        _projectData.Nodes.Draw(g, 10, 300, False)

        '
        ' currently selected node
        '
        If Not ctlNodeEditor.SelectedNode Is Nothing Then
            g.DrawRectangle(Pens.Coral, ctlNodeEditor.SelectedNode.Bounds)

            'With ctlNodeEditor.SelectedNode.Bounds
            '    Dim p(5) As Point
            '    Dim pp As New Pen(Color.FromArgb(127, 192, 220, 80), 6)
            '    p(0) = New Point((.Left + .Right) \ 2, .Bottom + 13)
            '    p(1) = New Point(.Right, .Bottom)
            '    p(2) = New Point(.Right, .Top)
            '    p(3) = New Point(.Left, .Top)
            '    p(4) = New Point(.Left, .Bottom)
            '    p(5) = New Point(.Right - 5, .Bottom + 13)

            '    g.DrawCurve(pp, p)
            'End With
        End If
    End Sub

#Region " pnlCanvas Mouse Event Handlers "

    Private Enum MouseMode
        None
        ResizeNode
        MoveNode
    End Enum

    Private _mouseDown As Boolean = False
    Private _mouseDownArgs As MouseEventArgs
    Private _mouseMode As MouseMode = MouseMode.None

    Private Sub pnlCanvas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCanvas.MouseDown
        _mouseDown = True
        _mouseDownArgs = e
        ctlNodeEditor.SelectedNode = _projectData.Nodes.HitTest(e.X, e.Y)

        If e.Button = MouseButtons.Right Then
            'Dim d As New BalloonMessage.MessageBalloon(pnlCanvas)
            'd.Text = "Kalle"
            'd.Title = "Kule"
            'd.TitleIcon = TooltipIcon.Info
            'd.Show()
            If ctlNodeEditor.SelectedNode Is Nothing Then
                mnuContextAddLink.Enabled = False
                mnuContextDelete.Enabled = False
            Else
                mnuContextAddLink.Enabled = True
                mnuContextDelete.Enabled = True
            End If
            mnuContextPaste.Enabled = (Not _clipboardNode Is Nothing)

            mnuContextMenu.Show(pnlCanvas, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub pnlCanvas_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCanvas.MouseUp
        _mouseDown = False
        _mouseMode = MouseMode.None

        If _projectNameRect.Contains(e.X, e.Y) Then
            StartEditProjectName()

        ElseIf txtEdit.Visible Then
            EndEditProjectName()
        End If

        pnlCanvas.Invalidate()
    End Sub

    Private Sub pnlCanvas_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCanvas.MouseMove

        Const ResizeGripWidth As Integer = 20
        Dim selectedNode As MinderNode = ctlNodeEditor.SelectedNode

        ' TODO: add balloon tops on links and texts

        If Not selectedNode Is Nothing Then

            Dim moveRect As Rectangle = ctlNodeEditor.SelectedNode.Bounds
            moveRect.Width += ResizeGripWidth \ 2

            If _mouseMode <> MouseMode.None OrElse moveRect.Contains(e.X, e.Y) Then

                moveRect.Width -= ResizeGripWidth
                If _mouseMode = MouseMode.MoveNode OrElse _
                  (_mouseMode = MouseMode.None AndAlso moveRect.Contains(e.X, e.Y)) Then

                    ' move selected node
                    Cursor = Cursors.NoMoveVert
                    If _mouseDown Then
                        ' TODO: change parent width by draging node
                        If e.Y < selectedNode.Bounds.Top Then
                            selectedNode.Level -= 1
                            'Dim newSize As Size
                            '_projectData.Nodes.MaxBounds(newSize)
                            'pnlCanvas.Size = newSize
                            pnlCanvas.Invalidate()

                        ElseIf e.Y > selectedNode.Bounds.Bottom Then
                            selectedNode.Level += 1
                            'Dim newSize As Size
                            '_projectData.Nodes.MaxBounds(newSize)
                            'pnlCanvas.Size = newSize
                            pnlCanvas.Invalidate()
                        End If

                        _mouseMode = MouseMode.MoveNode
                    End If

                Else
                    ' resize selected node
                    Cursor = Cursors.SizeWE

                    If _mouseDown Then
                        ' TODO: bad feel when resizing outside node
                        If (e.X < _mouseDownArgs.X OrElse e.X > _mouseDownArgs.X) Then
                            selectedNode.Width += e.X - _mouseDownArgs.X
                            pnlCanvas.Invalidate()
                        End If

                        _mouseMode = MouseMode.ResizeNode
                        _mouseDownArgs = e
                    End If
                End If

            Else ' outside selected node
                Cursor = Cursors.Default
            End If

        Else ' no selected node
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub pnlCanvas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCanvas.DoubleClick
        If Not ctlNodeEditor.SelectedNode Is Nothing Then
            If Not ctlNodeEditor.SelectedNode.SelectedLink Is Nothing Then
                ' link
                ' TODO: replace thisstupidcheat with real singleappinstancehandler
                If Not ctlNodeEditor.SelectedNode.SelectedLink.Link.EndsWith(".mxm") Then
                    ctlNodeEditor.SelectedNode.SelectedLink.Open()
                Else
                    SaveAsNeeded()
                    OpenProject(ctlNodeEditor.SelectedNode.SelectedLink.Link)
                End If
            Else
                If _mouseDownArgs.X > ctlNodeEditor.SelectedNode.Bounds.Right - 10 Then
                    ' add node
                    AddToSelectedNode(New MinderNode)
                Else

                    ' edit node
                    tabEditPane.SelectedTab = tabEditorPage
                    ctlNodeEditor.EditFocus()
                End If
            End If
        End If
    End Sub
#End Region

#Region " pnlCanvas DragDrop (add file link) "

    Private Sub pnlCanvas_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pnlCanvas.DragOver
        Dim point As Point = Me.PointToClient(New Point(e.X, e.Y))
        Dim hooverNode As MinderNode = _projectData.Nodes.HitTest(point.X, point.Y)

        If Not hooverNode Is Nothing Then
            e.Effect = DragDropEffects.Copy
            If Not hooverNode.Equals(ctlNodeEditor.SelectedNode) Then
                ctlNodeEditor.SelectedNode = hooverNode
                pnlCanvas.Invalidate()
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pnlCanvas_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pnlCanvas.DragDrop
        If Not e.Data.GetDataPresent(DataFormats.FileDrop) Then Return

        Dim point As Point = Me.PointToClient(New Point(e.X, e.Y))
        Dim destinationNode As MinderNode = _projectData.Nodes.HitTest(point.X, point.Y)

        If destinationNode Is Nothing Then
            destinationNode = ctlNodeEditor.SelectedNode
            If destinationNode Is Nothing Then
                ' TODO: handle DragDrop missed..
                Return
            End If
        End If
        ctlNodeEditor.SelectedNode = destinationNode
        tabEditPane.SelectedTab = tabEditorPage
        ctlNodeEditor.DragDropLinks(e)
    End Sub
#End Region

    Private Sub ctlNodeEditor_NodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctlNodeEditor.NodeChanged
        pnlCanvas.Invalidate()
    End Sub

    Private Sub ctlNodeEditor_LinksChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctlNodeEditor.LinksChanged
        pnlCanvas.Invalidate()
        UpdateNavigator()
    End Sub

    Private Sub ctlNodeEditor_EnterPressed(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctlNodeEditor.EnterPressed
        If Not ctlNodeEditor.SelectedNode.Parent Is Nothing Then
            ctlNodeEditor.SelectedNode = ctlNodeEditor.SelectedNode.Parent
            AddToSelectedNode(New MinderNode)
            pnlCanvas.Invalidate()
        End If
    End Sub

#Region " Navigator listview Update & Event Handlers "

    Private Sub UpdateNavigator()
        lvwNavigator.Items.Clear()
        For Each node As MinderNode In _projectData.Nodes
            AddNavigatorNodeItem(node)
        Next
    End Sub

    Private Sub AddNavigatorNodeItem(ByVal node As MinderNode)
        Dim listitem As ListViewItem = node.ListViewItem
        If listitem.ImageIndex > 0 Then
            listitem.Text = _projectData.IconDefinition.Item(listitem.ImageIndex)
        Else
            listitem.Text = " "
        End If

        If Not radFilterByStatus.Checked OrElse listitem.Text.Equals(cboFilter.Text) Then
            lvwNavigator.Items.Add(listitem)
        End If

        AddNavigatorNodeChilds(node)
    End Sub

    Private Sub AddNavigatorNodeChilds(ByVal parent As MinderNode)
        If Not radFilterByStatus.Checked Then

            For Each link As MinderLink In parent.Links
                If Not radFilterByLinkFiletype.Checked OrElse link.Link.EndsWith("doc") Then
                    lvwNavigator.Items.Add(link.ListViewItem)
                End If
            Next
        End If

        For Each node As MinderNode In parent.Nodes
            AddNavigatorNodeItem(node)
        Next
    End Sub

    Private Sub lvwNavigator_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwNavigator.SelectedIndexChanged
        If lvwNavigator.SelectedItems.Count <> 0 Then
            Dim node As MinderNode
            With lvwNavigator.SelectedItems(0)

                If TypeOf .Tag Is MinderLink Then
                    node = DirectCast(.Tag, MinderLink).Parent
                Else
                    node = DirectCast(.Tag, MinderNode)
                End If
            End With
            ctlNodeEditor.SelectedNode = node
        End If
        pnlCanvas.Invalidate()
    End Sub

    Private Sub lvwNavigator_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwNavigator.DoubleClick
        If lvwNavigator.SelectedItems.Count = 0 Then Return

        If TypeOf lvwNavigator.SelectedItems(0).Tag Is MinderLink Then
            ' link
            DirectCast(lvwNavigator.SelectedItems(0).Tag, MinderLink).Open()
        Else
            ' node
            tabEditPane.SelectedTab = tabEditorPage
            ctlNodeEditor.EditFocus()

            Dim visibleCanvas As New Rectangle(-pnlCanvas.Left, -pnlCanvas.Top, pnlScrollContainer.ClientSize.Width, pnlScrollContainer.ClientSize.Height)
            If Not visibleCanvas.Contains(ctlNodeEditor.SelectedNode.Bounds) Then
                ' TODO: move visible
            End If
        End If
    End Sub

    Private Sub radFilterNone_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radFilterNone.CheckedChanged
        cboFilter.Enabled = False
        UpdateNavigator()
    End Sub

    Private Sub radFilterByLinkFiletype_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radFilterByLinkFiletype.CheckedChanged
        With cboFilter
            .Items.Clear()
            .Items.Add("Word document (*.doc)")
            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If
            .Enabled = True
        End With
    End Sub

    Private Sub radFilterByStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radFilterByStatus.CheckedChanged
        With cboFilter
            .Items.Clear()
            For Each item As String In _projectData.IconDefinition
                .Items.Add(item)
            Next
            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If
            .Enabled = True
        End With
    End Sub

    Private Sub cboFilter_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFilter.SelectedValueChanged
        UpdateNavigator()
    End Sub

#End Region

#Region " Edit project name "

    Private Sub txtEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEdit.KeyPress
        If e.KeyChar = Chr(13) Then
            EndEditProjectName()
            e.Handled = True
        End If
    End Sub

    Private Sub StartEditProjectName()
        txtEdit.Bounds = _projectNameRect
        If txtEdit.Width < 60 Then
            txtEdit.Width = 60
        End If
        txtEdit.Text = _projectData.Name
        txtEdit.Visible = True
        txtEdit.Focus()
    End Sub

    Private Sub EndEditProjectName()
        txtEdit.Visible = False
        _projectData.Name = txtEdit.Text
    End Sub

#End Region
End Class
