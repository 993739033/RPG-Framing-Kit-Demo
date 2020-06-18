using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[RequireComponent(typeof(Button))]
public class DisableButtonOnEmptyStrings : MonoBehaviour
{
    private Button button;

    [SerializeField]
    private StringVariable[] strings;

    private void Awake()
    {
        button = this.GetComponent<Button>();
    }

    public void Verify ()
    {
        //判断输入的名称及农场名是否有空值
        button.interactable = strings.All(s => !string.IsNullOrEmpty(s.Value));
    }
}
