using UnityEngine;
using UnityEditor;

namespace UnityExtended
{
    [CustomPropertyDrawer(typeof(LabelAttribute))]
    public class LabelDrawer : PropertyDrawer
    {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			LabelAttribute labelAttr = attribute as LabelAttribute;
			label.text = labelAttr.text;
			EditorGUI.PropertyField(position, property, label);
		}
	}
}
