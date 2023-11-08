using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour, IDamagable
{
    [field: SerializeField] public EventableType <float> Health { get; private set; }
    [field: SerializeField] public EventableType <float> HealthMax { get; private set; }

    [Header("Variable")]
    [SerializeField] SOFloatVariable variableHealth;
    [SerializeField] SOFloatVariable variableHealthMax;

    

    private void Awake()
    {
        // Debug.LogError("HealthComponent");
        Health.Value = HealthMax.Value; 

       if (variableHealth)
        {
           
            variableHealth.Variable = Health;
        }


        if (variableHealthMax)
        {
           
            variableHealthMax.Variable = HealthMax;
        }
    }
    public bool AddDamage(float damage)
    {
        Health.Value -= damage;
        return true;
    }

     


#if UNITY_EDITOR
        [Header("Debug Health")]
        [SerializeField] private float debugHealthDiff;

        [ContextMenu("Invoke AddDebugHealthDiff")]
        private void InvokeOnHealthChangedEditor()
        {
        Health.Value += debugHealthDiff;
        }
#endif
}