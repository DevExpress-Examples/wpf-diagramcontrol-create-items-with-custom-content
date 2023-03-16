Imports DevExpress.Diagram.Core
Imports DevExpress.Xpf.Diagram
Imports System.Windows

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
            stencil.RegisterTool(New FactoryItemTool(id:="Text", getName:=Function() "Text", createItem:=Function(diagram) New DiagramContentItem() With {.CustomStyleId = "formattedTextContentItem"}, defaultSize:=New Size(230, 110), isQuick:=True))
            stencil.RegisterTool(New FactoryItemTool(id:="Logo", getName:=Function() "Logo", createItem:=Function(diagram) New DiagramContentItem() With {.CustomStyleId = "devExpressLogoContentItem"}, defaultSize:=New Size(230, 80), isQuick:=True))
            stencil.RegisterTool(New FactoryItemTool(id:="Action", getName:=Function() "Button", createItem:=Function(diagram) New DiagramContentItem() With {.CustomStyleId = "buttonContentItem"}, defaultSize:=New Size(230, 80), isQuick:=True))
            DiagramToolboxRegistrator.RegisterStencil(stencil)
        End Sub

        Private Sub LoadDiagram()
            Me.diagramControl.DocumentSource = "DiagramData.xml"
            Me.diagramControl.SelectedStencils = New StencilCollection(New String() {"CustomTools"})
        End Sub
    End Class
End Namespace
