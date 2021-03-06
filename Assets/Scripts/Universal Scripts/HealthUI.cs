using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Image healthUI;

    void Awake()
    {
        healthUI = GameObject.FindWithTag(Tags.HEALTH_UI).GetComponent<Image>();
    }

    public void DisplayHealth(float value)
    {
        value /= 100f;

        if (value < 0)
            value = 0;

        healthUI.fillAmount = value;
    }
}
