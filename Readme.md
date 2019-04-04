<!-- default file list -->
*Files to look at*:

* [DiagramResources.xaml](./CS/DXDiagram.ContentItem/DiagramResources.xaml) (VB: [DiagramResources.xaml](./VB/DXDiagram.ContentItem/DiagramResources.xaml))
* **[MainWindow.xaml](./CS/DXDiagram.ContentItem/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/DXDiagram.ContentItem/MainWindow.xaml))**
* [MainWindow.xaml.cs](./CS/DXDiagram.ContentItem/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DXDiagram.ContentItem/MainWindow.xaml.vb))
* [Model.cs](./CS/DXDiagram.ContentItem/Model.cs) (VB: [Model.vb](./VB/DXDiagram.ContentItem/Model.vb))
<!-- default file list end -->
# How to: Create Items with Custom Content in DiagramControl


<p>Simple shapes in DiagramControl display only their content as an editable string. If it's necessary to add custom elements to diagram items, use the <strong>DiagramContentItem</strong> class. DiagramContentItem has the ContentTemplate property, which can be used to put any elements into the item.</p>


```xaml
<Style x:Key="formattedTextContentItem" TargetType="dxdiag:DiagramContentItem">
    <Setter Property="ContentTemplate">
        <Setter.Value>
            <DataTemplate>
                ...
            </DataTemplate>
        </Setter.Value>
    </Setter>
</Style>
```


<p>To register DiagramContentItem in the toolbox, use the <strong>DiagramStencil.RegisterTool</strong> method with <strong>FactoryItemTool</strong> as a parameter:</p>


```cs
stencil.RegisterTool(new FactoryItemTool(
    "Calendar",
    () => "Calendar",
    diagram => new DiagramContentItem() {
        CustomStyleId = "formattedTextContentItem"
    },
    new Size(230, 110), true));
```


<p>After that, register the stencil using <strong>DiagramToolboxRegistrator.RegisterStencil</strong>.<br>Please note that to properly deserialize DiagramContentItem, it's necessary to set its <strong>CustomStyleId</strong> property, which accepts a key of a Style applied to the item.</p>

<br/>


