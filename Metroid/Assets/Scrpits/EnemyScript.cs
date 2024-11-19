using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Carrillo Juan
 * 10/31/2024
 * Desc: this controls the enemy movement
 */

public class EnemyScript : MonoBehaviour
{
    public GameObject leftpoint;
    public GameObject rightpoint;
    private Vector3 leftpos;
    private Vector3 rightpos;
    public bool goingLeft;
    public int speed;
    public float enemyHealth = 1;
    public float enemyDamage = 15;


    // Start is called before the first frame update
    void Start()
    {
        leftpos = leftpoint.transform.position;
        rightpos = rightpoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        EnemyLife();
    }


    //This controls the postition for the enemy going left to right.
    public void Move()
    {
        if (goingLeft)
        {
            if (transform.position.x <=leftpos.x)
            {
                goingLeft = false;
             } 
            else
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
        }
        else 
        {
            if (transform.position.x >= rightpos.x)
            {
                goingLeft = true;
            }
            else
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }

    }

    // Adding capabilities for bullets to deal damage to the enemy.

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            enemyHealth -= collision.gameObject.GetComponent<Bullet>().damage;

        }
    }


    // when enemies die they are destroyed  -bryce
    public void EnemyLife()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }



}

