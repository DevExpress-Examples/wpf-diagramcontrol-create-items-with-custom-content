Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Diagram.Core
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Diagram
Imports DevExpress.Mvvm.POCO

Namespace DXDiagram.ContentItem

    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
            RegisterContentItemTools()
            LoadDiagram()
        End Sub

        Private Sub RegisterContentItemTools()
            Dim stencil As New DiagramStencil("CustomTools", "Content Item Tools")
            stencil.RegisterTool(New FactoryItemTool("Text", Function() "Text", Function(diagram) New DiagramContentItem() With {.CustomStyleId = "formattedTextContentItem"}, New Size(230, 110), True))
            stencil.RegisterTool(New FactoryItemTool("Logo", Function() "Logo", Function(diagram) New DiagramContentItem() With {.CustomStyleId = "devExpressLogoContentItem"}, New Size(230, 80), True))
                stencil.RegisterTool(New FactoryItemTool("Action", Function() "Button", Function(diagram) New DiagramContentItem() With {.CustomStyleId = "buttonContentItem"}, New Size(230, 80), True))
                DiagramToolboxRegistrator.RegisterStencil(stencil)
        End Sub

        Private Sub LoadDiagram()
            diagramControl.DocumentSource = "DiagramData.xml"
            diagramControl.SelectedStencils = New StencilCollection(New String() { "CustomTools" })
        End Sub
    End Class
End Namespace
