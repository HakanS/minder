Imports System.IO
Imports System.Windows.Forms

Friend Class MruMenu

#Region " MruMenuItem Class "

    ' The menu may display a shortened or otherwise invalid pathname
    ' This class is used to store the actual filename, preferably as
    ' a fully resolved name.
    Public Class MruMenuItem
        Inherits MenuItem

        Private _filename As String

        Public Sub New()
            _filename = ""
        End Sub

        Public Sub New(ByVal filename As String, ByVal text As String, ByVal onClick As EventHandler)
            MyBase.New(text, onClick)
            _filename = filename
        End Sub

        Public Property Filename() As String
            Get
                Return _filename
            End Get
            Set(ByVal value As String)
                _filename = value
            End Set
        End Property
    End Class
#End Region

    Delegate Sub OnClickHandler(ByVal number As Integer, ByVal filename As String)

    Private _recentFileMenuItem As MenuItem
    Private _topMenuItem As MenuItem
    Private _onClickHandler As OnClickHandler
    Private _inlineStyle As Boolean = True
    Private _entries As Integer = 0
    Private _maxEntries As Integer = 4
    Private _maxShortenPathLength As Integer = 48

    Public Sub New(ByVal onClick As OnClickHandler)
        _onClickHandler = onClick
    End Sub

    Public Sub Init()
        If Not _recentFileMenuItem Is Nothing Then
            _recentFileMenuItem.Checked = False
            _recentFileMenuItem.Enabled = False
            _recentFileMenuItem.Visible = Not _inlineStyle
            _recentFileMenuItem.DefaultItem = False
            _topMenuItem = _recentFileMenuItem
        End If
    End Sub

    Protected Sub OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim menuItem As MruMenuItem = DirectCast(sender, MruMenuItem)

        _onClickHandler(menuItem.Index - StartIndex(), menuItem.Filename)
    End Sub

#Region " get/set properties "

    Public Property MenuItem() As MenuItem
        Get
            Return _recentFileMenuItem
        End Get
        Set(ByVal value As MenuItem)
            If Not value Is Nothing AndAlso value.Parent Is Nothing Then
                Throw New ArgumentException("MenuItem is not part of a menu")
            End If
            _recentFileMenuItem = value
        End Set
    End Property

    Public Property InLineStyle() As Boolean
        Get
            Return _inlineStyle
        End Get
        Set(ByVal value As Boolean)
            _inlineStyle = value
        End Set
    End Property

    Public Property MaxEntries() As Integer
        Get
            Return _maxEntries
        End Get
        Set(ByVal value As Integer)
            If value > 16 Then
                _maxEntries = 16
            Else
                If value < 4 Then
                    _maxEntries = 4
                Else
                    _maxEntries = value
                End If

                Dim index As Integer = StartIndex() + _maxEntries
                While _entries > _maxEntries
                    MenuItems.RemoveAt(index)
                    _entries -= 1
                End While
            End If
        End Set
    End Property

    Public Property MaxShortenPathLength() As Integer
        Get
            Return _maxShortenPathLength
        End Get
        Set(ByVal value As Integer)
            If value < 16 Then
                _maxShortenPathLength = 16
            Else
                _maxShortenPathLength = value
            End If
        End Set
    End Property

