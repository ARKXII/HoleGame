using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(MaterialAttribute))]
public class MaterialPropertyDrawer : PropertyDrawer
{
    int _choiceIndex;
    string[] _choices = new string[] { "User1", "User2" };

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty userIndexProperty = property.FindPropertyRelative("UserIndex");

        EditorGUI.BeginChangeCheck();
        _choiceIndex = EditorGUI.Popup(position, userIndexProperty.intValue, _choices);
        if (EditorGUI.EndChangeCheck())
        {
            userIndexProperty.intValue = _choiceIndex;
        }
    }
}
