using System;
using Cinemachine;
using UnityEditor;
using UnityEngine;

namespace Scenes.Editor
{
    [CustomEditor(typeof(Window1))]
    public class Window1Editor : UnityEditor.Editor
    {
        private bool showColumns;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            Window1 _window1 = target as Window1;
            _window1.Name = EditorGUILayout.TextField("姓名", _window1.Name);
            _window1.Age = EditorGUILayout.IntField("年龄", _window1.Age);
            GUI.color = Color.green;
            Rect progressRect = GUILayoutUtility.GetRect(20, 30);
            EditorGUI.ProgressBar(progressRect, _window1.Age / 100f, "Progress");
            GUI.color = Color.white;
            showColumns = EditorGUILayout.Foldout(showColumns, "hideColumns");
            if (showColumns)
            {
                if (_window1.Age < 10)
                {
                    EditorGUILayout.HelpBox("值有点低", MessageType.Warning);
                }
                else if (_window1.Age < 70)
                {
                    EditorGUILayout.HelpBox("值还可以", MessageType.Info);
                }
                else if (_window1.Age < 100)
                {
                    EditorGUILayout.HelpBox("值有点高了", MessageType.Error);
                }
                else if (_window1.Age >= 100)
                {
                    EditorGUILayout.HelpBox("值太高了", MessageType.Error);
                }

                EditorGUILayout.Vector2Field("V2", Vector2.zero);
                EditorGUILayout.Vector3Field("v3", Vector3.zero);
                EditorGUILayout.Vector4Field("v4", Vector4.zero);
                _window1.Age = (int) EditorGUILayout.Slider("SliderValue", _window1.Age, 0, 100);
            }
        }
    }
}