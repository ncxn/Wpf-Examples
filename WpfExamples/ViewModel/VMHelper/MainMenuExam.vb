Imports System.Data

Public Class MainMenuExam
    Inherits MenuItems

    Public Overrides Sub OnItemSelected(Obj As Object)
        MessageBox.Show(Obj.ToString)
    End Sub

    Public Function GenerateMenu() As IEnumerable(Of MainMenuExam)
        Dim dt As DataTable = DBHelper.GetInstance.GetDataTable("procGetAllControlsWithTypeMenu", CommandType.StoredProcedure)
        Dim allItems As IEnumerable(Of MainMenuExam) = (From dr As DataRow In dt.Rows Select New MainMenuExam With {
            .MenuId = dr(0),
            .MenuHeader = dr(1),
            .MenuParentId = dr(2).ToString(),
            .MenuIcon = "FileTree"
            }).ToList()

        Dim roots = allItems.Where(Function(x) String.IsNullOrEmpty(x.MenuParentId))

        For Each item In allItems
            Dim parent = allItems.FirstOrDefault(Function(x) x.MenuId = item.MenuParentId)
            If parent IsNot Nothing Then parent.SubMenu.Add(item)
        Next

        Return roots
    End Function

End Class
