using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 20f;

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
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();

        inputVector = transform.TransformDirection(inputVector);

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
