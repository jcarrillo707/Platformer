using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    Rigidbody rb;

    float horizontalMove = 0f;

    public float runSpeed = 6f;
    public float jumpSpeed = 6f;

    bool jump = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        controller = GetComponent<CharacterController>();

    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            rb.velocity 

        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime * Vector3.right);



    }
}
