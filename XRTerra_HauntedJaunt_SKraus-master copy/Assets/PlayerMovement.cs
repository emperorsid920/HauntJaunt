using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    void onMovement(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        inputVector.Normalize();

        movement.Set(inputVector.x, 0, inputVector.y);

        bool isWalking = (movement.magnitude > 0.1f);
    }
  
}

