Imports MahApps.Metro.Controls
Imports MaterialDesignThemes.Wpf

Public Class HamburgerMenuVM
    Inherits BaseVM

    Private _menuItems As HamburgerMenuItemCollection
    Private _menuOptionItems As HamburgerMenuItemCollection

    Public Sub New()
        CreateMenuItems()
    End Sub

    Public Sub CreateMenuItems()
        MenuItems = New HamburgerMenuItemCollection From {
            New HamburgerMenuIconItem() With {
                .Icon = New PackIcon() With {
                    .Kind = PackIconKind.Home
                },
                .Label = "Home",
                .ToolTip = "The Home view.",
                .Tag = New HomeViewModel(Me)
            },
            New HamburgerMenuIconItem() With {
                .Icon = New PackIcon() With {
                    .Kind = PackIconKind.AccountCircle
                },
                .Label = "Private",
                .ToolTip = "Private stuff.",
                .Tag = New PrivateViewModel(Me)
            },
            New HamburgerMenuIconItem() With {
                .Icon = New PackIcon() With {
                    .Kind = PackIconKind.Settings
                },
                .Label = "Settings",
                .ToolTip = "The Application settings.",
                .Tag = New SettingsViewModel(Me)
            }
        }
        MenuOptionItems = New HamburgerMenuItemCollection From {
            New HamburgerMenuIconItem() With {
                .Icon = New PackIcon() With {
                    .Kind = PackIconKind.Help
                },
                .Label = "About",
                .ToolTip = "Some help.",
                .Tag = New AboutViewModel(Me)
            }
        }
    End Sub

    Public Property MenuItems As HamburgerMenuItemCollection
        Get
            Return _menuItems
        End Get
        Set(ByVal value As HamburgerMenuItemCollection)
            If Equals(value, _menuItems) Then Return
            _menuItems = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property MenuOptionItems As HamburgerMenuItemCollection
        Get
            Return _menuOptionItems
        End Get
        Set(ByVal value As HamburgerMenuItemCollection)
            If Equals(value, _menuOptionItems) Then Return
            _menuOptionItems = value
            OnPropertyChanged()
        End Set
    End Property
End Class
