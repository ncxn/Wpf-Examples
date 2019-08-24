Imports System.Globalization

Public Class BoolToContentConverter
    Implements IValueConverter

    Public Sub New()
        TrueContent = "True"
        FalseContent = "False"
        NullContent = "No Value"
    End Sub

    Public Property TrueContent As Object
    Public Property FalseContent As Object
    Public Property NullContent As Object

    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
        If value Is Nothing Then Return NullContent
        Dim boolValue As Boolean = True
        Dim isBool As Boolean = True

        Try
            boolValue = CBool(value)
        Catch
            isBool = False
        End Try

        If Not isBool Then Return NullContent
        Return If(boolValue, TrueContent, FalseContent)
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class