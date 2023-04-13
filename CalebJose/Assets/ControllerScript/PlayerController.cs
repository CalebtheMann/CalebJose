using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _rotatePoint;

    InputActionAsset inputAsset;
    InputActionMap inputMap;
    InputAction move;
    InputAction aim;
    InputAction interact;
    InputAction shoot;

    Vector2 movement;
    Vector2 aiming;

    public GameObject Bullet;
    public GameObject BulletSpawn;

    private PlayerScript _ps;

    private void Awake()
    {
        _ps = GetComponent<PlayerScript>();

        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActions");
        move = inputMap.FindAction("Walk");
        interact = inputMap.FindAction("Interact");
        aim = inputMap.FindAction("Aim");
        shoot = inputMap.FindAction("Shoot");


        move.performed += fofofo => movement = fofofo.ReadValue<Vector2>();
        move.canceled += fofofo => movement = Vector2.zero;
        aim.performed += fofofo => aiming = fofofo.ReadValue<Vector2>();
        aim.canceled += fofofo => aiming = Vector2.zero;
        interact.performed += fofofo => OpenDoorReference();
        shoot.performed += fofofo => Shoot();
    }

    private void FixedUpdate()
    {
        Vector2 movementVelocity = new Vector2(movement.x, movement.y) * 10f * Time.deltaTime;
        transform.Translate(movementVelocity, Space.Self);

        //Vector2 rotateVelocity = new Vector2(aiming.x, aiming.y) * 3f * Time.deltaTime;
        //transform.Rotate(rotateVelocity, Space.Self);

        float angle = Mathf.Atan2(aiming.y, aiming.x) * Mathf.Rad2Deg;
        _rotatePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Shoot()
    {
        Vector2 bulletPos = new Vector3(BulletSpawn.transform.position.x, BulletSpawn.transform.position.y, BulletSpawn.transform.position.z) ;
        Instantiate(Bullet, bulletPos, Quaternion.identity);
    }

    private void OpenDoorReference()
    {
        if(_ps.ThisButton != null)
        {
            Debug.Log("pls work");
            _ps.ThisButton.OpenDoor();
        }
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
