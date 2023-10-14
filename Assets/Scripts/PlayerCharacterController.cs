using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] float speed;
    private void Update()
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        //characterController.Move(input * speed * Time. deltaTIme);
        characterController.SimpleMove(input * speed);
    }
}
