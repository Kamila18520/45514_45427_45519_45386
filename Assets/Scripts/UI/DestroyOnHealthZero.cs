using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyOnHealthZero : MonoBehaviour
{
    [SerializeField] HealthComponent healthComponent;

    private void Awake()
    {
        healthComponent.Health.OnValueChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        healthComponent.Health.OnValueChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float lastValue)
    {
        if (lastValue > 0 && healthComponent.Health.Value <= 0)
            Destroy(gameObject);
    }

}













