using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] float health = 1000;
    public Action<float, float> OnHealthChaged;
    public float Health
    {
        get => health;
        private set
        {
            if(health == value) 
                return;

            var oldHealth = health;
            health = value;
            OnHealthChaged.Invoke(oldHealth, health);
        }
    }






}
