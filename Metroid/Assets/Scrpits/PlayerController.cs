using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    void Start()
    {
        
    }
    void Update()
    {
        Debug.Log (Input.GetAxisRaw("Horizontal"));
    }
}
