using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//包含一组前后左右图像
[System.Serializable, CreateAssetMenu]
public class BodyData : ScriptableAsset
{
    public List<Sprite> side = new List<Sprite>();
    public List<Sprite> front = new List<Sprite>();
    public List<Sprite> back = new List<Sprite>();

    public BodyData subItem;
}