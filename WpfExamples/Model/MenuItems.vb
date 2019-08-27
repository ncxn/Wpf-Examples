Imports System.Collections.ObjectModel

Public MustInherit Class MenuItems
    Private _MenuId As String
    Private _MenuHeader As String
    Private _MenuIcon As Object
    Private _MenuParentId As String
    Private _MenuCommand As ICommand
    Private _MenuRole As Boolean
    Private _SubMenu As ObservableCollection(Of MenuItems)

    Public Sub New()
        _SubMenu = New ObservableCollection(Of MenuItems)
    End Sub

    Public Property MenuId As String
        Get
            Return _MenuId
        End Get
        Set(value As String)
            _MenuId = value
        End Set
    End Property

    Public Property MenuHeader As String
        Get
            Return _MenuHeader
        End Get
        Set(value As String)
            _MenuHeader = value
        End Set
    End Property

    Public Property MenuIcon As Object
        Get
            Return _MenuIcon
        End Get
        Set(value As Object)
            _MenuIcon = value
        End Set
    End Property

    Public Property MenuParentId As String
        Get
            Return _MenuParentId
        End Get
        Set(value As String)
            _MenuParentId = value
        End Set
    End Property

    Public Property MenuCommand As ICommand
        Get
            If _MenuCommand Is Nothing Then
                _MenuCommand = New RelayCommand(AddressOf OnItemSelected, AddressOf ItemCanBeSelected)
            End If

            Return _MenuCommand
        End Get
        Set(value As ICommand)
            _MenuCommand = value
        End Set
    End Property

    Public Property MenuRole As Boolean
        Get
            Return _MenuRole
        End Get
        Set(value As Boolean)
            _MenuRole = value
        End Set
    End Property

    Public Property SubMenu As ObservableCollection(Of MenuItems)
        Get
            Return _SubMenu
        End Get
        Set(value As ObservableCollection(Of MenuItems))
            _SubMenu = value
        End Set
    End Property

    Public Sub AddSubMenu(ByVal menuItem As MenuItems)
        _SubMenu.Add(menuItem)
    End Sub

    Public Sub RemoveSubMenu(ByVal menuItem As MenuItems)
        If _SubMenu.Contains(menuItem) Then
            _SubMenu.Remove(menuItem)
        End If
    End Sub

    Public MustOverride Sub OnItemSelected(Obj As Object)

    Public Overridable Function ItemCanBeSelected(Obj As Object) As Boolean
        Return True
    End Function

End Class
