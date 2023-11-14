using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaceablePlacer : MonoBehaviour
{
    [SerializeField] float placeDistance = 1f;
    [SerializeField] GameObject prefabToPlace;
    [SerializeField] GameObject objectToPlaceGhost;
    [Header("Place Settings")]
    [SerializeField] LayerMask layerMask;

    enum State { Idle, Placing }
    State currentState = State.Idle;
    readonly Collider[] overlapBoxResult = new Collider[1];

    public Vector3 DebugCheckPosition;
    public bool DebugIsCheckPositionFree;

    void Update()
    {
        SelectCorrectState();
        if (currentState == State.Placing)
            PlacingUpdate();
    }

    private void SelectCorrectState()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switch (currentState)
            {
                case State.Idle:
                    currentState = State.Placing;
                    break;
                case State.Placing:
                    currentState = State.Idle;
                    break;
            }
        }
    }

    private void PlacingUpdate()
    {
        Vector3Int checkPosition = Vector3Int.FloorToInt(transform.position + transform.forward * placeDistance);
        Vector3 boxCastPosition = checkPosition + Vector3.up * 0.05f;
        
        int collidersCount = Physics.OverlapBoxNonAlloc(boxCastPosition, Vector3.zero, overlapBoxResult, Quaternion.identity, layerMask, QueryTriggerInteraction.Collide);
        bool gridIsFree = collidersCount == 0;

        if (gridIsFree && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefabToPlace, checkPosition, Quaternion.identity);
        }

        DebugIsCheckPositionFree = gridIsFree;
        DebugCheckPosition = boxCastPosition;
    }

    private void OnDrawGizmos()
    {
        if (currentState == State.Placing)
        {
            Gizmos.color = DebugIsCheckPositionFree ? Color.green : Color.red;
            Gizmos.DrawCube(DebugCheckPosition, Vector3.one);
        }
    }
}
