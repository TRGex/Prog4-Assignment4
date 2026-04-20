using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void MovementInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }
    private void Move()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.transform.Translate(moveDirection * 0.25f);
    }
}
