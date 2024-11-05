using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed = 3f;


    float speedDif;
    float maxSpeed = 5f;
    float jumpForce = 5f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //speedDif = maxSpeed - rb.velocity.x;
        //float movement = speedDif * playerSpeed;
        Vector3 deltaMovement = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {

           // rb.AddForce(Vector3.left * playerSpeed, ForceMode.Force);
            deltaMovement.x = -1;

        }

        if (Input.GetKey(KeyCode.D))
        {

           // rb.AddForce(Vector3.right * playerSpeed, ForceMode.Force);
            deltaMovement.x = 1;

        }

        rb.velocity = new Vector3(deltaMovement.x * playerSpeed, rb.velocity.y, rb.velocity.z); 

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }

    }

}
