using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 20f;
    [SerializeField] private float momentumDamping = 5f;

    private CharacterController characterController;
    private Animator animator;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float gravity = -10f;

    private bool isWalking;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GetInput();
        MovePlayer();
        CheckPlayerMovement();
        animator.SetBool("IsWalking", isWalking);
    }

    private void GetInput()
    {
        // if we are holding down WASD 
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);
        }
        else
        {
            // if we are not lerp it towards zero
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentumDamping * Time.deltaTime);
        }
        
        movementVector = (inputVector * playerSpeed) + (Vector3.up * gravity);
    }

    private void MovePlayer()
    {
        characterController.Move(movementVector * Time.deltaTime);
    }

    private void CheckPlayerMovement()
    {
        if (characterController.velocity.magnitude > 0.1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }
}
