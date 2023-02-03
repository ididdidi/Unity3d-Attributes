using UnityEngine;

namespace ru.mofrison.unity3d.UnityExtended
{
    public class LabelAttribute : PropertyAttribute
    {
        public string text;

        public LabelAttribute(string label) => this.text = label;
    }
}
