Imports System.Collections.ObjectModel
Imports System.Data

Public Class UsersVM
    Inherits BaseVM

    Private _Users As ObservableCollection(Of UsersModel)
    Private _IsItemSelected As Boolean
    Private _IsAllItemsSelected As Boolean
    Private _SelectedUser As UsersModel
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

    Public Property IsItemSelected As Boolean
        Get
            Return _IsItemSelected
        End Get
        Set
            If SetProperty(_IsItemSelected, Value) Then
                EditCmd.OnCanExecuteChanged()
            End If
            OnPropertyChanged(NameOf(_IsItemSelected))
        End Set
    End Property

    Public Property IsAllItemsSelected As Boolean
        Get
            Return _IsAllItemsSelected
        End Get
        Set(value As Boolean)
            _IsAllItemsSelected = value
            OnPropertyChanged(NameOf(IsAllItemsSelected))
        End Set
    End Property

    Public Property SelectedUser As UsersModel
        Get
            Return _SelectedUser
        End Get
        Set
            If SetProperty(_SelectedUser, Value) Then
                EditCmd.OnCanExecuteChanged()
            End If
            OnPropertyChanged(NameOf(SelectedUser))
        End Set
    End Property

    Private Function CanEditUser(arg As Object) As Boolean
        If SelectedUser IsNot Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub EditUser(obj As Object)
        Dim u As UsersModel = TryCast(obj, UsersModel)
        MessageBox.Show(u.UserName + ": " + IsItemSelected.ToString + ": " + IsAllItemsSelected.ToString)
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
                .UserUpdate_at = r(3),
                .IsSelected = False
            }
            _Users.Add(user)
        Next

        Return _Users

    End Function

#End Region

#Region " Additional"
    Private Sub SelectAll()
        For Each u In Users

        Next
    End Sub
#End Region
End Class
