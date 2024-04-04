using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement data")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    
    private Rigidbody rigidBody;
    private float verticalInput;
    private float horizontalInput;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (verticalInput < 0 )
        {
            horizontalInput = -Input.GetAxisRaw("Horizontal");
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = transform.forward * moveSpeed * verticalInput;

        rigidBody.velocity = movement;

        transform.Rotate(0, rotateSpeed * horizontalInput, 0);
    }
}
