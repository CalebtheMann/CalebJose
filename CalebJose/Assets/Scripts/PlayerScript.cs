using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour

{
    public GameObject Enemy;
    public Transform SpawnLocation;
    [HideInInspector] public bool DoorTrigger = false;
    [HideInInspector] public ButtonScript ThisButton;
    public bool Button1 = false;
    public bool Button2 = false;
    public GameObject Door1;
    public GameObject Door2;
    [HideInInspector] public DoubleButtonScript ThatButton;
    public GameObject Spawner1;
    public float EnemyMinY = 2;
    public float EnemyMaxY = 14.4f;
    public float EnemyMinX = 71;
    public float EnemyMaxX = 105;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Restart();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Button")
        {
            DoorTrigger = true;
            ThisButton = collision.gameObject.GetComponent<ButtonScript>();
            Debug.Log("you are on a button");
        }

        if (collision.gameObject.tag == "AutoButton1")
        {
            Button1 = true;
            ThatButton = collision.gameObject.GetComponent<DoubleButtonScript>();
            Debug.Log("Open");
        }

        if (collision.gameObject.tag == "AutoButton2")
        {
            Button2 = true;
            ThatButton = collision.gameObject.GetComponent<DoubleButtonScript>();
            Debug.Log("Up");
        }

        if (Button1 && Button2 == true)
        {
            ThatButton.Open();
            Debug.Log("Open up dumb thing");
        }

        if (collision.gameObject.tag == "Spawn")
        {
            InvokeRepeating("spawnEnemy", 1.5f, 0.8f);

            /* for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    EnemyPos.x = SpawnLocation.position.x + ((j + 0.5f) * 3f);
                    Instantiate(Enemy, EnemyPos, Quaternion.identity);
                }
            }*/
        }
    }

    private void spawnEnemy()
    {
        Vector2 EnemyPos = new Vector2();
        EnemyPos.x = Random.Range(EnemyMinX, EnemyMaxX);
        EnemyPos.y = Random.Range(EnemyMinY, EnemyMaxX);

        Instantiate(Enemy, EnemyPos, Quaternion.identity);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Button")
        {
            ThisButton = null;
            DoorTrigger = false;
            //Debug.Log("you are on a button");
        }

        /* if (collision.gameObject.tag == "AutoButton1")
        {
            Button1 = false;
        }

        if (collision.gameObject.tag == "AutoButton2")
        {
            Button2 = false;
        }*/
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    /*public static void OpenDoor()
    {
        if (doorTrigger == true)
        {
            DoorBehavior.Animator.SetBool("Open", true);
        }
    } */
}
