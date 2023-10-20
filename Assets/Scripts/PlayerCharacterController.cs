using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] float speed;

   
    private void Update()
    {
        //var movementValue = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        var camera = Camera.main;
        var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        input = camera.transform.TransformDirection(input);

        characterController.SimpleMove(input * speed);

        var ray = camera.ScreenPointToRay(Input.mousePosition);
        var plane = new Plane(transform.up, transform.position);

        float distance;
        if(plane.Raycast(ray, out distance)) 
        {
            Vector3 hitPoint = ray.GetPoint(distance);
            transform.forward = hitPoint - transform.position;
        
        }

     //  movementValue *= velocity;
     //  movementValue *= Time.deltaTime;
        //characterController.Move(input * speed * Time. deltaTIme);
        // characterController.SimpleMove(movementValue * speed);

     //  characterController.Move(new Vector3(movementValue.x, yMovement * Time.deltaTime, movementValue.y));
     //  if(characterController.velocity.sqrMagnitude > 0.1)
     //      transform.forward = new Vector3(movementValue.x, 0f, movementValue.y);
     //  
     //  if(Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded) 
     //      yMovement = 10f;
     //
     //      yMovement = Mathf.Max(-9.81f, yMovement - Time.deltaTime * fallJumpModif);
     //  
        
    }
}
