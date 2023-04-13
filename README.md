# Unity3d-Attributes
Additional attributes module for Unity3d.

## Property attributes

Attribute								| Description
--------------------------------------- | -----------
[Label](#labelattribute)				| Allows you to change the attribute name
[RequireType](#requiretype)				| Allows the field to be displayed for the provided interface in the inspector

### LabelAttribute
Add the following attribute before the property declaration to change its label displayed in the Inspector:
```csharp
[SerializeField, Label("Property name")] private string str;
```

### RequireType
Add the following attribute before the property declaration of type `Object`(!) to display the field for the object in the Inspector:
```csharp
[SerializeField, RequireType(typeof(InterfaceType))] private Object fieldName;
```
`InterfaceType` - is the name of the interface (required parameter).