#End Region

    Public Sub SetFiles(ByVal filenames As Specialized.StringCollection)
        RemoveAll()
        For itr As Integer = filenames.Count - 1 To 0 Step -1
            AddFile(filenames(itr))
        Next
    End Sub

    Public Function GetFiles() As Specialized.StringCollection
        Dim retval As New Specialized.StringCollection

        For itr As Integer = StartIndex() To EndIndex() - 1
            retval.Add(DirectCast(MenuItems(itr), MruMenuItem).Filename)
        Next
        Return retval
    End Function

    Public Sub AddFile(ByVal filename As String)
        Dim pathname As String = Path.GetFullPath(filename)
        AddItem(pathname, ShortenPathname(pathname, _maxShortenPathLength))
    End Sub

    Public Sub AddItem(ByVal path As String, ByVal menuName As String)
        If path Is Nothing Then
            Throw New ArgumentNullException("filename")
        End If
        If path.Length = 0 Then
            Throw New ArgumentException("filename")
        End If

        ' already in mru list ?
        If _entries > 0 Then
            Dim index As Integer = IndexOf(path)
            If index >= 0 Then
                SetFileFirst(index)
                Return
            End If
        End If

        ' list allowed to grow ?
        If _entries < _maxEntries Then
            Dim menuItem As New MruMenuItem(path, FixupEntryname(0, menuName), New System.EventHandler(AddressOf Me.OnClick))
            MenuItems.Add(StartIndex, menuItem)
            _topMenuItem = menuItem

            _entries += 1
            If _entries = 1 Then
                Enable()
            Else
                UpdatePrefixes(1)
            End If

        ElseIf _entries > 1 Then
            ' change last entry to added item
            Dim menuItem As MruMenuItem = DirectCast(MenuItems((StartIndex() + _entries - 1)), MruMenuItem)
            menuItem.Text = FixupEntryname(0, menuName)
            menuItem.Filename = path
            menuItem.Index = StartIndex()
            _topMenuItem = menuItem
            UpdatePrefixes(1)
        End If
    End Sub

    Public Sub RemoveFile(ByVal number As Integer)
        If number >= 0 AndAlso number < _entries Then
            _entries -= 1
            If _entries = 0 Then
                Disable()
            Else
                Dim _startIndex As Integer = StartIndex()
                If number = 0 Then
                    _topMenuItem = MenuItems(_startIndex + 1)
                End If

                MenuItems.RemoveAt(_startIndex + number)

                If number < _entries Then
                    UpdatePrefixes(number)
                End If
            End If
        End If
    End Sub

    Public Sub RemoveFile(ByVal filename As String)
        If _entries > 0 Then
            RemoveFile(IndexOf(filename))
        End If
    End Sub

    Public Sub RemoveAll()
        If _entries > 0 Then
            For index As Integer = EndIndex() - 1 To StartIndex() + 1 Step -1
                MenuItems.RemoveAt(index)
            Next

            Disable()
            _entries = 0
        End If
    End Sub

    Public Sub SetFileFirst(ByVal number As Integer)
        If number > 0 AndAlso _entries > 1 AndAlso number < _entries Then
            Dim menuItem As menuItem = MenuItems((StartIndex() + number))
            menuItem.Index = StartIndex()
            _topMenuItem = menuItem
            UpdatePrefixes(0)
        End If
    End Sub

#Region " private methods "

    Private Function MenuItems() As Menu.MenuItemCollection
        If _inlineStyle Then
            Return _topMenuItem.Parent.MenuItems
        Else
            Return _recentFileMenuItem.MenuItems
        End If
    End Function

    Private Function StartIndex() As Integer
        If _inlineStyle AndAlso Not _topMenuItem Is Nothing Then
            Return _topMenuItem.Index
        Else
            Return 0
        End If
    End Function

    Private Function EndIndex() As Integer
        If _inlineStyle Then
            Return _topMenuItem.Index + _entries
        Else
            Return _entries
        End If
    End Function

    Private Sub Enable()
        If Not _inlineStyle Then
            _recentFileMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Disable()
        If _inlineStyle Then
            MenuItems.Remove(_topMenuItem)
            _topMenuItem = _recentFileMenuItem
        Else
            _recentFileMenuItem.Enabled = False
            _recentFileMenuItem.MenuItems.RemoveAt(0)
        End If
    End Sub

    Private Function IndexOf(ByVal filename As String) As Integer
        If filename Is Nothing Then
            Throw New ArgumentNullException("filename")
        End If
        If filename.Length = 0 Then
            Throw New ArgumentException("filename")
        End If

        If _entries > 0 Then
            For i As Integer = StartIndex() To EndIndex() - 1
                If String.Compare((CType(MenuItems(i), MruMenuItem)).Filename, filename, True) = 0 Then
                    Return i - StartIndex()
                End If
            Next
        End If
        Return -1
    End Function

    Private Sub UpdatePrefixes(ByVal startNumber As Integer)
        If startNumber < 0 Then
            startNumber = 0
        End If

        If startNumber < _maxEntries Then
            Dim itr As Integer
            For itr = StartIndex() + startNumber To EndIndex() - 1
                Dim menuText As String = MenuItems(itr).Text
                MenuItems(itr).Text = FixupEntryname(startNumber, menuText.Substring(menuText.IndexOf(" "c) + 2))
                startNumber += 1
            Next
        End If
    End Sub

    Private Function FixupEntryname(ByVal number As Integer, ByVal menuName As String) As String
        If number < 9 Then
            Return "&" & (number + 1) & "  " & menuName
        ElseIf number = 9 Then
            Return "1&0" & "  " & menuName
        Else
            Return number + 1 & "  " & menuName
        End If
    End Function

