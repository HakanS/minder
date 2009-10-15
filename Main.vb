'
' Minder - a sort of mindmapping 
'
' License    GPL 2 (http://www.gnu.org/licenses/gpl.html)
' Author     Håkan Sandell <hakan.sandell@home.se>
'
Imports System.Diagnostics
Imports System.Threading

Module Main

    Private _mainForm As MainForm
    Private _nodeIcons As ImageList

    Public Sub Main()
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf OnUnhandledException
        AddHandler Application.ThreadException, AddressOf OnThreadException

        ' add debug output to file
        'Debug.Listeners.Add(New System.Diagnostics.TextWriterTraceListener("Minder debug.log"))
        'Debug.AutoFlush = True
        'Debug.WriteLine(vbNewLine)

        Application.EnableVisualStyles()
        Application.DoEvents()  ' to enable correct visual style in toolbar (it's a bug - not a feature!)

        _nodeIcons = New ImageList
        _nodeIcons.Images.AddStrip(New Bitmap(GetType(MainForm), "NodeIcons.bmp"))
        _nodeIcons.TransparentColor = Color.Cyan

        _mainForm = New MainForm
        Application.Run(_mainForm)
    End Sub

    Private Sub OnUnhandledException(ByVal sender As Object, ByVal t As UnhandledExceptionEventArgs)
        ProcessException(DirectCast(t.ExceptionObject, Exception))
    End Sub

    Private Sub OnThreadException(ByVal sender As Object, ByVal t As ThreadExceptionEventArgs)
        ProcessException(t.Exception)
    End Sub

    Private Sub ProcessException(ByVal anException As Exception)
        If TypeOf anException Is ThreadAbortException Then Return

        Debug.WriteLine(HandleError(anException))
    End Sub

    Public Function HandleError(ByVal ex As Exception) As String
        MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return ex.ToString
    End Function

    Friend Function MainFormTextSize(ByVal text As String, ByVal font As Font) As SizeF
        Dim g As Graphics = _mainForm.CreateGraphics
        Dim retval As SizeF = g.MeasureString(text, font)
        g.Dispose()
        Return retval
    End Function

    Friend Function NodeIcons() As ImageList
        Return _nodeIcons
    End Function
End Module
