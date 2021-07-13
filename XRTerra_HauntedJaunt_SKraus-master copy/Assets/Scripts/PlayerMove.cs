using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Animator animator;
    Vector3 movement;

    Rigidbody rigidbody;

    public float turnSpeed = 10f; 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public void onMovement(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        inputVector.Normalize();

        movement.Set(inputVector.x, 0, inputVector.y);

        bool isWalking = (movement.magnitude > 0.1f);

        animator.SetBool("isWalking", isWalking);
    }

    public void OnAnimatorMove()
    {
        rigidbody.MovePosition(rigidbody.position + movement * animator.deltaPosition.magnitude);

        Vector3 desiredRotation = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);

        Quaternion rotation = Quaternion.LookRotation(desiredRotation);

        rigidbody.MoveRotation(rotation);
    }

}

