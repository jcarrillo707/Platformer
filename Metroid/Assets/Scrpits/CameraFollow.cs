using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Bryce DeHart
 * 11/17/2024
 * Desc: this is a script to have the camera follow the player, just attaching it to the player caused it to rotate with the player when going left or right
 */
public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(player.transform.position.x +3, player.transform.position.y, player.transform.position.z - 10 );
    }


}
