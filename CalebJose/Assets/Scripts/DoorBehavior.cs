using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public static Animator animator;
    [SerializeField] public DoorBehavior door;
    private static bool doorTrigger = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
            animator.SetBool("Open", true);
        }
    }

    public void CloseDoor()
    {
        animator.SetBool("Open", false);
    }
}
