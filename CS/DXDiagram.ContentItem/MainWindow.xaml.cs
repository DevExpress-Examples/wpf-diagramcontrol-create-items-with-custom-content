using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Diagram.Core;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Diagram;
using DevExpress.Mvvm.POCO;

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
                "Text",
                () => "Text",
                diagram => new DiagramContentItem() {
                    CustomStyleId = "formattedTextContentItem"
                },
                new Size(230, 110), true));
            stencil.RegisterTool(new FactoryItemTool(
                "Logo",
                () => "Logo",
                diagram => new DiagramContentItem() {
                    CustomStyleId = "devExpressLogoContentItem",
                },
                new Size(230, 80), true));
                stencil.RegisterTool(new FactoryItemTool(
                "Action",
                () => "Button",
                diagram => new DiagramContentItem()
                {
                    CustomStyleId = "buttonContentItem",
                },
                new Size(230, 80), true));
                DiagramToolboxRegistrator.RegisterStencil(stencil);
            }

        void LoadDiagram() {
            diagramControl.DocumentSource = "DiagramData.xml";
            diagramControl.SelectedStencils = new StencilCollection(new string[] { "CustomTools" });
        }
    }
}
