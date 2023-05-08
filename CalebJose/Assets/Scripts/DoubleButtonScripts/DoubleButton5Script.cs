using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleButton5Script : MonoBehaviour
{
    public GameObject Door1;
    public GameObject Door2;
    private PlayerScript sp_;
    public bool Button5 = false;
    public bool Button6 = false;
    public AudioClip ButtonActivate;

    /// <summary>
    /// Open function that will open the door
    /// </summary>
    public void Open()
    {
        // Find object of type PlayerScript
        foreach (PlayerScript p in FindObjectsOfType<PlayerScript>())
        {
            if (PlayerScript.Button5 == true && PlayerScript.Button6 == true)
            {
                // Destroy both doors
                Destroy(Door1);
                Destroy(Door2);
                AudioBehavior.Source.PlayOneShot(ButtonActivate);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerScript.Button5 = true;
        }
    }
}
