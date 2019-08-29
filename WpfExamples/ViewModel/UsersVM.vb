Imports System.Collections.ObjectModel
Imports System.Data
Imports WpfExamples

Public Class UsersVM
    Inherits BaseVM

    Private _Users As ObservableCollection(Of UsersModel)
    Private _isSelected As Boolean

    Private _EditCmd As ICommand
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

    Public Property EditCmd As ICommand
        Get
            Return If(_EditCmd, New RelayCommand(AddressOf EditUser, AddressOf CanEditUser))
        End Get
        Set(value As ICommand)
            _EditCmd = value
            OnPropertyChanged(NameOf(EditCmd))
        End Set
    End Property

    Public Property IsSelected As Boolean
        Get
            Return _isSelected
        End Get
        Set(value As Boolean)
            _isSelected = value
            OnPropertyChanged(NameOf(IsSelected))
        End Set
    End Property

    Private Function CanEditUser(arg As Object) As Boolean
        Return IsSelected
    End Function

    Private Sub EditUser(obj As Object)
        MessageBox.Show(obj.ToString)
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
