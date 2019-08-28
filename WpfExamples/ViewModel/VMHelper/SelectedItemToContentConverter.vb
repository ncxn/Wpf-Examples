Imports System.Globalization

Public Class SelectedItemToContentConverter
    Implements IMultiValueConverter

    Public Function Convert(ByVal values As Object(), ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
        If values IsNot Nothing AndAlso values.Length > 1 Then
            Return If(values(0), values(1))
        End If

        Return Nothing
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetTypes As Type(), ByVal parameter As Object, ByVal culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
        Return targetTypes.[Select](Function(t) Binding.DoNothing).ToArray()
    End Function
End Class
