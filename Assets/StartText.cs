using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartText : MonoBehaviour
{
    public RectTransform rectTransform;
    public float maxScale = 1.5f;
    public float minScale = 0.5f;
    public float scaleSpeed = 0.02f;
    float x = 1f;
    private bool isIncreasing = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (x > maxScale)
        {
            isIncreasing = false;
        }else if (x < minScale)
        {
            isIncreasing = true;
        }

        rectTransform.localScale = new Vector2(x,x);
    }
    private void FixedUpdate()
    {
        if (isIncreasing)
        {
            x += scaleSpeed;
        }
        else if (!isIncreasing)
        {
            x -= scaleSpeed;
        }
    }
}
