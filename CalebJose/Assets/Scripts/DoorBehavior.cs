/*****************************************************************************
// File Name : DoorBehavior.cs
// Author : Jose Becerra
// Last Edited by : Jose Becerra
// Creation Date : April 6, 2023
//
// Brief Description : This is the original code used to animate and open doors
when a player is triggering a button, and clicks X on the controller to 
interact. We have since changed to ButtonScript that will handle opening doors.  
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    // Creates public variables for the door, Animator, and creates a private
    // bool that will determine whether or not a player is on a button.

    // public static Animator animator;
    /* [SerializeField] public DoorBehavior Door;
    private static bool doorTrigger = false; */


    // On Awake, animator variable = Animator
    /** private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    // When a player triggers a button...
    private void OnTriggerEnter2D(Collider2D collision)
    {
    // If the collision that activates the trigger has the tag "Player"
        if (collision.gameObject.tag == "Player")
        {

        // The boolean is true, and the console will read "you are on a button"
            doorTrigger = true;
            Debug.Log("you are on a button");
        }
    }

    // Open Door statement that will set the parameter in the animator to true
    // if the bool is true, meaning the player is on the button.
    public static void OpenDoor()
    {
        if (doorTrigger == true)
        {
            Animator.SetBool("Open", true);
        }
    }*/

}
    