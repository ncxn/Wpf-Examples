Imports System.Collections.ObjectModel

Public Class MainMenu

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim M As New MenuDTO
        M.Role = Not M.Role
        Debug.WriteLine("Quyền hiện tại:  " + M.Role.ToString)
    End Sub
End Class
