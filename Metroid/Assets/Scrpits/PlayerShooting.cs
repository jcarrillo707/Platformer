using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Bryce DeHart
 * 11/17/2024
 * Desc: this controls the player shooting and several checks related to it
 */
public class PlayerShooting : MonoBehaviour
{
    [Header("Projectile Variables")]
    public GameObject projectilePrefab;
    public GameObject projectilePrefabUpgrade;
    public float speed = 1;
    public float shotDelay;
    public bool isGoingRight = true;
    public bool upgrade;

    public GameObject player;

    bool cooldown;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {

            isGoingRight = false;

        }

        if (Input.GetKey(KeyCode.D))
        {

            isGoingRight = true;

        }

        SpaceShot();

        upgrade = player.GetComponent<PlayerController>().gunCheck;


    }

    // the way projectiles are spawned and checking direction as well as checking if the upgrade has been obtained
    public void SpawnProjectile()
    {
        if (upgrade == false)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);


            projectile.GetComponent<Bullet>().isGoingRight = isGoingRight;
        }

        if (upgrade == true)
        {
            GameObject projectile = Instantiate(projectilePrefabUpgrade, transform.position, projectilePrefab.transform.rotation);


            projectile.GetComponent<Bullet>().isGoingRight = isGoingRight;
        }

    }

    void SpaceShot()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (cooldown == false)
            {
                SpawnProjectile();

                StartCoroutine(ShotDelay());
        
            
            }
        }
            



    }

    private IEnumerator ShotDelay()
    {
        cooldown = true;

        yield return new WaitForSeconds(shotDelay);


        cooldown = false;

    }
}
