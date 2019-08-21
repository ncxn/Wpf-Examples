Imports System.Collections.ObjectModel

Public Class MainMenu
    Public Property Parent As ObservableCollection(Of MenuDTO)
    Public Sub New()
        InitializeComponent()
        Parent = New ObservableCollection(Of MenuDTO) From {
            New MenuDTO With {
                .Header = "Alpha"
            },
            New MenuDTO With {
                .Header = "Beta",
                .SubMenu = New ObservableCollection(Of MenuDTO) From {
                    New MenuDTO With {
                        .Header = "Beta1"
                    },
                    New MenuDTO With {
                        .Header = "Beta2",
                        .SubMenu = New ObservableCollection(Of MenuDTO) From {
                            New MenuDTO With {
                                .Header = "Beta1a"
                            },
                            New MenuDTO With {
                                .Header = "Beta1b"
                            },
                            New MenuDTO With {
                                .Header = "Beta1c"
                            }
                        }
                    },
                    New MenuDTO With {
                        .Header = "Beta3"
                    }
                }
            },
            New MenuDTO With {
                .Header = "Gamma"
            }
        }
        DataContext = Me
    End Sub
End Class
