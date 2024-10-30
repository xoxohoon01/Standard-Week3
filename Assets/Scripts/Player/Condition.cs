using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float currentValue;
    public float maxValue;
    public float startValue;
    public float passiveValue;
    public Image uiBar;

    public void Start()
    {
        currentValue = startValue;
    }
    private void Update()
    {
        if (uiBar != null)
        {
            uiBar.fillAmount = GetPercentage();
        }
    }

    public void Add(float amount)
    {
        currentValue = Mathf.Min(currentValue + amount, maxValue);
    }
    public void Subtract(float amount)
    {
        currentValue = Mathf.Min(currentValue - amount, maxValue);
    }
    public float GetPercentage()
    {
        return currentValue / maxValue;
    }
}
