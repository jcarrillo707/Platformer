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
    public float hitTime = 5;
    float blinkTime = 0.5f;


    float speedDif;
    public float jumpForce = 5f;
    public MeshRenderer mesh;

    bool isFacingRight = true;
    bool hitToggle = false;
    public bool gunCheck = false;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.GetComponent<MeshRenderer>();
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

        Loss();
    }
    
    /*
    private void Respawn()
    {
        //health--;
        transform.position = startPosition;
    }
    */
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

    //checker for if the thing is an enemy or an item
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (hitToggle == false)
            {

                health = health - collision.gameObject.GetComponent<EnemyScript>().enemyDamage; 
                StartCoroutine(NoHits());
                StartCoroutine(Blinking());

            }
        }

        if (collision.gameObject.GetComponent<HealthPack>())
        {
            Destroy(collision.gameObject);

            health = health + 25;

            if (health > 99)
            {

                health = 99;

            }
        }

        if (collision.gameObject.GetComponent<HeavyGunUpgrade>())
        {
            gunCheck = true;

            Destroy(collision.gameObject);

            if (gunCheck == false)
            {
                //boo womp
            }
        }

    }
    // The timers for the hitting functionality

    private IEnumerator NoHits()
    {
        hitToggle = true;

        yield return new WaitForSeconds(hitTime);

        hitToggle = false;
    }
    
    private IEnumerator Blinking()
    {
        for (int i = 0; i < 6; i++)
        {
        mesh.enabled = !mesh.enabled;

        yield return new WaitForSeconds(blinkTime);

        mesh.enabled = mesh.enabled;

        yield return new WaitForSeconds(blinkTime);
        }


    }
}
