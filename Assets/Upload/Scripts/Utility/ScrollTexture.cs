using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[AddComponentMenu("Farming Kit/User Interface/Scroll Texture")]
[RequireComponent(typeof(RawImage))]
public class ScrollTexture : UIBehaviour
{
    [SerializeField]
    private RawImage target;

    [SerializeField] private Vector2 direction;

    private Vector2 baseSize;

    [SerializeField]
    private Vector2 offset;

    [SerializeField]
    private bool repeatX;

    [SerializeField]
    private bool repeatY;

    protected override void Awake()
    {
        target.material = new Material(target.material);
    }

    void Update ()
    {
        offset += direction * Time.deltaTime;
        target.uvRect = new Rect(offset,target.uvRect.size);
        
//      target.material.SetTextureOffset("_MainTex", offset);
    }

    //sizedelta 表示ui各边缘里锚点相同方向各边的距离的和 rectTransform.rect.size 表示ui的宽高
    //OnRectTransformDimensionsChange 在运行时调用
    protected override void OnRectTransformDimensionsChange()
    {
        Debug.Log("OnRecctTransformDimensionChange");
        if (baseSize.x == 0 || baseSize.y == 0)
        {
            baseSize = target.rectTransform.sizeDelta;                                                           
        }

        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 sizeDifference = screenSize - baseSize;

        float xDifference = (repeatX)? sizeDifference.x / baseSize.x : 0;
        float yDifference = (repeatY)? sizeDifference.y / baseSize.y : 0;

        Rect newRect = target.uvRect;

        newRect.width = 1 + (xDifference);
        newRect.height = 1 + (yDifference);

        target.rectTransform.sizeDelta = baseSize + sizeDifference;
        target.uvRect = newRect;
    }
}
