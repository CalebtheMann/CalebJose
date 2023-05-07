using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleButton3Script : MonoBehaviour
{
    public GameObject Door1;
    public GameObject Door2;
    private PlayerScript sp_;
    public bool Button3 = false;
    public bool Button4 = false;
    public AudioClip ButtonActivate;

        /// <summary>
        /// Open function that will open the door
        /// </summary>
    public void Open()
        {
            // Find object of type PlayerScript
            foreach (PlayerScript p in FindObjectsOfType<PlayerScript>())
            {
                if (PlayerScript.Button3 == true && PlayerScript.Button4 == true)
                {
                    // Destroy both doors
                    Destroy(Door1);
                    Destroy(Door2);
                    AudioSource.PlayClipAtPoint(ButtonActivate, transform.position, 1f);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                PlayerScript.Button3 = true;
            }
        }
}
