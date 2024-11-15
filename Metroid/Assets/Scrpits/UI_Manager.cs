using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

/*
* Author: Rooney, Konner
* Date Created: 11/6/2024
* This script handles UI elements
*/

public class UI_Manager : MonoBehaviour
{

    public PlayerController livingholder;
    public TMP_Text healthText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HP: " + livingholder.health;
    }
}
