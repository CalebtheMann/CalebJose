using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public static Animator animator;
    [SerializeField] public DoorBehavior door;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
       
    }

    public static void OpenDoor()
    {
        animator.SetBool("Open", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("Open", false);
    }
}
