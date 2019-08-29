Imports System.Windows
Imports System.Windows.Media
Public Class VisualTreeHelpers
    Public Shared Function FindAncestor(Of T As DependencyObject)(ByVal current As DependencyObject) As T
        current = VisualTreeHelper.GetParent(current)

        While current IsNot Nothing

            If TypeOf current Is T Then
                Return CType(current, T)
            End If

            current = VisualTreeHelper.GetParent(current)
        End While

        Return Nothing
    End Function

    Public Shared Function FindAncestor(Of T As DependencyObject)(ByVal current As DependencyObject, ByVal lookupItem As T) As T
        While current IsNot Nothing

            If TypeOf current Is T AndAlso current Is lookupItem Then
                Return CType(current, T)
            End If

            current = VisualTreeHelper.GetParent(current)
        End While

        Return Nothing
    End Function

    Public Shared Function FindAncestor(Of T As DependencyObject)(ByVal current As DependencyObject, ByVal parentName As String) As T
        While current IsNot Nothing

            If Not String.IsNullOrEmpty(parentName) Then
                Dim frameworkElement = TryCast(current, FrameworkElement)

                If TypeOf current Is T AndAlso frameworkElement IsNot Nothing AndAlso frameworkElement.Name = parentName Then
                    Return CType(current, T)
                End If
            ElseIf TypeOf current Is T Then
                Return CType(current, T)
            End If

            current = VisualTreeHelper.GetParent(current)
        End While

        Return Nothing
    End Function

    Public Shared Function FindChild(Of T As DependencyObject)(ByVal parent As DependencyObject, ByVal childName As String) As T
        If parent Is Nothing Then Return Nothing
        Dim foundChild As T = Nothing
        Dim childrenCount As Integer = VisualTreeHelper.GetChildrenCount(parent)

        For i As Integer = 0 To childrenCount - 1
            Dim child = VisualTreeHelper.GetChild(parent, i)
            Dim childType As T = TryCast(child, T)

            If childType Is Nothing Then
                foundChild = FindChild(Of T)(child, childName)
                If foundChild IsNot Nothing Then Exit For
            ElseIf Not String.IsNullOrEmpty(childName) Then
                Dim frameworkElement = TryCast(child, FrameworkElement)

                If frameworkElement IsNot Nothing AndAlso frameworkElement.Name = childName Then
                    foundChild = CType(child, T)
                    Exit For
                Else
                    foundChild = FindChild(Of T)(child, childName)
                    If foundChild IsNot Nothing Then Exit For
                End If
            Else
                foundChild = CType(child, T)
                Exit For
            End If
        Next

        Return foundChild
    End Function

    Public Shared Function FindChild(Of T As DependencyObject)(ByVal parent As DependencyObject) As T
        If parent Is Nothing Then Return Nothing
        Dim foundChild As T = Nothing
        Dim childrenCount As Integer = VisualTreeHelper.GetChildrenCount(parent)

        For i As Integer = 0 To childrenCount - 1
            Dim child = VisualTreeHelper.GetChild(parent, i)
            Dim childType As T = TryCast(child, T)

            If childType Is Nothing Then
                foundChild = FindChild(Of T)(child)
                If foundChild IsNot Nothing Then Exit For
            Else
                foundChild = CType(child, T)
                Exit For
            End If
        Next

        Return foundChild
    End Function
End Class
