using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialUI : MonoBehaviour
{

    public GameObject pressX;
    public GameObject twoPlayer;
    public GameObject enemies;

    // Start is called before the first frame update
    void Start()
    {
        pressX.SetActive(false);
        twoPlayer.SetActive(false);
        enemies.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            pressX.SetActive(true);
            twoPlayer.SetActive(true);
            enemies.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pressX.SetActive(false);
            twoPlayer.SetActive(false);
            enemies.SetActive(false);
        }
    }
}
