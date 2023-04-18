/*****************************************************************************
// File Name : PlayerScript.cs
// Author : Jose Becerra
// Last Edited by : Caleb Purnell
// Creation Date : April 6, 2023
//
// Brief Description : This script will control the player and how they behave 
in relation to objects around them.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour

{
    // public variables for the enemy object, the doortrigger bool, the buttons,
    // and the enemies spawn position

    public GameObject Enemy;
    //public Transform SpawnLocation;
    public bool DoorTrigger = false;
    [HideInInspector] public ButtonScript ThisButton;
    [HideInInspector] public EnemyButtonScript TheseButtons;
    public bool EnemySpawn = false;
    public bool Button1 = false;
    public bool Button2 = false;
    //public GameObject Door1;
    //public GameObject Door2;
    [HideInInspector] public DoubleButtonScript1 ThatButton;
    [HideInInspector] public DoubleButtonScript2 ThoseButtons;
    //public GameObject Spawner1;
    public float EnemyMinY = 2;
    public float EnemyMaxY = 5;
    public float EnemyMinX = 71;
    public float EnemyMaxX = 105;
    public int Player = 0;

    
    /// <summary>
    /// On Collision with another object, being the enemy, the game will restart
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the player collides with a game object that has the "Enemy" tag
        if (collision.gameObject.tag == "Enemy")
        {
            // Run the Restart function
            Restart();
        }
    }

    /// <summary>
    /// On TriggerEnter, being the button, the bool becomes true, and the player
    /// will be able to open the door
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the object colliding has the tag "Button"
        if (collision.gameObject.tag == "Button")
        {
            // DoorTrigger bool is true
            DoorTrigger = true;

            // ThisButton object gets component from ButtonScript which will allow
            // the player to open the door, the console will also debug the player
            // is on a button
            ThisButton = collision.gameObject.GetComponent<ButtonScript>();
            Debug.Log("you are on a button");
            TheseButtons = collision.gameObject.GetComponent<EnemyButtonScript>();
        }

        // if the object colliding has the tag "AutoButton1"
        if (collision.gameObject.tag == "AutoButton1")
        {
            // Button1 bool is true
            Button1 = true;

            // ThatButton object gets component from DoubleButtonScript which will allow
            // the player to open the door, the console will also debug the 
            // door will open
            ThatButton = collision.gameObject.GetComponent<DoubleButtonScript1>();
            Debug.Log("Open");
        }

        // if the object colliding has the tag "AutoButton2"
        if (collision.gameObject.tag == "AutoButton2")
        {
            // Button2 bool is true
            Button2 = true;

            // ThatButton object gets component from DoubleButtonScript which will allow
            // the player to open the door, the console will also debug Up
            ThoseButtons = collision.gameObject.GetComponent<DoubleButtonScript2>();
            Debug.Log("Up");
        }

        // if Button1 and Button2 is true
        if (Button1 && Button2 == true)
        {
            //Open the door and debug
            ThatButton.Open();
            Debug.Log("Open up dumb thing");
        }

        // If collision with game object that has the tag "Spawn"
        if (collision.gameObject.tag == "Spawn")
        {
            EnemySpawn = true;

            if (EnemySpawn == true)
            {
                spawnEnemy();
            }

    
            // Repeatedly invoke spawnEnemy() after 1.5 seconds, then every .8
            // seconds

        }
    }

    /// <summary>
    /// This function will spawn enemies
    /// </summary>
    private void spawnEnemy()
    {
        // Vector2 enemy position = new Vector2
        Vector2 EnemyPos = new Vector2();

        // Enemy Position is randomly chosen within the min and max variables for
        // X and Y
        EnemyPos.x = Random.Range(EnemyMinX, EnemyMaxX);
        EnemyPos.y = Random.Range(EnemyMinY, EnemyMaxY);

        // Spawn an enemy object at that randomly chosen position
        Instantiate(Enemy, EnemyPos, Quaternion.identity);
        InvokeRepeating("spawnEnemy", 1.5f, 20f);
    }

    /// <summary>
    /// When a player exits a trigger, meaning no longer on a button
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        // if the object the player is colliding with has the "Button" tag
        if (collision.gameObject.tag == "Button")
        {
            // ThisButton becomes null and DoorTrigger becomes false
            ThisButton = null;
            DoorTrigger = false;
            //Debug.Log("you are on a button");
        }

        /* if (collision.gameObject.tag == "AutoButton1")
        {
            Button1 = false;
        }

        if (collision.gameObject.tag == "AutoButton2")
        {
            Button2 = false;
        }*/
    }

    /// <summary>
    /// Restart function that will restart the level
    /// </summary>
    public void Restart()
    {
        // Load scene again to restart the level
        SceneManager.LoadScene("SampleScene");
    }

    /*public static void OpenDoor()
    {
        if (doorTrigger == true)
        {
            DoorBehavior.Animator.SetBool("Open", true);
        }
    } */
}
