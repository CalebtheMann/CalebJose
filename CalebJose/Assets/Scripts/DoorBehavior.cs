using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public static Animator Animator;
    [SerializeField] public DoorBehavior Door;
    private static bool doorTrigger = false;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            doorTrigger = true;
            Debug.Log("you are on a button");
        }
    }

    public static void OpenDoor()
    {
        if (doorTrigger == true)
        {
            Animator.SetBool("Open", true);
        }
    }

    public void CloseDoor()
    {
        Animator.SetBool("Open", false);
    }
}
