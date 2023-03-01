# Unity3d-Attributes
Additional attributes module for Unity3d.

## Property attributes

Attribute								| Description
--------------------------------------- | -----------
[Label](#labelattribute)				| Allows you to change the attribute name
[RequireType](#requiretype)				| Allows the field to be displayed for the provided interface in the inspector
[DisplayProperties](#displayproperties)	| Allows the field to be displayed object properties in the field

### LabelAttribute
Add the following attribute before the property declaration to change its label displayed in the Inspector:
```csharp
[Label("Property name")] string str;
```

### RequireType
Add the following attribute before the property declaration of type `Object`(!) to display the field for the object in the Inspector:
```csharp
[RequireType(typeof(InterfaceType))] Object fieldName;
```
`InterfaceType` - is the name of the interface (required parameter).

### DisplayProperties
Add the following attribute before the property declaration to display the properties of the object after it has been added.
```csharp
[DisplayProperties] Image image;
```
**!** *Displaying arrays of objects does not work correctly*