using UnityEngine;
using System.Collections;


//需生成guid 用于判定
public interface IReferenceableAsset
{
    string GetGuid();

    // Required when checking for duplicate guids.
    void GenerateNewGuid();
}
