using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed = 10f;


    float speedDif;
    float maxSpeed = 20f;


    Rigidbody rb;

    private void Update()
    {
        speedDif = maxSpeed - rb.velocity.x;


        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speedDif);


        }



    }


}
