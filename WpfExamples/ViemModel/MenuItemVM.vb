Imports System.Collections.ObjectModel
Imports WpfExamples

Public Class MenuItemVM
    Inherits BaseVM

#Region " Properties"

    Private _menuId As String
    Private _parentId As String
    Private _menuName As String
    Private _menuIcon As Object
    Private _role As Boolean
    Private _objectId As Object
    Private _MenuItems As ObservableCollection(Of MenuItemVM)
    Private _SubMenu As ObservableCollection(Of MenuItemVM)
#End Region


    Public Sub New()
        _MenuItems = BuilMenuTree()
    End Sub

    Public Property MenuId As String
        Get
            Return _menuId
        End Get
        Set(value As String)
            _menuId = value
        End Set
    End Property

    Public Property MenuName As String
        Get
            Return _menuName
        End Get
        Set(value As String)
            _menuName = value
        End Set
    End Property
    Public Property ParentId As String
        Get
            Return _parentId
        End Get
        Set(value As String)
            _parentId = value
        End Set
    End Property
    Public Property MenuIcon As Object
        Get
            Return _menuIcon
        End Get
        Set(value As Object)
            _menuIcon = value
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

    Public Property ObjectId As Object
        Get
            Return _objectId
        End Get
        Set(value As Object)
            _objectId = value
        End Set
    End Property

    Public Property MenuItems As ObservableCollection(Of MenuItemVM)
        Get
            Return _MenuItems
        End Get
        Set(value As ObservableCollection(Of MenuItemVM))
            _MenuItems = value
        End Set
    End Property

    Public Property SubMenu As ObservableCollection(Of MenuItemVM)
        Get
            Return _SubMenu
        End Get
        Set(value As ObservableCollection(Of MenuItemVM))
            _SubMenu = value
        End Set
    End Property


#Region "Build menu tree"
    Private Function BuilMenuTree()
        Dim allItems As List(Of MenuItemVM) = MenuDTO.GetAllMenuItems

        Dim roots = allItems.Where(Function(x) String.IsNullOrEmpty(x.ParentId))

        For Each item In allItems
            Dim parent = allItems.FirstOrDefault(Function(x) x.MenuId = item.ParentId)
            If parent IsNot Nothing Then parent.SubMenu.Add(item)
        Next

        Return roots
    End Function
#End Region

#Region " Build Menu tree by manual method"
    'Private Sub GetMenuItems()
    '    _MenuItems = New ObservableCollection(Of MenuDTO) From {
    '        New MenuDTO With {
    '            .Header = "Alpha",
    '            .Command = New RelayCommand(AddressOf OnItemSelected, AddressOf ItemCanBeSelected),
    '            .Icon = New PackIcon With {.Kind = PackIconKind.Home}
    '    },
    '        New MenuDTO With {
    '            .Header = "Beta",
    '            .Command = New RelayCommand(AddressOf OnItemSelected, AddressOf ItemCanBeSelected),
    '            .SubMenu = New ObservableCollection(Of MenuDTO) From {
    '                New MenuDTO With {
    '                    .Header = "Beta1",
    '                    .Command = New RelayCommand(AddressOf OnItemSelected, AddressOf ItemCanBeSelected)
    '                },
    '                New MenuDTO With {
    '                    .Header = "Beta2",
    '                    .Command = New RelayCommand(AddressOf OnItemSelected, AddressOf ItemCanBeSelected),
    '                    .SubMenu = New ObservableCollection(Of MenuDTO) From {
    '                        New MenuDTO With {
    '                            .Header = "Beta1a"
    '                        },
    '                        New MenuDTO With {
    '                            .Header = "Beta1b"
    '                        },
    '                        New MenuDTO With {
    '                            .Header = "Beta1c"
    '                        }
    '                    }
    '                },
    '                New MenuDTO With {
    '                    .Header = "Beta3"
    '                }
    '            }
    '        },
    '        New MenuDTO With {
    '            .Header = "Gamma",
    '            .Command = New RelayCommand(AddressOf OnItemSelected, AddressOf ItemCanBeSelected)
    '        }
    '    }
    'End Sub
#End Region

End Class