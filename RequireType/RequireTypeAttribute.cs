using UnityEngine;

namespace UnityExtended
{
    /// <summary>
    /// An attribute to display in the field inspector with a <see cref="GameObject"/> that implements the provided interface.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class RequireTypeAttribute : PropertyAttribute
    {
        // Interface type.
        public System.Type RequiredType { get; }

        /// <summary>
        /// Requiring implementation of the <see cref="RequireTypeAttribute"/> interface.
        /// </summary>
        /// <param name="type">Interface type.</param>
        public RequireTypeAttribute(System.Type type)
        {
            this.RequiredType = type;
        }
    }
}
