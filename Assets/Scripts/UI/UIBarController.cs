using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBarController : MonoBehaviour
{
    Slider slider;
    [SerializeField] SOFloatVariable variable;
    [SerializeField] SOFloatVariable variableMax;

    private void Awake()
    {
        Debug.LogError("UIBarController");

        slider = GetComponentInChildren<Slider>();
        variable.Variable.OnValueChanged += OnValueChanged;
        variableMax.Variable.OnValueChanged += OnValueChanged;
        variableMax.Variable.OnValueChanged += OnMaxValueChanged;
        OnMaxValueChanged(0f);
        OnValueChanged(0f);

    }

    private void OnDestroy()
    {
        variable.Variable.OnValueChanged -= OnValueChanged;
        variableMax.Variable.OnValueChanged -= OnValueChanged;
        variableMax.Variable.OnValueChanged -= OnMaxValueChanged;

    }

    private void OnValueChanged(float old)
    {
        slider.value = variable.Variable.Value;
        //slider.value = variable.Variable.Value / variableMax.Variable.Value;
    }

    private void OnMaxValueChanged(float old)
    {
        slider.maxValue = variableMax.Variable.Value;
    }
       
}