<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128585250/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T395119)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF DiagramControl - Create Items with Custom Content

This example demonstrates how to create diagram items with custom elements and register these items in the toolbox.

![image](https://user-images.githubusercontent.com/65009440/225615519-b95b8b2e-7612-4f0f-9cd0-f0ddef07d099.png)

DiagramControl shapes can display only string content. To add custom elements to diagram items, use [DiagramContentItem](https://docs.devexpress.com/WPF/DevExpress.Xpf.Diagram.DiagramContentItem) objects with the specified [ContentTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Diagram.DiagramContentItem.ContentTemplate) property:

```xaml
<Style x:Key="formattedTextContentItem" TargetType="dxdiag:DiagramContentItem">
    <Setter Property="ContentTemplate">
        <Setter.Value>
            <DataTemplate>
                <!-- ... -->
            </DataTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

Create a [DiagramStencil](https://docs.devexpress.com/CoreLibraries/DevExpress.Diagram.Core.DiagramStencil) object and call its [RegisterTool](https://docs.devexpress.com/CoreLibraries/DevExpress.Diagram.Core.DiagramStencil.RegisterTool(DevExpress.Diagram.Core.ItemTool)) method with the [FactoryItemTool](https://docs.devexpress.com/CoreLibraries/DevExpress.Diagram.Core.FactoryItemTool) object as a parameter to register the created `DiagramContentItem` in the toolbox:

```cs
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
```

Call the [DiagramToolboxRegistrator.RegisterStencil](https://docs.devexpress.com/CoreLibraries/DevExpress.Diagram.Core.DiagramToolboxRegistrator.RegisterStencil(DevExpress.Diagram.Core.DiagramStencil)) method to register the stencil:

```cs
DiagramToolboxRegistrator.RegisterStencil(stencil);
```

To deserialize the `DiagramContentItem`, specify its `CustomStyleId` property. This property accepts the applied style's key.

## Files to Review

* [DiagramData.xml](./CS/DXDiagram.ContentItem/DiagramData.xml) (VB: [DiagramData.xml](./VB/DXDiagram.ContentItem/DiagramData.xml))
* [DiagramResources.xaml](./CS/DXDiagram.ContentItem/DiagramResources.xaml) (VB: [DiagramResources.xaml](./VB/DXDiagram.ContentItem/DiagramResources.xaml))
* [MainWindow.xaml](./CS/DXDiagram.ContentItem/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/DXDiagram.ContentItem/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/DXDiagram.ContentItem/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DXDiagram.ContentItem/MainWindow.xaml.vb))
* [Model.cs](./CS/DXDiagram.ContentItem/Model.cs) (VB: [Model.vb](./VB/DXDiagram.ContentItem/Model.vb))

## Documentation

* [Diagram Items with Custom Content](https://docs.devexpress.com/WPF/120318/controls-and-libraries/diagram-control/diagram-items/items-with-custom-content)
* [DiagramContentItem](https://docs.devexpress.com/WPF/DevExpress.Xpf.Diagram.DiagramContentItem)
* [DiagramContentItem.ContentTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Diagram.DiagramContentItem.ContentTemplate)

## More Examples

* [WPF DiagramControl - Create Custom Shapes with Connection Points](https://github.com/DevExpress-Examples/wpf-diagramdesigner-create-custom-shapes-with-connection-points)
* [Create Custom Diagram Containers and Register Them in the Toolbox and Ribbon Gallery](https://github.com/DevExpress-Examples/how-to-create-custom-diagram-containers-and-register-them-in-the-toolbox-and-ribbon-gallery-t466430)
* [Create a DiagramShape Descendant with Editable and Serializable Properties](https://github.com/DevExpress-Examples/how-to-create-a-diagramshape-descendant-with-editable-and-serializable-properties-t395040)
