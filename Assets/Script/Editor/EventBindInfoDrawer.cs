using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(EventBindInfo))]
public class EventBindInfoDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        EventBindInfo bindingInfo = property.GetSerializedValue<EventBindInfo>();
        string title = bindingInfo.component == null ? "NULL" : bindingInfo.component.ToString();
        GUIContent titleContent = new GUIContent(title);
        if (property.isExpanded)
        {
            property.isExpanded = EditorGUI.Foldout(new Rect(position.position - new Vector2(0, 20), position.size), property.isExpanded, titleContent, false);
        }
        else 
        {
            property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, titleContent, true);
        }
        if (property.isExpanded)
        {
            var amountRect = new Rect(position.x, position.y + 20, position.width, 20);
            var unitRect = new Rect(position.x, position.y + 40, position.width, 20);

            EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("component"), GUIContent.none);

            SerializedObject o = property.serializedObject;
            Type tO = o.targetObject.GetType();
            PropertyInfo viewModelProperty = tO.GetProperty("ViewModel", BindingFlags.Public | BindingFlags.Instance);
            string typeModel = viewModelProperty.PropertyType.Name;
            SerializedProperty propertyProperty = property.FindPropertyRelative("invokeFunctionName");
            List<string> propertyList = EditorPropertyCache.GetMethodAndPropertys(typeModel, bindingInfo.component.GetType());

            if (propertyList.Count > 0)
            {
                int index = propertyList.IndexOf(propertyProperty.stringValue);
                index = EditorGUI.Popup(unitRect, index, propertyList.ToArray());
                if (index >= 0)
                {
                    propertyProperty.stringValue = propertyList[index];
                }
            }
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (property.isExpanded)
        {
            return 60;
        }

        return 20;
    }
}


