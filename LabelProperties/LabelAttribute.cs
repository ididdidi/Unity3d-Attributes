using UnityEngine;

namespace ru.mofrison.unity3d.UnityExtended
{
    /// <summary>
    /// Attribute for custom label
    /// Allows you to change the attribute name
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class LabelAttribute : PropertyAttribute
    {
        // Label text
        public string text;

        /// <summary>
        /// Requiring implementation of the <see cref="LabelAttribute"/> interface.
        /// </summary>
        /// <param name="label">Label.</param>
        public LabelAttribute(string label) => this.text = label;
    }
}
