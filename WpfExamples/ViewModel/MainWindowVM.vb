Public Class MainWindowVM
    Inherits BaseVM
    Private _MenuCmd As ICommand
    Private _HambugerMenuCmd As ICommand
    Private _DataGridCmd As ICommand

    Public Property MenuCmd As ICommand
        Get
            Return If(_MenuCmd, New RelayCommand(AddressOf OpenMenuExample, AddressOf CanOpenMenuExample))
        End Get
        Set(value As ICommand)
            _MenuCmd = value
            OnPropertyChanged(NameOf(MenuCmd))
        End Set
    End Property
    Public Property HambugerMenuCmd As ICommand
        Get
            Return If(_HambugerMenuCmd, New RelayCommand(AddressOf OpenHambugerMenu, AddressOf CanOpenHambugerMenu))
        End Get
        Set(value As ICommand)
            _HambugerMenuCmd = value
            OnPropertyChanged(NameOf(HambugerMenuCmd))
        End Set
    End Property

    Public Property DataGridCmd As ICommand
        Get
            Return If(_DataGridCmd, New RelayCommand(AddressOf OpenDataGrid, AddressOf CanOpenDataGrid))
        End Get
        Set(value As ICommand)
            _DataGridCmd = value
        End Set
    End Property

    Private Sub OpenDataGrid(obj As Object)
        Dim w As Windows.Window = New DataGridView
        w.Show()
    End Sub

    Private Function CanOpenDataGrid(arg As Object) As Boolean
        Return True
    End Function

    Private Sub OpenMenuExample(obj As Object)
        Dim w As Windows.Window = New MainMenuExample
        w.Show()
    End Sub
    Private Function CanOpenMenuExample(obj As Object)
        Return True
    End Function


    Private Sub OpenHambugerMenu(obj As Object)
        Dim w As Windows.Window = New HamburgerMenu
        w.Show()
    End Sub

    Private Function CanOpenHambugerMenu(arg As Object) As Boolean
        Return True
    End Function
End Class
