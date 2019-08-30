Imports System.ComponentModel

Public Class BaseVM
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub OnPropertyChanged(Optional propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Function SetProperty(Of T)(ByRef storage As T, value As T, Optional propertyName As String = Nothing) As Boolean
        If Not Equals(storage, value) Then
            storage = value
            OnPropertyChanged(propertyName)
            Return True
        End If
        Return False
    End Function
End Class