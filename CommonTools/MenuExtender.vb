Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Namespace Extenders

    '    ProvideProperty("ImageIndex", GetType(MenuItem))> _
    <ToolboxBitmap(GetType(MenuExtender)), _
     ProvideProperty("StatusBarHint", GetType(MenuItem))> _
    Public Class MenuExtender
        Inherits Component
        Implements IExtenderProvider
        Implements ISupportInitialize

        ' StatusBar Hint
        Private _statusBarPanel As StatusBarPanel
        Private _statusMessages As New Hashtable
        Private _statusBarText As String
        Private _menuInProgress As Boolean

        ' Menu Appearance
        Private _imageList As ImageList

        ' MRU list
        Public Event MruClick(ByVal number As Integer, ByVal filename As String)
        Private _mruMenu As New MruMenu(AddressOf MruMenu_OnClick)

        ' ContextMenu Helper
        Private _menuCloneConnections As New Hashtable
        Private _cloneMenuConnections As New Hashtable


        '''<summary>
        ''' Definition of the components that will be extended
        '''</summary>
        Public Function CanExtend(ByVal extendee As Object) As Boolean Implements System.ComponentModel.IExtenderProvider.CanExtend
            Return (TypeOf extendee Is MenuItem)
        End Function

#Region " extended properties (StatusBarHint / ImageIndex) "

        '''<summary>
        '''</summary>
        <Description("Menuitem called when toolbar button is clicked."), _
         Category("Menu Extender"), _
         Localizable(True)> _
        Public Sub SetStatusBarHint(ByVal extendee As Component, ByVal text As String)

            Dim menu As MenuItem = DirectCast(extendee, MenuItem)

            If Not _statusMessages.Contains(menu) Then
                _statusMessages.Add(menu, text)
                AddHandler menu.Select, AddressOf Me.Menu_Select
            Else
                _statusMessages(menu) = text
            End If
        End Sub

        '''<summary>
        '''</summary>
        <Description("Menuitem called when toolbar button is clicked."), _
         Category("Menu Extender"), _
         Localizable(True)> _
        Public Function GetStatusBarHint(ByVal component As Component) As String
            If _statusMessages.Contains(component) Then
                Return DirectCast(_statusMessages(component), String)
            Else
                Return Nothing
            End If
        End Function

        Private Function ShouldSerializeStatusBarHint(ByVal component As Component) As Boolean
            Return Not GetStatusBarHint(component) Is Nothing
        End Function

        Private Sub ResetStatusBarHint(ByVal component As Component)
            SetStatusBarHint(component, Nothing)
        End Sub
#End Region

#Region " extender (global) get/set properties "

        '
        ' StatusBar Hint
        '
        <Description("The StatusBar panel that will recieve the help text when menuitem selected."), _
         Category("StatusBar Hint")> _
        Public Property StatusBarPanel() As StatusBarPanel
            Get
                Return _statusBarPanel
            End Get
            Set(ByVal value As StatusBarPanel)
                _statusBarPanel = value
            End Set
        End Property

        Public Function ShouldSerializeStatusBarPanel() As Boolean
            Return Not (_statusBarPanel Is Nothing)
        End Function

        Public Sub ResetStatusBarPanel()
            _statusBarPanel = Nothing
        End Sub

        <Description("The StatusBar panel that will recieve the help text when menuitem selected."), _
         Category("StatusBar Hint"), _
         DefaultValue(""), _
         Localizable(True)> _
        Public Property StatusBarText() As String
            Get
                Return _statusBarText
            End Get
            Set(ByVal value As String)
                _statusBarText = value
                If Not _statusBarPanel Is Nothing AndAlso Not _menuInProgress Then
                    _statusBarPanel.Text = _statusBarText
                End If
            End Set
        End Property

        '
        ' Menu Appearance
        '
        <Description("The ImageList from which the MenuImage will get all of the MenuItem images."), _
         Category("Menu Appearance")> _
        Public Property ImageList() As ImageList
            Get
                Return _imageList
            End Get
            Set(ByVal value As ImageList)
                _imageList = value
            End Set
        End Property

        Public Function ShouldSerializeImageList() As Boolean
            Return Not (_imageList Is Nothing)
        End Function

        Public Sub ResetImageList()
            _imageList = Nothing
        End Sub

        '
        ' MRU list
        '
        <Description(" ."), _
         Category("MRU list")> _
        Public Property MruMenuItem() As MenuItem
            Get
                Return _mruMenu.MenuItem
            End Get
            Set(ByVal value As MenuItem)
                _mruMenu.MenuItem = value
            End Set
        End Property

        Public Function ShouldSerializeMruMenuItem() As Boolean
            Return Not (_mruMenu.MenuItem Is Nothing)
        End Function

        Public Sub ResetMruMenuItem()
            _mruMenu.MenuItem = Nothing
        End Sub

        <Description(" ."), _
         Category("MRU list"), _
         DefaultValue(True)> _
        Public Property MruInLineStyle() As Boolean
            Get
                Return _mruMenu.InLineStyle
            End Get
            Set(ByVal value As Boolean)
                _mruMenu.InLineStyle = value
            End Set
        End Property

        <Description(" ."), _
         Category("MRU list"), _
         DefaultValue(4)> _
        Public Property MruMaxEntries() As Integer
            Get
                Return _mruMenu.MaxEntries
            End Get
            Set(ByVal value As Integer)
                _mruMenu.MaxEntries = value
            End Set
        End Property

        <Description(" ."), _
         Category("MRU list"), _
         DefaultValue(48)> _
        Public Property MaxShortenPathLength() As Integer
            Get
                Return _mruMenu.MaxShortenPathLength
            End Get
            Set(ByVal value As Integer)
                _mruMenu.MaxShortenPathLength = value
            End Set
        End Property
#End Region

#Region " MRU eventhandlers/methods "

        Private Sub MruMenu_OnClick(ByVal number As Integer, ByVal filename As String)
            RaiseEvent MruClick(number, filename)
        End Sub

        Public Sub MruSetFiles(ByVal filenames As Specialized.StringCollection)
            _mruMenu.SetFiles(filenames)
        End Sub

        Public Function MruGetFiles() As Specialized.StringCollection
            Return _mruMenu.GetFiles()
        End Function

        Public Sub MruAddFile(ByVal filename As String)
            _mruMenu.AddFile(filename)
        End Sub

        Public Sub MruAddItem(ByVal path As String, ByVal menuName As String)
            _mruMenu.AddItem(path, menuName)
        End Sub

        Public Sub MruRemoveFile(ByVal number As Integer)
            _mruMenu.RemoveFile(number)
        End Sub

        Public Sub MruRemoveFile(ByVal filename As String)
            _mruMenu.RemoveFile(filename)
        End Sub

        Public Sub MruRemoveAll()
            _mruMenu.RemoveAll()
        End Sub

        Public Sub MruSetFileFirst(ByVal number As Integer)
            _mruMenu.SetFileFirst(number)
        End Sub

#End Region

#Region " StatusBarHint eventhandlers/methods "

        Private Sub Form_MenuStart(ByVal sender As Object, ByVal e As System.EventArgs)
            _menuInProgress = True
        End Sub

        Private Sub Form_MenuComplete(ByVal sender As Object, ByVal e As System.EventArgs)
            _menuInProgress = False

            If _statusBarPanel Is Nothing Then Return
            _statusBarPanel.Text = _statusBarText
        End Sub

        Private Sub Menu_Select(ByVal sender As Object, ByVal e As System.EventArgs)
            If _statusBarPanel Is Nothing Then Return

            If _statusMessages.Contains(sender) Then
                _statusBarPanel.Text = " " & DirectCast(_statusMessages(sender), String)
            End If
        End Sub
#End Region

#Region " ContextMenu Helper methods "

        Public Sub MenuAddToContext(ByVal context As ContextMenu, ByVal menu As MenuItem)
            Dim clone As MenuItem = menu.CloneMenu
            context.MenuItems.Add(clone)
            _menuCloneConnections.Add(menu, clone)
            _cloneMenuConnections.Add(clone, menu)
        End Sub

        Public Sub MenuAddToContext(ByVal context As ContextMenu, ByVal menus() As MenuItem)
            For Each menu As MenuItem In menus
                MenuAddToContext(context, menu)
            Next
        End Sub

        <Browsable(False)> _
        Public Property MenuEnabled(ByVal menu As MenuItem) As Boolean
            Get
                Return menu.Enabled
            End Get
            Set(ByVal value As Boolean)
                menu.Enabled = value

                Dim item As MenuItem = DirectCast(_menuCloneConnections(menu), MenuItem)
                If Not item Is Nothing Then
                    item.Enabled = value
                End If
                item = DirectCast(_cloneMenuConnections(menu), MenuItem)
                If Not item Is Nothing Then
                    item.Enabled = value
                End If
            End Set
        End Property

        <Browsable(False)> _
        Public Property MenuVisible(ByVal menu As MenuItem) As Boolean
            Get
                Return menu.Visible
            End Get
            Set(ByVal value As Boolean)
                menu.Visible = value

                Dim item As MenuItem = DirectCast(_menuCloneConnections(menu), MenuItem)
                If Not item Is Nothing Then
                    item.Visible = value
                End If
                item = DirectCast(_cloneMenuConnections(menu), MenuItem)
                If Not item Is Nothing Then
                    item.Visible = value
                End If
            End Set
        End Property

        <Browsable(False)> _
        Public Property MenuChecked(ByVal menu As MenuItem) As Boolean
            Get
                Return menu.Checked
            End Get
            Set(ByVal value As Boolean)
                menu.Checked = value

                Dim item As MenuItem = DirectCast(_menuCloneConnections(menu), MenuItem)
                If Not item Is Nothing Then
                    item.Checked = value
                End If
                item = DirectCast(_cloneMenuConnections(menu), MenuItem)
                If Not item Is Nothing Then
                    item.Checked = value
                End If
            End Set
        End Property

#End Region

#Region " ISupportInitialize implementation (attach event handlers) "

        Public Sub BeginInit() Implements System.ComponentModel.ISupportInitialize.BeginInit
            ' do nothing
        End Sub

        ' attatch .. handlers to all toolbars
        Public Sub EndInit() Implements System.ComponentModel.ISupportInitialize.EndInit

            If Not _statusBarPanel Is Nothing Then
                Dim parent As Form = DirectCast(_statusBarPanel.Parent.Parent, Form)

                AddHandler parent.MenuStart, New EventHandler(AddressOf Form_MenuStart)
                AddHandler parent.MenuComplete, New EventHandler(AddressOf Form_MenuComplete)
            End If

            _mruMenu.Init()
            'Dim toolbars As New Hashtable

            'For Each obj As Object In _statusMessages.Keys
            '    Dim menu As MenuItem = DirectCast(obj, MenuItem)
            '    Dim toolbar As toolbar = button.Parent

            '    If (Not toolbar Is Nothing) AndAlso (Not toolbars.Contains(toolbar)) Then

            '        AddHandler toolbar.ButtonClick, AddressOf Me.Handle_ToolbarButtonClick
            '        toolbars.Add(toolbar, Nothing)
            '    End If
            'Next
            'toolbars.Clear()
        End Sub
#End Region

    End Class
End Namespace
