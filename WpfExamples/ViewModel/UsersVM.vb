Imports System.Collections.ObjectModel
Imports System.Data
Imports WpfExamples

Public Class UsersVM
    Inherits BaseVM

    Private _Users As ObservableCollection(Of UsersModel)
    Private _isSelected As Boolean
    Private _SelectedItem As UsersModel
    Private _EditCmd As RelayCommand
    Public Sub New()
        LoadData()
    End Sub

    Public Property Users As ObservableCollection(Of UsersModel)
        Get
            Return _Users
        End Get
        Set(value As ObservableCollection(Of UsersModel))
            _Users = value
            OnPropertyChanged(NameOf(Users))
        End Set
    End Property

    Public Property EditCmd As RelayCommand
        Get
            Return If(_EditCmd, New RelayCommand(AddressOf EditUser, AddressOf CanEditUser))
        End Get
        Set(value As RelayCommand)
            _EditCmd = value
        End Set
    End Property

    Public Property IsSelected As Boolean
        Get
            Return _isSelected
        End Get
        Set
            If SetProperty(_isSelected, Value) Then
                EditCmd.OnCanExecuteChanged()
            End If
            OnPropertyChanged(NameOf(IsSelected))
        End Set
    End Property

    Public Property SelectedItem As UsersModel
        Get
            Return _SelectedItem
        End Get
        Set(value As UsersModel)
            If SetProperty(_SelectedItem, value) Then
                EditCmd.RaiseCanExecuteChanged()
            End If
            OnPropertyChanged(NameOf(SelectedItem))
        End Set
    End Property

    Private Function CanEditUser(arg As Object) As Boolean
        'If SelectedItem IsNot Nothing Then
        '    Return True
        'Else
        '    Return False
        'End If
        'If arg IsNot Nothing Then
        '    Return True
        'Else
        '    Return False
        'End If
        Return Not IsNothing(arg)
        EditCmd.OnCanExecuteChanged()
    End Function

    Private Sub EditUser(obj As Object)
        Dim u As UsersModel = TryCast(obj, UsersModel)
        MessageBox.Show(u.UserName + ": " + IsSelected.ToString)

    End Sub

#Region " Get data of User"

    Private Function LoadData()

        Dim tb As DataTable = DBHelper.GetInstance.GetDataTable("SELECT user_name, user_email, user_created_at, user_updated_at FROM tblUsers", CommandType.Text)

        _Users = New ObservableCollection(Of UsersModel)

        For Each r As DataRow In tb.Rows
            Dim user As New UsersModel With {
                .UserName = r(0),
                .UserEmail = r(1),
                .UserCreate_at = r(2),
                .UserUpdate_at = r(3)
            }
            _Users.Add(user)
        Next

        Return _Users

    End Function

#End Region
End Class
