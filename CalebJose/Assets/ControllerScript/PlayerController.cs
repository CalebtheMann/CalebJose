using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputActionAsset inputAsset;
    InputActionMap inputMap;
    InputAction move;
    InputAction aim;
    InputAction interact;

    Vector2 movement;
    Vector2 aiming;

    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActions");
        move = inputMap.FindAction("Walk");
        interact = inputMap.FindAction("Interact");

        move.performed += fofofo => movement = fofofo.ReadValue<Vector2>();
        move.canceled += fofofo => movement = Vector2.zero;
        /* aim.performed += fofofo => aiming = fofofo.ReadValue<Vector2>();
        aim.canceled += fofofo => aiming = Vector2.zero; */
        interact.performed += fofofo => OpenDoorReference();
    }

    private void FixedUpdate()
    {
        Vector2 movementVelocity = new Vector2(movement.x, movement.y) * 5f * Time.deltaTime;
        transform.Translate(movementVelocity, Space.Self);

        Vector2 rotateVelocity = new Vector2(aiming.x, aiming.y) * 3f * Time.deltaTime;
        transform.Rotate(rotateVelocity, Space.Self);
    }

    private void OpenDoorReference()
    {
        DoorBehavior.OpenDoor();
    }

    private void OnEnable()
    {
        inputMap.Enable();
    }

    private void OnDisable()
    {
        inputMap.Disable();
    }
}
