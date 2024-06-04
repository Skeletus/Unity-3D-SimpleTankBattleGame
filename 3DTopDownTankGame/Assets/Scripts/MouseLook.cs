using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float smoothing = 10f;
    [SerializeField] private float sensitivy = 1.5f;

    private float xMousePosition;
    private float smoothedMousePosition;
    private float currentLookPosition;

    private void Start()
    {
        // lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }

    private void GetInput()
    {
        xMousePosition = Input.GetAxisRaw("Mouse X");
    }

    private void ModifyInput()
    {
        xMousePosition *= sensitivy * smoothing;
        smoothedMousePosition = Mathf.Lerp(smoothedMousePosition, xMousePosition, 1f/smoothing);
    }

    private void MovePlayer()
    {
        currentLookPosition += smoothedMousePosition;
        transform.localRotation = Quaternion.AngleAxis(currentLookPosition, transform.up);
    }
}
