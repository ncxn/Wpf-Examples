Public Class UsersModel
    Private _UserName As String
    Private _UserEmail As String
    Private _UserCreate_at As Date
    Private _UserUpdate_at As Date

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
End Class
