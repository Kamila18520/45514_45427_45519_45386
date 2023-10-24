using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour, IDamagable
{
    [Header("Variable")]
    [SerializeField] SOFloatVariable variableHealth;
    [SerializeField] SOFloatVariable variableHealthMax;

    [SerializeField] EventableType<float> health;
    [SerializeField] EventableType<float> healthMax;

    private void Awake()
    {
        health.Value = healthMax.Value;

       if (variableHealth)
        {
            health.OnValueChanged += (old) => variableHealth.Variable.Value = health.Value;
            variableHealth.Variable.Value = health.Value;
        }


        if (variableHealthMax)
        {
            healthMax.OnValueChanged += (old) => variableHealthMax.Variable.Value = healthMax.Value;
            variableHealthMax.Variable.Value = healthMax.Value;
        }
    }
    public bool AddDamage(float damage)
    {
        health.Value -= damage;
        return true;
    }

     


#if UNITY_EDITOR
        [Header("Debug Health")]
        [SerializeField] private float debugHealthDiff;

        [ContextMenu("Invoke AddDebugHealthDiff")]
        private void InvokeOnHealthChangedEditor()
        {
        health.Value += debugHealthDiff;
        }
#endif
}