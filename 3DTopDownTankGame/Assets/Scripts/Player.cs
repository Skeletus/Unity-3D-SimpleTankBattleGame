using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movement;
    [SerializeField] private Rigidbody rigidBody;

    [SerializeField] private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector3 (0, 0, movement * verticalInput);
    }
}
