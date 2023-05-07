/*****************************************************************************
// File Name : PlayerController.cs
// Author : Jose Becerra
// Last Edited by : Caleb Purnell
// Creation Date : April 6, 2023
//
// Brief Description : This script controls the player and their actions, all 
inputs on the controller are read and will be told what to do. This will allow 
the player to move, shoot, and interact with other objects within the level.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Create a variable for the rotate point of the player,
    // allowing the player to aim in that direction
    [SerializeField] private Transform _rotatePoint;

    // Reference the Player Input Actions and Action Map, as well as create
    // Input Actions for each action the player can make when using the controller
    InputActionAsset inputAsset;
    InputActionMap inputMap;
    InputAction move;
    InputAction aim;
    InputAction interact;
    InputAction shoot;

    // Create Vector 2 variables that will be used to allow the player to aim
    // and move
    Vector2 movement;
    Vector2 aiming;

    // Create GameObject variables that will hold the bullet and the spawn point
    // for the bullet
    public GameObject Bullet;
    public GameObject BulletSpawn;
    public AudioClip Laser;
    
    // Creates references to PlayerScript and DirectionScript that will be used
    // to access code within those scripts
    public PlayerScript _ps;
    [SerializeField] DirectionScript direction;

    /// <summary>
    /// On Awake, the input actions will refernce different functions that will
    /// let the player do different thhings, like shooting, moving, aiming, and
    /// interacting
    /// </summary>
    private void Awake()
    {
        _ps = GetComponent<PlayerScript>();

        // Input Asset gets the component of PlayerInput Actions
        inputAsset = this.GetComponent<PlayerInput>().actions;
        // InputMap = the action map "Player Actions"
        inputMap = inputAsset.FindActionMap("PlayerActions");

        // Each input action is assigned their respective
        // Action within the Action Map
        move = inputMap.FindAction("Walk");
        interact = inputMap.FindAction("Interact");
        aim = inputMap.FindAction("Aim");
        shoot = inputMap.FindAction("Shoot");

        // Each input action is performed, there is context associated with it,
        // and then either a variable is assigned something new like Vector2 for
        // movement, or a function is being referenced like with shooting
        move.performed += fofofo => movement = fofofo.ReadValue<Vector2>();
        move.canceled += fofofo => movement = Vector2.zero;
        aim.performed += fofofo => aiming = fofofo.ReadValue<Vector2>();
        aim.canceled += fofofo => aiming = Vector2.zero;
        interact.performed += fofofo => OpenDoorReference();
        shoot.performed += fofofo => Shoot();
    }

    /// <summary>
    /// This code will be using Fixed Update, and will allow the player to move
    /// using the left stick. It will also allow the player to aim using the 
    /// right stick.
    /// </summary>
    private void FixedUpdate()
    {
        // creates a Vector2 variable that is movement * speed * time
        Vector2 movementVelocity = new Vector2(movement.x, movement.y) * 10f * Time.deltaTime;
        transform.Translate(movementVelocity, Space.Self);

        //Vector2 rotateVelocity = new Vector2(aiming.x, aiming.y) * 3f * Time.deltaTime;
        //transform.Rotate(rotateVelocity, Space.Self);

        // creates a float angle that uses the tangent of the angle
        // of Vector2 aiming * Radians to degrees
        float angle = Mathf.Atan2(aiming.y, aiming.x) * Mathf.Rad2Deg;

        // the rotation of rotatePoint is = angle, and forward
        _rotatePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    /// <summary>
    /// Shoot function that will spawn in bullets and send them in the direction
    /// the player is facing
    /// </summary>
    private void Shoot()
    {
        // Vector2 bullet position = the position of the bullet spawn object
        Vector2 bulletPos = new Vector3(BulletSpawn.transform.position.x, BulletSpawn.transform.position.y, BulletSpawn.transform.position.z) ;

        // var bullet Object = spawn in the Bullet object on bullet position
        var bulletObj = Instantiate(Bullet, bulletPos, Quaternion.identity);

        // bullet object gets the component bulletDirection from Bullet Script
        // and that equals the transform of direction
        bulletObj.GetComponent<BulletScript>().bulletDirection = direction.transform;

        AudioSource.PlayClipAtPoint(Laser, transform.position, 1f);
    }

    /// <summary>
    /// A script that will reference OpenDoor() in PlayerScript with an if
    /// statement, being if the player is standing on the button
    /// </summary>
    private void OpenDoorReference()
    {
        // if the player is triggering the button
        if(_ps.ThisButton != null)
        {
            // debug in the console and reference OpenDoor()
            Debug.Log("pls work");
            _ps.ThisButton.OpenDoor();
        }

        if(_ps.TheseButtons != null)
        {
            Debug.Log("pls work");
            _ps.TheseButtons.OpenDoor();
            _ps.CancelInvoke();
        }

        if(_ps.ThatButton != null)
        {
            Debug.Log("pls work");
            _ps.ThatButton.Open();
        }

        if(_ps.ThoseButtons!= null)
        {
            Debug.Log("pls work");
            _ps.ThoseButtons.Open();
        }

        if(_ps.ThatButton2 != null)
        {
            _ps.ThatButton2.Open();
        }

        if(_ps.ThoseButtons2 != null)
        {
            _ps.ThoseButtons2.Open();
        }

        if(_ps.ThatButton3 != null)
        {
            _ps.ThatButton3.Open();
        }

        if(_ps.ThoseButtons3 != null)
        {
            _ps.ThoseButtons3.Open();
        }
    }

    /// <summary>
    /// When the script is active
    /// </summary>
    private void OnEnable()
    {
        //Enable the Input Action Map
        inputMap.Enable();
    }


    /// <summary>
    /// When the script is Disabled
    /// </summary>
    private void OnDisable()
    {
        // Disable the Input Action Map
        inputMap.Disable();
    }
}
