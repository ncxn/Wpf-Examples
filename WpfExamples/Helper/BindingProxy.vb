Imports System.Diagnostics.CodeAnalysis
Imports System.Globalization

Public Class BindingProxy
    Inherits Freezable

    Public Shared ReadOnly DataProperty As DependencyProperty = DependencyProperty.Register("Data", GetType(IValueConverter), GetType(BindingProxy), New UIPropertyMetadata(Nothing))
    Protected Overrides Function CreateInstanceCore() As Freezable
        Return New BindingProxy()
    End Function

    Public Property Data As IValueConverter
        Get
            Return CType(GetValue(DataProperty), IValueConverter)
        End Get
        Set(value As IValueConverter)
            SetValue(DataProperty, value)
        End Set
    End Property

    <SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations", Justification:="It'll be fiiiiine")>
    Public Overrides Function ToString() As String
        Return "BindingProxy: " & Convert.ToString(Data, CultureInfo.CurrentCulture)
    End Function

End Class