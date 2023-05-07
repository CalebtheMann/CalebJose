/*****************************************************************************
// File Name : DoubleButtonScript.cs
// Author : Jose Becerra
// Last Edited by : Caleb Purnell
// Creation Date : April 6, 2023
//
// Brief Description : This script will open doors when two buttons are
neccesary to open it
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleButtonScript1 : MonoBehaviour
{
    // Creates two door objects and references PlayerScript
    public GameObject Door1;
    public GameObject Door2;
    private PlayerScript sp_;
    public bool Button1 = false;
    public bool Button2 = false;
    public AudioClip ButtonActivate;

    /// <summary>
    /// Open function that will open the door
    /// </summary>
    public void Open()
    {
        // Find object of type PlayerScript
        foreach (PlayerScript p in FindObjectsOfType<PlayerScript>())
        {
            if (PlayerScript.Button1 == true && PlayerScript.Button2 == true)
            {
                // Destroy both doors
                Destroy(Door1);
                Destroy(Door2);
                AudioSource.PlayClipAtPoint(ButtonActivate, transform.position, 3f);
                PlayerScript.Button1 = false;
            }
        }            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerScript.Button1 = true;
        }
    }

}
