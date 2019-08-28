Imports System.Collections.ObjectModel
Imports WpfExamples

Public Class MainMenuVM
    Inherits BaseVM

    Dim MainMenuX As New MainMenuExam

    Private _RootMenu As ObservableCollection(Of MainMenuExam)

    Public Sub New()
        _RootMenu = New ObservableCollection(Of MainMenuExam)(MainMenuX.GenerateMenu())
    End Sub

    Public Property RootMenu As ObservableCollection(Of MainMenuExam)
        Get
            Return _RootMenu
        End Get
        Set(value As ObservableCollection(Of MainMenuExam))
            _RootMenu = value
        End Set
    End Property



#Region " Build menu tree"

#End Region

#Region " Command"
    Public Sub OnClick(obj As Object)
        MessageBox.Show("Click vào éo nào: " + obj.ToString)
    End Sub

    Public Function CanClick(obj As Object) As Boolean

        Return True

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