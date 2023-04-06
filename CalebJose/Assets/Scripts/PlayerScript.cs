using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour

{
    public GameObject Enemy;
    public Transform SpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spawn")
        {
            Vector2 EnemyPos = new Vector2(SpawnLocation.position.x, SpawnLocation.position.y);

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    EnemyPos.x = SpawnLocation.position.x + ((j + 0.5f) * 3f);
                    Instantiate(Enemy, EnemyPos, Quaternion.identity);
                }
            }
        }
    }
}
