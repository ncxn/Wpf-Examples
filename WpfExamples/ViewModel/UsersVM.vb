Imports System.Collections.ObjectModel
Imports System.Data
Imports WpfExamples

Public Class UsersVM
    Inherits BaseVM

    Private _Users As ObservableCollection(Of UsersModel)
    Private _IsItemSelected As Boolean
    Private _IsAllItemsSelected As Boolean
    Private _SelectedUsers As ObservableCollection(Of UsersModel)
    Private _SelectedUser As UsersModel

    Private _SelectedUsersCmd As RelayCommand
    Private _SelectAllUsersCmd As RelayCommand
    Private _EditCmd As RelayCommand
    Private _DeleteCmd As RelayCommand

    Public Sub New()
        LoadData()
    End Sub

#Region " Command Properties"

    Public Property SelectedUsersCmd As RelayCommand
        Get
            Return If(_SelectedUsersCmd, New RelayCommand(AddressOf SelectUsers))
        End Get
        Set(value As RelayCommand)
            _SelectedUsersCmd = value
            OnPropertyChanged(NameOf(SelectedUsersCmd))
        End Set
    End Property

    'Public Property SelectAllUsersCmd As RelayCommand
    '    Get
    '        Return If(_SelectAllUsersCmd, New RelayCommand(AddressOf SelectAllUsers))
    '    End Get
    '    Set(value As RelayCommand)
    '        _SelectAllUsersCmd = value
    '        OnPropertyChanged(NameOf(SelectedUsersCmd))
    '    End Set
    'End Property

    Public Property EditCmd As RelayCommand
        Get
            Return If(_EditCmd, New RelayCommand(AddressOf EditUser, AddressOf CanEditUser))
        End Get
        Set(value As RelayCommand)
            _EditCmd = value
        End Set
    End Property

    Public Property DeleteCmd As RelayCommand
        Get
            Return If(_DeleteCmd, New RelayCommand(AddressOf DeleteUser, AddressOf CanDeleteUser))
        End Get
        Set(value As RelayCommand)
            _DeleteCmd = value
        End Set
    End Property

#End Region

#Region " Properties"

    Public Property Users As ObservableCollection(Of UsersModel)
        Get
            Return _Users
        End Get
        Set(value As ObservableCollection(Of UsersModel))
            _Users = value
            OnPropertyChanged(NameOf(Users))
        End Set
    End Property

    Public Property SelectedUsers As ObservableCollection(Of UsersModel)
        Get
            Return _SelectedUsers
        End Get
        Set(value As ObservableCollection(Of UsersModel))
            _SelectedUsers = value
            OnPropertyChanged(NameOf(SelectedUsers))
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
            OnPropertyChanged(NameOf(IsItemSelected))
        End Set
    End Property

    Public Property IsAllItemsSelected As Boolean
        Get
            Return _IsAllItemsSelected
        End Get
        Set(ByVal value As Boolean)
            _IsAllItemsSelected = value
            SelectAllUsers(value, Users)
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


#End Region

#Region " The Sub/Funtions"

    Private Function CanEditUser(arg As Object) As Boolean
        If SelectedUser IsNot Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub EditUser(obj As Object)
        Dim u As UsersModel = TryCast(obj, UsersModel)
        MessageBox.Show("Do you edit " + u.UserName + " ?")
    End Sub

    Private Function CanDeleteUser(arg As Object) As Boolean
        Return True
    End Function

    Private Sub DeleteUser(obj As Object)
        Dim s As String = String.Empty
        For Each u In SelectedUsers.ToList
            s = s + " + " + u.UserName
            Users.Remove(u)
            SelectedUsers.Remove(u)
        Next
        MessageBox.Show(s)
    End Sub

    Private Sub SelectUsers(obj As Object)
        Dim items As IList = CType(obj, IList)
        _SelectedUsers = New ObservableCollection(Of UsersModel)(items.Cast(Of UsersModel)())
    End Sub

    Private Sub SelectAllUsers(value As Boolean, models As ObservableCollection(Of UsersModel))
        For Each u In models
            u.IsSelected = value
        Next
        For Each u In Users
            Debug.WriteLine(u.IsSelected)
        Next
        OnPropertyChanged(IsItemSelected)
    End Sub

#End Region

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
