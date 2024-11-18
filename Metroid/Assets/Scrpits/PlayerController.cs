using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Bryce DeHart
 * 11/17/2024
 * Desc: this controls the player movement
 */
public class PlayerController : MonoBehaviour
{
    public int fallDepth;
    private Vector3 startPosition;

    public float playerSpeed = 3f;

    //Public Float created by Konner
    public float health = 99f;


    float speedDif;
    float jumpForce = 5f;

    bool isFacingRight = true;

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
            isFacingRight = false;
        }

        if (Input.GetKey(KeyCode.D))
        {

           // rb.AddForce(Vector3.right * playerSpeed, ForceMode.Force);
            deltaMovement.x = 1;
            isFacingRight = true;
        }

        rb.velocity = new Vector3(deltaMovement.x * playerSpeed, rb.velocity.y, rb.velocity.z); 

    }

    private void Update()
    {

        JumpBar();
        FacingRight();
        if (transform.position.y < -10)
        {
            Respawn();
        }


    }
    private void Respawn()
    {
        health--;
        transform.position = startPosition;
    }
    private void JumpBar()
    {
        float raycastDist = 1.2f;

        if (Input.GetKeyDown(KeyCode.W))
        {

            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDist))
            {



            // upwards speeeed
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            }

        }
    }

    void FacingRight()
    {
        if (isFacingRight == false)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (isFacingRight == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);


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
    /// <summary>
    /// This onTrigger respawns the player to new location or respawns if touvhes enemy...By Juan Carrillo
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Respawn();
        }
        //Starts postition for portal on the new level
        if (other.gameObject.tag == "Portal")
        {
            startPosition = other.gameObject.GetComponent<PortalScript>().spawnPoint.transform.position;
        }
        transform.position = startPosition;

    }
}
