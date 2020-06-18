using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //ContextMenu 注释方法 CreateAssetMenu (menuItem("Assets/menuItem"))
    [ContextMenu("TT2")]
    public void printPath1()
    {
        Debug.Log($"persistener Path: {Application.persistentDataPath}");
    }
}
