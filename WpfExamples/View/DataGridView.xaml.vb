Public Class DataGridView
    Private Sub CheckBox_Checked(sender As Object, e As RoutedEventArgs)
        UsersDataGrid.SelectAll()

    End Sub
    Private Sub CheckBox_UnChecked(sender As Object, e As RoutedEventArgs)
        UsersDataGrid.UnselectAll()
    End Sub
End Class
