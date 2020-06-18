using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif
public interface  ISaveable
{
    //返回保存的json字符串
    /// <param name="saveSystem"> JSON data</param>
    string OnSave();

    //加载json中的数据
    /// <param name="saveSystem"> JSON data</param>
    void OnLoad(string data);

    //判断是否可以保存 如判断保存数据未发生改变不进行存储
    /// <summary>
    /// Returning true will allow the save to occur, else it will skip the save
    /// </summary>
    bool OnSaveCondition();
}