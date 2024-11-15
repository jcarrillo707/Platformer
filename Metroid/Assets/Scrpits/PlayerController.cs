using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed = 3f;

    //Public Float created by Konner
    public float health = 99f;


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

        JumpBar();

        

    }

    private void JumpBar()
    {
        float raycastDist = 1.2f;

        if (Input.GetKeyDown(KeyCode.Space))
        {

            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDist))
            {



            // upwards speeeed
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            }

        }
    }

    // Public Void by Konner
    /// <summary>
    /// When the player's health equals 0, the scene switches to the Game Over Screen.
    /// </summary>
    public void Loss()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
