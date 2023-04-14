/*****************************************************************************
// File Name : BulletScript.cs
// Author : Jose Becerra
// Last Edited by : Caleb Purnell
// Creation Date : April 6, 2023
//
// Brief Description : This script will control the bullet and how they travel,
as well as how they interact with collisions.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Transform variable called bulletDirection, a refernce to the rigidbody of
    // the bullet, and a float variable for the speed
    public Transform bulletDirection;
    private Rigidbody2D rb;
    public float BulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //bulletDirection = FindObjectOfType<DirectionScript>().transform;

        //rb = get the component of the rigidbody of the bullet
        rb = GetComponent<Rigidbody2D>();

        // Vector3 direction = the bulletDirection's position - transform position
        Vector3 direction = bulletDirection.position - transform.position;

        // rigidbody velocity = new Vector2 which = the X and Y of direction normalized
        // multiplied by BulletSpeed
        rb.velocity = new Vector2(direction.x, direction.y).normalized * BulletSpeed;
    }

    /// <summary>
    /// On collision with an Enemy, destroy the enemies
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the object the bullet is colliding with has the tag "Enemy"
        if (collision.gameObject.tag == "Enemy")
        {
            // Destroy the Enemy Object
            Destroy(gameObject);
        }

        // Destroy the bullet Object
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // direction = the angle of the X and Y velocity of the bullet rigidbody
        // and multiply it by the radians to degrees
        float direction = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;

        // the rotation of the bullet is equal to direction
        transform.rotation = Quaternion.Euler(0f, 0f, direction);

    }
}
