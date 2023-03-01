using UnityEngine;
using UnityEditor;

namespace ru.mofrison.unity3d.UnityExtended
{
	/// <summary>
	/// Drawer for the LabelAttribute attribute.
	/// </summary>
	[CustomPropertyDrawer(typeof(LabelAttribute))]
	public class LabelDrawer : PropertyDrawer
	{
		/// <summary>
		/// Overrides GUI drawing for the attribute.
		/// </summary>
		/// <param name="position">Position.</param>
		/// <param name="property">Property.</param>
		/// <param name="label">Label.</param>
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			LabelAttribute labelAttr = attribute as LabelAttribute;
			if (!string.IsNullOrEmpty(labelAttr.text)) { label.text = labelAttr.text; }
			EditorGUI.BeginProperty(position, label, property);
			EditorGUI.PropertyField(position, property, label);
			EditorGUI.EndProperty();
		}
	}
}
