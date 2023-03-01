using UnityEngine;

/// <summary>
/// Attribute for displaying object properties in the field
/// Displaying arrays of objects does not work correctly!!!
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Field)]
public class DisplayPropertiesAttribute : PropertyAttribute
{
    public DisplayPropertiesAttribute() { }
}
