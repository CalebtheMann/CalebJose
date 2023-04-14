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

public class DoubleButtonScript : MonoBehaviour
{
    // Creates two door objects and references PlayerScript
    public GameObject Door1;
    public GameObject Door2;
    private PlayerScript sp_;

    /// <summary>
    /// Open function that will open the door
    /// </summary>
    public void Open()
    {
        // Find object of type PlayerScript
        sp_ = FindObjectOfType<PlayerScript>();

        // if Button1 and Button2 are true
        if (sp_.Button1 == true && sp_.Button2 == true)
        {
            // Destroy both doors
            Destroy(Door1);
            Destroy(Door2);
        }
    }

}
