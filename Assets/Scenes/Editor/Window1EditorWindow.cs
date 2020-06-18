using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Window1EditorWindow : EditorWindow
{
    [MenuItem("MyEditor/CreateWidnow")]
    static void addWindow()
    {
        Rect wr = new Rect(0, 0, 500, 500);
        Window1EditorWindow editorWindow =
            EditorWindow.GetWindowWithRect<Window1EditorWindow>(wr, true, "CreateWindow");
        editorWindow.Show();
    }

    String text = "Image";
    String saveDir = "Assets/Captures/";
    private void OnGUI()
    {
        text = EditorGUILayout.TextField("输入文字：", text);
        if (GUILayout.Button("打开通知", GUILayout.Width(200)))
        {
            this.ShowNotification(new GUIContent("this is notification"));
        }

        if (GUILayout.Button("close", GUILayout.Width(200)))
        {
            this.Close();
        }

        if (GUILayout.Button("SaveCapture", GUILayout.Width(200)))
        {
            saveCaptureImg();
        }
    }
    

    private void saveCaptureImg()
    {
        Directory.CreateDirectory(saveDir);
        ScreenCapture.CaptureScreenshot(saveDir + text + ".jpg");
    }
}