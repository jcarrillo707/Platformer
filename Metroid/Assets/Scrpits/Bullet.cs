using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Bryce DeHart
 * 11/17/2024
 * Desc: Bullet's script
 */
public class Bullet : MonoBehaviour
{
    public float speed = 1;
    public float damage = 1;
    public bool isGoingRight;

    void Start()
    {

       Destroy(gameObject, 1);

    }


    void Update()
    {
        BulletMove();

    }

    // the movement script for the bullet
    void BulletMove()
    {
        if (isGoingRight == false)
        {

            transform.position += speed * Vector3.left * Time.deltaTime;

        }
        else
        {

            transform.position += speed * Vector3.right * Time.deltaTime;

        }
    }

    // this is where you would have it change the enemy health
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        
    }
}
