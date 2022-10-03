using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(TagSelectorAttribute))]
public class TagSelectorPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var tagList = UnityEditorInternal.InternalEditorUtility.tags;
        string propertyString = property.stringValue;
        int index = 0;
        for (int i = 0; i < tagList.Length; i++)
        {
            if (tagList[i] == propertyString)
            {
                index = i;
                break;
            }
        }
        index = EditorGUI.Popup(position, label.text, index, tagList);
        property.stringValue = tagList[index];
        EditorGUI.EndProperty();
    }
}