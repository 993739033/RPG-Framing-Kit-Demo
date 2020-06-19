using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Farming Kit/User Interface/Sprite Fader")]
[RequireComponent(typeof(SpriteRenderer)), DisallowMultipleComponent]
//alpha 渐变
public class SpriteFader : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float transitionTime = 0.5f;

    private Coroutine fadeCoroutine;


    private void OnValidate()
    {
    
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    public void SetAlpha(float alpha)
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        fadeCoroutine = StartCoroutine(TransitionColor(new Color(1, 1, 1, alpha)));
    }

    //instant瞬间
    public void SetAlphaInstant(float alpha)
    {
        //停到所有当前behavir中的所有协程
        StopAllCoroutines();
        spriteRenderer.color = new Color(1, 1, 1, alpha);
    }

    IEnumerator TransitionColor(Color targetColor)
    {
        float t = 0;

        Color currentColor = spriteRenderer.color;

        while (t != transitionTime)
        {
            spriteRenderer.color = Color.Lerp(currentColor, targetColor, t / transitionTime);
            t += Time.deltaTime;
            yield return null;
        }
    }
}
