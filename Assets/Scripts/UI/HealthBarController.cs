using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Slider slider;

    [Header("To Override In Other Prefab")]
    [SerializeField] HealthComponent healthComponent;

    private void Awake()
    {
        healthComponent.Health.OnValueChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        healthComponent.Health.OnValueChanged += OnHealthChanged;
    }

    private void OnHealthChanged(float oldValue)
    {
        slider.value = healthComponent.Health.Value / healthComponent.HealthMax.Value;
        canvas.enabled = true;
        StartCoroutine(Hide(4f));
    }

    IEnumerator Hide(float timer)
    {
        yield return new WaitForSeconds(timer);
        canvas.enabled = false;

    }

}





