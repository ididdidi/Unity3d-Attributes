using UnityEditor;
using UnityEngine;

namespace UnityExtended
{
    /// <summary>
    /// Drawer for the DisplayProperties attribute
    /// </summary>
    [CustomPropertyDrawer(typeof(DisplayPropertiesAttribute))]
    public class DisplayPropertiesDrawer : PropertyDrawer
    {
        private Editor editor;
        private bool foldout;

        /// <summary>
        /// Overrides GUI drawing for the attribute
        /// </summary>
        /// <param name="position"><see cref="Rect"/> fields to activate validation</param>
        /// <param name="property">Serializedproperty the object</param>
        /// <param name="label">Displaу field label</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {// Check if this is reference type property
            if (property.propertyType != SerializedPropertyType.ObjectReference)
            {
                // If field is not reference, show error message.            
                var style = new GUIStyle(EditorStyles.objectField);
                style.normal.textColor = Color.red;

                // Display label with error message
                EditorGUI.LabelField(position, label, new GUIContent($"{property.propertyType} is not a reference type"), style);
                return;
            }

            // If there is already an editor, add a foldout icon
            if (editor) { foldout = EditorGUI.Foldout(position, foldout, new GUIContent()); }

            // Start blocking change checks
            EditorGUI.BeginChangeCheck();
            // Display a ObjectField
            EditorGUI.ObjectField(position, property, label);
            // If changes were made to the contents of the field,
            // or the reference is empty, there is an editor,
            // or the reference is there but there is no editor
            if (EditorGUI.EndChangeCheck() || (property.objectReferenceValue ^ editor))
            {
                // Create an editor for the object pointed to by the reference, even if reference is empty
                editor = Editor.CreateEditor(property.objectReferenceValue);
            }

            // If foldout is true and the Editor exists
            if (foldout && editor)
            {
                // Draw the properties of an object in a frame
                try
                {
                    GUILayout.BeginVertical(EditorStyles.helpBox);
                    editor.OnInspectorGUI();
                    GUILayout.EndVertical();
                }
                catch (System.ArgumentException e)
                {
                    foldout = false;
                }
            }
        }
    }
}