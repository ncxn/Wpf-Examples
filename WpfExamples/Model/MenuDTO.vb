Imports System.Collections.ObjectModel
Imports System.Data
Imports WpfExamples

Public Class MenuDTO
    Private _Header As String
    Private _Parent As String
    Private _Command As ICommand
    Private _subMenu As ObservableCollection(Of MenuDTO)
    Public Property Header As String
        Get
            Return _Header
        End Get
        Set(value As String)
            _Header = value
        End Set
    End Property
    Public Property Parent As String
        Get
            Return _Parent
        End Get
        Set(value As String)
            _Parent = value
        End Set
    End Property
    Public Property Command As ICommand
        Get
            Return _Command
        End Get
        Set(value As ICommand)
            _Command = value
        End Set
    End Property

    Public Property SubMenu As ObservableCollection(Of MenuDTO)
        Get
            Return _subMenu
        End Get
        Set(value As ObservableCollection(Of MenuDTO))
            _subMenu = value
        End Set
    End Property

    Public Shared Function GetAllMenuItems() As List(Of MenuDTO)

        Dim dt As DataTable = DBHelper.GetInstance.GetDataTable("procGetAllControlsWithTypeMenu", CommandType.StoredProcedure)
        Dim allItems As List(Of MenuDTO) = (From dr As DataRow In dt.Rows Select New MenuDTO With {
                 .Header = dr(1),
                .Parent = dr(2).ToString()
            }).ToList()
        Return allItems
    End Function

End Class
