using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement data")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    [Header("Tower data")]
    [SerializeField] private Transform tankTowerTransform;
    [SerializeField] private float towerRotationSpeed;

    [Header("Aim data")]
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
        CheckInputs();
    }

    private void CheckInputs()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (verticalInput < 0)
        {
            horizontalInput = -Input.GetAxisRaw("Horizontal");
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        ApplyBodyRotation();
        ApplyTowerRotation();
    }

    private void ApplyTowerRotation()
    {
        Vector3 direction = aimTransform.position - tankTowerTransform.position;
        direction.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        tankTowerTransform.rotation = Quaternion.RotateTowards(tankTowerTransform.rotation, targetRotation, towerRotationSpeed);
    }

    private void ApplyBodyRotation()
    {
        transform.Rotate(0, rotateSpeed * horizontalInput, 0);
    }

    private void ApplyMovement()
    {
        Vector3 movement = transform.forward * moveSpeed * verticalInput;
        rigidBody.velocity = movement;
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
