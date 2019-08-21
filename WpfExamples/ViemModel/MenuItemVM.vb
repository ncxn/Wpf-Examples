Imports System.Collections.ObjectModel
Imports WpfExamples

Public Class MenuItemVM
    Inherits BaseVM

    Private _children As ObservableCollection(Of MenuDTO)
    Private _parent As ObservableCollection(Of MenuDTO)
    Private _onSelected As ICommand

    Public Sub New()
        _parent = getParent()
        _children = getChildren()
    End Sub

    Public Property Children As ObservableCollection(Of MenuDTO)
        Get
            Return _children
        End Get
        Set(ByVal value As ObservableCollection(Of MenuDTO))
            _children = value
            OnPropertyChanged(NameOf(Children))
        End Set
    End Property
    Public Property Parent As ObservableCollection(Of MenuDTO)
        Get
            Return _parent
        End Get
        Set(ByVal value As ObservableCollection(Of MenuDTO))
            _parent = value
            OnPropertyChanged(NameOf(Parent))
        End Set
    End Property

    Public ReadOnly Property OnSelected As ICommand
        Get
            If _onSelected Is Nothing Then
                _onSelected = New RelayCommand(AddressOf OnItemSelected, AddressOf ItemCanBeSelected)
            End If
            Return _onSelected
        End Get
    End Property


    Public Sub OnItemSelected(obj As Object)
        MessageBox.Show("Click vào éo nào" + obj.ToString)
    End Sub

    Public Function ItemCanBeSelected(obj As Object) As Boolean
        Return True
    End Function

    Private Function GetParent()
        Dim listObj = MenuDTO.GetAllMenuItems.Where(Function(x) x.Parent Is String.Empty Or x.Parent Is Nothing)
        Dim pr As ObservableCollection(Of MenuDTO) = New ObservableCollection(Of MenuDTO)(listObj)
        For Each i In pr
            Debug.WriteLine(i.Header.ToString)
        Next
        Return pr

    End Function

    Private Function GetChildren()
        Dim listObj = MenuDTO.GetAllMenuItems.Where(Function(x) x.Parent IsNot Nothing)
        Dim cr As ObservableCollection(Of MenuDTO) = New ObservableCollection(Of MenuDTO)(listObj)
        Return cr
    End Function
End Class