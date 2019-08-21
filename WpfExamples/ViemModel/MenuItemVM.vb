Imports System.Collections.ObjectModel
Imports MaterialDesignThemes.Wpf
Imports WpfExamples

Public Class MenuItemVM
    Inherits BaseVM


    Private _MenuItems As ObservableCollection(Of MenuDTO)

    Public Sub New()
        GetMenuItems()

    End Sub


    Public Property MenuItems As ObservableCollection(Of MenuDTO)
        Get
            Return _MenuItems
        End Get
        Set(value As ObservableCollection(Of MenuDTO))
            _MenuItems = value
            OnPropertyChanged(NameOf(MenuItems))
        End Set
    End Property

    Public Sub OnItemSelected(obj As Object)
        MessageBox.Show("Click vào éo nào" + obj.ToString)
    End Sub

    Public Function ItemCanBeSelected(obj As Object) As Boolean
        Return True
    End Function

    Private Sub GetMenuItems()
        _MenuItems = New ObservableCollection(Of MenuDTO) From {
            New MenuDTO With {
                .Header = "Alpha",
                .Command = New RelayCommand(AddressOf OnItemSelected, AddressOf ItemCanBeSelected),
                .Icon = New PackIcon With {.Kind = PackIconKind.Home}
        },
            New MenuDTO With {
                .Header = "Beta",
                .Command = New RelayCommand(AddressOf OnItemSelected, AddressOf ItemCanBeSelected),
                .SubMenu = New ObservableCollection(Of MenuDTO) From {
                    New MenuDTO With {
                        .Header = "Beta1",
                        .Command = New RelayCommand(AddressOf OnItemSelected, AddressOf ItemCanBeSelected)
                    },
                    New MenuDTO With {
                        .Header = "Beta2",
                        .Command = New RelayCommand(AddressOf OnItemSelected, AddressOf ItemCanBeSelected),
                        .SubMenu = New ObservableCollection(Of MenuDTO) From {
                            New MenuDTO With {
                                .Header = "Beta1a"
                            },
                            New MenuDTO With {
                                .Header = "Beta1b"
                            },
                            New MenuDTO With {
                                .Header = "Beta1c"
                            }
                        }
                    },
                    New MenuDTO With {
                        .Header = "Beta3"
                    }
                }
            },
            New MenuDTO With {
                .Header = "Gamma",
                .Command = New RelayCommand(AddressOf OnItemSelected, AddressOf ItemCanBeSelected)
            }
        }
    End Sub

End Class