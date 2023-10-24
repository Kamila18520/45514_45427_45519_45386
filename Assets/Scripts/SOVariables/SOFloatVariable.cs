using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "SOFloatVariable", menuName = "SOVariables/SOFloatVariable")]

public class SOFloatVariable : ScriptableObject
{
    [SerializeField] public EventableType<float> Variable;


#if UNITY_EDITOR
        [Header("Debug Value")]
        [SerializeField] private float debugHealthDiff;

        [ContextMenu("Invoke AddDebugValueDiff")]
        private void InvokeOnValueChangedEditor()
        {
        Variable.Value += debugHealthDiff;
        }
#endif
}

