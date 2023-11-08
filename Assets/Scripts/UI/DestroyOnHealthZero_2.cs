using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHealthZero_2 : MonoBehaviour
{
    [SerializeField] HealthComponent healthComponent;
    [SerializeField] float teleportRange = 10.0f;

    private bool isTeleporting = false;

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
        if (lastValue > 0 && healthComponent.Health.Value <= 0 && !isTeleporting)
        {
            isTeleporting = true;
            TeleportToRandomPosition();
            healthComponent.Health.Value = healthComponent.HealthMax.Value;
        }
    }

    private void TeleportToRandomPosition()
    {
        Vector3 randomPosition = GetRandomUnoccupiedPosition();
        transform.position = randomPosition;
        isTeleporting = false;
    }

    private Vector3 GetRandomUnoccupiedPosition()
    {
        Vector3 randomPosition = Vector3.zero;
        int maxAttempts = 10;
        int currentAttempts = 0;

        do
        {
            float randomX = UnityEngine.Random.Range(-teleportRange, teleportRange);
            float randomZ = UnityEngine.Random.Range(-teleportRange, teleportRange);

            randomPosition = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

            currentAttempts++;
        } while (IsPositionOccupied(randomPosition) && currentAttempts < maxAttempts);

        return randomPosition;
    }

    private bool IsPositionOccupied(Vector3 position)
    {
        // U¿yj Raycasta, aby sprawdziæ, czy pozycja jest zajêta przez inny obiekt.
        RaycastHit hit;
        if (Physics.Raycast(position, Vector3.down, out hit))
        {
            // Jeœli trafiono coœ innego ni¿ ten obiekt, uznaj to za zajêt¹ pozycjê.
            if (hit.collider.gameObject != gameObject)
            {
                return true;
            }
        }

        return false;
    }
}