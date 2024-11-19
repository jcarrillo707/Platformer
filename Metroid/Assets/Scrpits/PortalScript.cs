using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    //game object to determine where player spawns
    public GameObject teleportPoint;
    private void OnTriggerEnter(Collider other)
    {

        other.transform.position = teleportPoint.transform.position;

    }
}
