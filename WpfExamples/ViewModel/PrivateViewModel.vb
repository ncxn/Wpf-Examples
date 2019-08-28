Public Class PrivateViewModel
    Inherits BaseVM

    Private ReadOnly _mainViewModel As BaseVM

    Public Sub New(ByVal mainViewModel As BaseVM)
        _mainViewModel = mainViewModel
    End Sub
End Class
