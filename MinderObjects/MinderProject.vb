'
' Minder - a sort of mindmapping 
'
' License    GPL 2 (http://www.gnu.org/licenses/gpl.html)
' Author     Håkan Sandell <hakan.sandell@home.se>
'

Public Class MinderProject

    Public Const CurrentFileVersion As Integer = 1
    Public FileVersion As Integer = CurrentFileVersion

    Private _name As String = "New Minder Project"
    Private _iconDefinition As New Specialized.StringCollection
    Private _nodes As New MinderNodeCollection(Nothing)
    Private _touched As Boolean = False
    Private _canvasHeight As Integer = 780
    Private _canvasWidth As Integer = 1024

    Public Sub New()
        _iconDefinition.AddRange(New String() {"<none>", _
                                               "Eureka! ", "Attention: ", "Investigate: ", "Work in progress: ", _
                                               "Critical: ", "Discussion: ", "Branch: ", "Documentation: "})
    End Sub

    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
            _touched = True
        End Set
    End Property

    Public Property IconDefinition() As Specialized.StringCollection
        Get
            Return _iconDefinition
        End Get
        Set(ByVal value As Specialized.StringCollection)
            _iconDefinition = value
            _touched = True
        End Set
    End Property

    Public Property CanvasHeight() As Integer
        Get
            Return _canvasHeight
        End Get
        Set(ByVal value As Integer)
            _canvasHeight = value
            ' TODO: _canvasHeight   _touched = True
        End Set
    End Property

    Public Property CanvasWidth() As Integer
        Get
            Return _canvasWidth
        End Get
        Set(ByVal value As Integer)
            _canvasWidth = value
            ' TODO: _canvasWidth   _touched = True
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

    Public Function Touched() As Boolean
        Return _touched OrElse _nodes.Touched
    End Function

    Public Sub ResetTouched()
        _touched = False
        _nodes.ResetTouched()
    End Sub

    Public Sub Save(ByVal path As String)
        Me.FileVersion = CurrentFileVersion

        Dim outFile As IO.FileStream = IO.File.Create(path)

        Try
            Dim formatter As New Xml.Serialization.XmlSerializer(Me.GetType)
            formatter.Serialize(outFile, Me)

        Catch ex As Exception
            Throw New ApplicationException("Project data could not be written to file " & path, ex)

        Finally
            outFile.Close()
        End Try
    End Sub

    Public Function Load(ByVal path As String) As MinderProject
        Dim inFile As IO.FileStream

        Try
            inFile = IO.File.OpenRead(path)

        Catch ex As Exception
            Throw New ApplicationException("Project data file not found " & path, ex)
        End Try

        Try
            Dim formatter As New Xml.Serialization.XmlSerializer(Me.GetType)
            Dim buffer(CInt(inFile.Length)) As Byte

            inFile.Read(buffer, 0, CInt(inFile.Length))

            Dim stream As New IO.MemoryStream(buffer)
            stream.Position = 0

            Return CType(formatter.Deserialize(stream), MinderProject)

        Catch ex As Exception
            Throw New ApplicationException("Project data could not be read from file " & path, ex)
        Finally
            inFile.Close()
        End Try

    End Function


End Class
