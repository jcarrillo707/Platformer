using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* Author: Rooney, Konner
* Date Created: 11/7/2024
* This script handles the transition from the gameplay scene to the game over screen scene upon the player losing all of their health
*/

public class EndGame_Screen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Closes/quits the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("I Quit");
    }

    /// <summary>
    /// The direct handler of the scene transition in the event of a player's health hitting zero
    /// </summary>
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