#End Region

    ' Shortens a pathname by either removing consecutive components of a path
    ' and/or by removing characters from the end of the filename and replacing
    ' then with three elipses (...)
    '
    ' In all cases, the root of the passed path will be preserved in it's entirety.
    '
    ' If a UNC path is used or the pathname and maxLength are particularly short,
    ' the resulting path may be longer than maxLength.
    '
    ' This method expects fully resolved pathnames to be passed to it.
    ' (Use Path.GetFullPath() to obtain this.)
    Public Shared Function ShortenPathname(ByVal pathname As String, ByVal maxLength As Integer) As String

        If pathname.Length <= maxLength Then
            Return pathname
        End If

        Dim root As String = Path.GetPathRoot(pathname)
        If root.Length > 3 Then
            root += Path.DirectorySeparatorChar
        End If
        Dim elements As String() = pathname.Substring(root.Length).Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)

        Dim filenameIndex As Integer = elements.GetLength(0) - 1

        If elements.GetLength(0) = 1 Then ' pathname is just a root and filename
            If elements(0).Length > 5 Then ' long enough to shorten
                ' if path is a UNC path, root may be rather long
                If root.Length + 6 >= maxLength Then
                    Return root + elements(0).Substring(0, 3) + "..."
                Else
                    Return pathname.Substring(0, maxLength - 3) + "..."
                End If
            End If

        ElseIf root.Length + 4 + elements(filenameIndex).Length > maxLength Then ' pathname is just a root and filename
            root += "...\"

            Dim len As Integer = elements(filenameIndex).Length
            If len < 6 Then
                Return root + elements(filenameIndex)
            End If
            If root.Length + 6 >= maxLength Then
                len = 3
            Else
                len = maxLength - root.Length - 3
            End If
            Return root + elements(filenameIndex).Substring(0, len) + "..."

        ElseIf elements.GetLength(0) = 2 Then
            Return root + "...\" + elements(1)

        Else
            Dim len As Integer = 0
            Dim begin As Integer = 0
            Dim ends As Integer
            Dim i As Integer

            For i = 0 To filenameIndex ' - 1
                If elements(i).Length > len Then
                    begin = i
                    len = elements(i).Length
                End If
            Next i

            Dim totalLength As Integer = pathname.Length - len + 3
            ends = begin + 1

            While totalLength > maxLength
                If begin > 0 Then
                    begin -= 1
                    totalLength -= elements(begin).Length - 1
                End If
                If totalLength <= maxLength Then
                    Exit While
                End If
                If ends < filenameIndex Then
                    ends += 1
                    totalLength -= elements(ends).Length - 1
                End If
                If begin = 0 AndAlso ends = filenameIndex Then
                    Exit While
                End If
            End While
            ' assemble final string

            For i = 0 To begin - 1
                root += elements(i) + "\"c
            Next i

            root += "...\"

            For i = ends To filenameIndex - 1
                root += elements(i) + "\"c
            Next i

            Return root + elements(filenameIndex)
        End If
        Return pathname
    End Function

End Class
