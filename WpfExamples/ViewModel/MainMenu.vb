Imports System.Data

Public Class MainMenu
    Inherits MenuItems
    Private _ListMainMenu As List(Of MainMenu)
    Public Sub New()
        _ListMainMenu = GetAllMenuItems()
    End Sub

    Public Property ListMainMenu As List(Of MainMenu)
        Get
            Return _ListMainMenu
        End Get
        Set(value As List(Of MainMenu))
            _ListMainMenu = value
        End Set
    End Property

    Public Overrides Sub OnItemSelected(Obj As Object)
        MessageBox.Show(Obj.ToString)
    End Sub

    Private Function GetAllMenuItems() As List(Of MainMenu)
        Dim dt As DataTable = DBHelper.GetInstance.GetDataTable("procGetAllControlsWithTypeMenu", CommandType.StoredProcedure)
        Dim allItems As List(Of MainMenu) = (From dr As DataRow In dt.Rows Select New MainMenu With {
            .MenuId = dr(0),
            .MenuHeader = dr(1),
            .MenuParentId = dr(2).ToString(),
            .MenuIcon = "FileTree"
            }).ToList()

        Return allItems
    End Function
End Class
