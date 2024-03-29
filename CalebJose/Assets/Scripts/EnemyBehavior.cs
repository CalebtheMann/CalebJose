/*****************************************************************************
// File Name : EnemyBehavior.cs
// Author : Jose Becerra
// Last Edited by : Caleb Purnell
// Creation Date : April 6, 2023
//
// Brief Description : This script will control the player and how they behave 
in relation to objects around them.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform Player1;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 3;
    private float angle;
    [HideInInspector] public PlayerScript Player;
    public AudioClip EnemyDeath;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScript cp = null;
        float shortestDist = 50;

        foreach (PlayerScript e in FindObjectsOfType<PlayerScript>())
        {
            float distFromPlayer = Vector3.Distance(e.transform.position, transform.position);
            if (distFromPlayer < shortestDist)
            {
                shortestDist = distFromPlayer;
                cp = e;
            }
        }

        CalculateClosestMovement(cp);
    }

    private void CalculateClosestMovement(PlayerScript closestPlayer)
    {
        if(closestPlayer == null)
        {
            return;
        }

        Vector3 direction = closestPlayer.transform.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction; //Vector3.distance
    }

    private void FixedUpdate()
    {
        foreach (PlayerScript e in FindObjectsOfType<PlayerScript>())
        {
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            AudioBehavior.Source.PlayOneShot(EnemyDeath);
        }

        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
            AudioBehavior.Source.PlayOneShot(EnemyDeath);
        }

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            AudioBehavior.Source.PlayOneShot(EnemyDeath);
        }
    }
}
