using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableTest : ScriptableObject
{
    [MenuItem("MyMenu/TT1")]
    public static void printPath()
    {
        Debug.Log($"persistener Path: {Application.persistentDataPath}");
    }
}
