using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject Door;
    public DoorBehavior Animator;
    [HideInInspector] public PlayerScript _ps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        _ps = FindObjectOfType<PlayerScript>();
        Debug.Log(Door);
        if (_ps.DoorTrigger == true)
        {
            // DoorBehavior.Animator.SetBool("Open", true);
            Destroy(Door);
            Debug.Log("OpenDoor");
        }
    }
}
