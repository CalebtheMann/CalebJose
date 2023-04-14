/*****************************************************************************
// File Name : MainMenuController.cs
// Author : Jose Becerra
// Last Edited by : Jose Becerra
// Creation Date : April 6, 2023
//
// Brief Description : This script will control the main menu and what happens
when the buttons are clicked.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Creates a MainMenu GameObject
    public GameObject mainMenu;

    /// <summary>
    /// Start Game function with the parameter int sceneToLoad, the number that 
    /// goes in the parameter will be the number of the scene that will be loaded
    /// when start is pressed
    /// </summary>
    /// <param name="sceneToLoad"></param>
    public void StartGame(int sceneToLoad)
    {
        // Load whichever number scene is inputted
        SceneManager.LoadScene(sceneToLoad);
    }

    /// <summary>
    /// QuitGame function that will allow players to quit the game in the main
    /// menu as well as debug that the player has quit the game. It will also
    /// set the main menu object to false, allowing other menus like the options
    /// or how to play menu to be set on and off
    /// </summary>
    public void QuitGame()
    {
        // Quit the game, debug, set object active as false by default
        Application.Quit();
        Debug.Log("Quit the Game!");
        mainMenu.SetActive(false);
    }
}
