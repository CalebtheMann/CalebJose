/*****************************************************************************
// File Name : ButtonScript.cs
// Author : Jose Becerra
// Last Edited by : Caleb Purnell
// Creation Date : April 6, 2023
//
// Brief Description : This script will control the buttons and will open the
doors when any of the players interact with the button
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyButtonScript : MonoBehaviour
{
    // Creates a door game object, the animator for the door, and references
    // PlayerScript
    public GameObject Door;
    public DoorBehavior Animator;
    [HideInInspector] public PlayerScript _ps;
    public AudioClip ButtonActivate;

    /// <summary>
    /// Open Door function that gets referenced in PlayerController
    /// </summary>
    public void OpenDoor()
    {
        // foreach loop that checks for any objects of type PlayerScript
        foreach (PlayerScript p in FindObjectsOfType<PlayerScript>())
        {
            //Debugs which door is being opened
            Debug.Log(Door);

            // DoorTrigger is true for the player on the button
            if (p.DoorTrigger == true)
            {
                // DoorBehavior.Animator.SetBool("Open", true);

                // Destroy the door and debug OpenDoor
                Debug.Log("stop pls");
                Debug.Log("OpenDoor");
                Destroy(Door);
                PlayerScript.EnemySpawn = false;
                PlayerScript.EnemySpawn2 = false;
                AudioBehavior.Source.PlayOneShot(ButtonActivate);
            }
        }
    }
}
