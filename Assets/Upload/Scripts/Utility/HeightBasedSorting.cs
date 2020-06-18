using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// Sorts the attached sorting group based on the Y axis.
/// </summary>

[AddComponentMenu("Farming Kit/User Interface/Height Based Sorting")]
[RequireComponent(typeof(SortingGroup)), DisallowMultipleComponent]
//根据y值手动设置sort值
public class HeightBasedSorting : MonoBehaviour, IMove
{
    [SerializeField]
    private SortingGroup sortingGroup;

    [SerializeField]
    private float positionScaling = -100;

    [SerializeField]
    private bool flip;

    //这两种模式下回调
    //脚本被加载时
    //Inspector 中的任何值被修改时
    private void OnValidate()
    {
        if (sortingGroup == null)
        {
            sortingGroup = GetComponent<SortingGroup>();
        }

        UpdateOrder();
    }

    private void Start()
    {
        UpdateOrder();
    }

    public void OnMove(Vector2 direction, float velocity)
    {
        UpdateOrder();
    }

    private void UpdateOrder()
    {
        if (sortingGroup != null)
        {
            sortingGroup.sortingOrder = (int)(transform.position.y * positionScaling);
        }
    }
}
