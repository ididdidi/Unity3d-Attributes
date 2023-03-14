using UnityEngine;
using UnityEditor;

namespace UnityExtended
{
    /// <summary>
    /// Drawer for the RequireInterface attribute
    /// </summary>
    [CustomPropertyDrawer(typeof(RequireTypeAttribute))]
    public class RequireTypeDrawer : PropertyDrawer
    {
        /// <summary>
        /// Overrides GUI drawing for the attribute
        /// </summary>
        /// <param name="position"><see cref="Rect"/> fields to activate validation</param>
        /// <param name="property">Serializedproperty the object</param>
        /// <param name="label">Displaу field label</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Check if this is reference type property
            if (property.propertyType != SerializedPropertyType.ObjectReference)
            {
                // If field is not reference, show error message.            
                var style = new GUIStyle(EditorStyles.objectField);
                style.normal.textColor = Color.red;

                // Display label with error message
                EditorGUI.LabelField(position, label, new GUIContent($"{ property.propertyType } is not a reference type"), style);
                return;
            }

            var requiredType = ((RequireTypeAttribute)attribute).RequiredType;
            ChecDragAndDrops(position, requiredType);
            DrawObjectField(position, property, requiredType, label);
            ChecValues(property, requiredType);
        }

        /// <summary>
        /// Checks the validity of the dragged objects
        /// </summary>
        /// <param name="position"><see cref="Rect"/> fields to activate validation</param>
        /// <param name="requiredType">Required <see cref="System.Type"/> of reference being checked</param>
        private void ChecDragAndDrops(Rect position, System.Type requiredType)
        {
            // If the cursor is in the area of the rendered field
            if (position.Contains(Event.current.mousePosition))
            {
                // Iterate over all draggable references
                foreach (var @object in DragAndDrop.objectReferences)
                {
                    // If we do not find the required type
                    if (!IsValidObject(@object, requiredType))
                    {
                        // Disable drag and drop
                        DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if an reference matches the required type
        /// </summary>
        /// <param name="object">Checked reference</param>
        /// <param name="requiredType">Required <see cref="System.Type"/> of reference being checked</param>
        /// <returns></returns>
        private bool IsValidObject(Object @object, System.Type requiredType)
        {
            // If the object is a GameObject
            if (@object is GameObject go)
            {
                // Check if it has a component of the required type and return result
                return go.GetComponent(requiredType) != null;
            }

            // Check the reference itself for compliance with the required type
            return requiredType.IsAssignableFrom(@object.GetType());
        }

        /// <summary>
        /// Display a field for adding a reference to an object
        /// </summary>
        /// <param name="position"><see cref="Rect"/> fields to activate validation</param>
        /// <param name="property">Serializedproperty the object</param>
        /// <param name="requiredType">Required <see cref="System.Type"/> of reference being checked</param>
        /// <param name="label">Displaу field label</param>
        private void DrawObjectField(Rect position, SerializedProperty property, System.Type requiredType, GUIContent label)
        {
            // Start change checks
            EditorGUI.BeginChangeCheck();
            // Display a ObjectField
            EditorGUI.ObjectField(position, property, label);
            // If changes were made to the contents of the field and a GameObject was added to the field
            if (EditorGUI.EndChangeCheck() && property.objectReferenceValue is GameObject @object)
            {
                // Get component of the required type on the object and save a reference to it in a property
                property.objectReferenceValue = @object.GetComponent(requiredType);
            }
        }

        /// <summary>
        /// Checks the publication for the requirements of already added references
        /// </summary>
        /// <param name="property">Serializedproperty the object</param>
        /// <param name="requiredType">Required <see cref="System.Type"/> of reference being checked</param>
        private void ChecValues(SerializedProperty property, System.Type requiredType)
        {
            // If the reference is not null and points to an object that does not match the type
            if (property.objectReferenceValue != null && !IsValidObject(property.objectReferenceValue, requiredType))
            {
                // Nullify the reference
                property.objectReferenceValue = null;
            }
        }
    }
}
