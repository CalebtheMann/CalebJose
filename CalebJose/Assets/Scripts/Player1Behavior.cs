using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Behavior: MonoBehaviour
{
    PlayerControls controls;

    Vector2 movement;

    // Start is called before the first frame update
    private void Awake()
    {
        controls = new PlayerControls();

        controls.PlayerActions.Walk.performed += fofofo => movement = fofofo.ReadValue<Vector2>();

        controls.PlayerActions.Walk.canceled += fofofo => movement = Vector2.zero;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 moveVelocity = new Vector2(movement.x, movement.y) * 10 * Time.deltaTime;
        transform.Translate(moveVelocity, Space.Self);
    }

    private void OnEnable()
    {
        controls.PlayerActions.Enable(); //Necessary 
    }

    private void OnDisable()
    {
        controls.PlayerActions.Disable(); //Necessary
    }
}
