Imports System.ComponentModel

Public Class UsersModel
    Implements INotifyPropertyChanged
    Private _UserName As String
    Private _UserEmail As String
    Private _UserCreate_at As Date
    Private _UserUpdate_at As Date
    Private _IsSelected As Boolean


    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub OnPropertyChanged(Optional propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
    Public Property UserName As String
        Get
            Return _UserName
        End Get
        Set(value As String)
            _UserName = value
        End Set
    End Property

    Public Property UserEmail As String
        Get
            Return _UserEmail
        End Get
        Set(value As String)
            _UserEmail = value
        End Set
    End Property

    Public Property UserCreate_at As Date
        Get
            Return _UserCreate_at
        End Get
        Set(value As Date)
            _UserCreate_at = value
        End Set
    End Property

    Public Property UserUpdate_at As Date
        Get
            Return _UserUpdate_at
        End Get
        Set(value As Date)
            _UserUpdate_at = value
        End Set
    End Property

    Public Property IsSelected As Boolean
        Get
            Return _IsSelected
        End Get
        Set(value As Boolean)
            _IsSelected = value
            OnPropertyChanged(IsSelected)
        End Set
    End Property
End Class
