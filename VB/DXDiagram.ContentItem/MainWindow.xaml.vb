Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Diagram.Core
Imports DevExpress.Xpf.Diagram

Namespace DXDiagram.ContentItem

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            RegisterContentItemTools()
            LoadDiagram()
        End Sub

        Private Sub RegisterContentItemTools()
            Dim stencil As DiagramStencil = New DiagramStencil("CustomTools", "Content Item Tools")
            stencil.RegisterTool(New FactoryItemTool("Text", Function() "Text", Function(diagram) New DiagramContentItem() With {.CustomStyleId = "formattedTextContentItem"}, New Size(230, 110), True))
            stencil.RegisterTool(New FactoryItemTool("Logo", Function() "Logo", Function(diagram) New DiagramContentItem() With {.CustomStyleId = "devExpressLogoContentItem"}, New Size(230, 80), True))
            stencil.RegisterTool(New FactoryItemTool("Action", Function() "Button", Function(diagram) New DiagramContentItem() With {.CustomStyleId = "buttonContentItem"}, New Size(230, 80), True))
            DiagramToolboxRegistrator.RegisterStencil(stencil)
        End Sub

        Private Sub LoadDiagram()
            Me.diagramControl.DocumentSource = "DiagramData.xml"
            Me.diagramControl.SelectedStencils = New StencilCollection(New String() {"CustomTools"})
        End Sub
    End Class
End Namespace
