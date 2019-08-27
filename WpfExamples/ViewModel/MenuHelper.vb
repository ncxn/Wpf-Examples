Public Class MenuHelper
    Private allMenuItems As List(Of MenuItems)

    Public Sub New()
        allMenuItems = New List(Of MenuItems)()
    End Sub

    Public Function GetRootMenuItems() As List(Of MenuItems)
        Dim RootMenuItems As List(Of MenuItems) = allMenuItems.FindAll(Function(x) String.IsNullOrEmpty(x.MenuParentId))
        Return RootMenuItems
    End Function

    Public Sub AddMenuItem(ByVal item As MenuItems, ByVal Optional MenuParent As String = "")
        If MenuParent Is Nothing Or String.IsNullOrEmpty(MenuParent) Then
            allMenuItems.Add(item)
        Else
            Dim parent As MenuItems = allMenuItems.FirstOrDefault(Function(x) x.MenuId = item.MenuParentId)
            If parent IsNot Nothing Then
                parent.AddSubMenu(item)
            End If
            allMenuItems.Add(item)
        End If
    End Sub

    Public Sub RemoveMenuItem(ByVal menuItem As MenuItems)
        For Each item As MenuItems In allMenuItems
            item.RemoveSubMenu(menuItem)
        Next

        If allMenuItems.Contains(menuItem) Then
            allMenuItems.Remove(menuItem)
        End If
    End Sub
End Class
