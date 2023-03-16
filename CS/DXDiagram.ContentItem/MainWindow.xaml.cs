using DevExpress.Diagram.Core;
using DevExpress.Xpf.Diagram;
using System.Windows;

namespace DXDiagram.ContentItem {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            RegisterContentItemTools();
            LoadDiagram();
        }

        void RegisterContentItemTools() {
            DiagramStencil stencil = new DiagramStencil("CustomTools", "Content Item Tools");

            stencil.RegisterTool(new FactoryItemTool(
                id: "Text",
                getName: () => "Text",
                createItem: diagram => new DiagramContentItem() {
                    CustomStyleId = "formattedTextContentItem"
                },
                defaultSize: new Size(230, 110), 
                isQuick: true
            ));

            stencil.RegisterTool(new FactoryItemTool(
                id: "Logo",
                getName: () => "Logo",
                createItem: diagram => new DiagramContentItem() {
                    CustomStyleId = "devExpressLogoContentItem",
                },
                defaultSize: new Size(230, 80),
                isQuick: true
            ));

            stencil.RegisterTool(new FactoryItemTool(
                id: "Action",
                getName: () => "Button",
                createItem: diagram => new DiagramContentItem() {
                    CustomStyleId = "buttonContentItem",
                },
                defaultSize: new Size(230, 80),
                isQuick: true
            ));

            DiagramToolboxRegistrator.RegisterStencil(stencil);
        }

        void LoadDiagram() {
            diagramControl.DocumentSource = "DiagramData.xml";
            diagramControl.SelectedStencils = new StencilCollection(new string[] { "CustomTools" });
        }
    }
}
