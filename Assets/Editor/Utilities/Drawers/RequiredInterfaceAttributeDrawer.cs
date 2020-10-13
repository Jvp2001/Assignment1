using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Utilities.Attributes;

namespace InteractionSystem
{
    [CustomPropertyDrawer(typeof(RequiredInterfaceAttribute))]
    public class RequiredInterfaceAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var requiredInterfaceAttribute = attribute as RequiredInterfaceAttribute;

            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                EditorGUI.BeginProperty(position, label, property);

                property.objectReferenceValue = EditorGUI.ObjectField(position, label, property.objectReferenceValue,
                    requiredInterfaceAttribute.RequiredType, true);
                UnityEngine.Object obj = EditorGUI.ObjectField(position, label, property.objectReferenceValue,
                    typeof(UnityEngine.Object), true);

                property.tooltip.Insert(0,
                    $"Has to have a component which implements {requiredInterfaceAttribute.RequiredType.Name}\n");


                if (obj is GameObject gameObject)
                    property.objectReferenceValue = gameObject.GetComponent(requiredInterfaceAttribute.RequiredType);

                EditorGUI.EndProperty();
            }
            else
            {
                // Draw error label saying that this object does not implement the required interface.

                var previousColour = GUI.color;
                GUI.color = Color.red;
                EditorGUI.LabelField(position, label,
                    new GUIContent(
                        $"Must be a reference Type.\nDoes Not Implement Interface: {requiredInterfaceAttribute.RequiredType.Name}"));
                Debug.Log("RI: ERROR");
                GUI.color = previousColour;
            }
        }
    }
}