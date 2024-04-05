using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement data")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    [Space]
    [SerializeField] private LayerMask whatIsAimMask;
    [SerializeField] private Transform aimTransform;
    
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
        UpdateAim();

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

    private void UpdateAim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, whatIsAimMask) )
        {
            float fixedY = aimTransform.position.y;
            aimTransform.position = new Vector3(hit.point.x, fixedY, hit.point.z);
        }

    }
}
