Imports System.Collections.ObjectModel
Imports System.Data


Public Class MenuDTO
    Private _name As String
    Private _Header As String
    Private _Icon As Object
    Private _Parent As String
    Private _Command As ICommand
    Private _role As Boolean
    Public Sub New()

    End Sub

    Public Property Header As String
        Get
            Return _Header
        End Get
        Set(value As String)
            _Header = value
        End Set
    End Property
    Public Property Parent As String
        Get
            Return _Parent
        End Get
        Set(value As String)
            _Parent = value
        End Set
    End Property
    Public Property Command As ICommand
        Get
            Return _Command
        End Get
        Set(value As ICommand)
            _Command = value
        End Set
    End Property

    Public Property Icon As Object
        Get
            Return _Icon
        End Get
        Set(value As Object)
            _Icon = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property Role As Boolean
        Get
            Return _role
        End Get
        Set(value As Boolean)
            _role = value

        End Set
    End Property

    Public Shared Function GetAllMenuItems() As IEnumerable(Of MenuDTO)

        Dim dt As DataTable = DBHelper.GetInstance.GetDataTable("procGetAllControlsWithTypeMenu", CommandType.StoredProcedure)
        Dim allItems As List(Of MenuDTO) = (From dr As DataRow In dt.Rows Select New MenuDTO With {
            .Name = dr(0),
            .Header = dr(1),
            .Parent = dr(2).ToString(),
            .Icon = "FileTree"
            }).ToList()

        Return allItems
    End Function
    Public Sub OnClick(obj As Object)
        MessageBox.Show("Click vào éo nào: " + obj.ToString)
    End Sub

    Public Function CanClick(obj As Object) As Boolean

        Return True

    End Function
End Class
