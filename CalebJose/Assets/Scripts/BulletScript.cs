using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Transform bulletDirection;
    private Rigidbody2D rb;
    public float BulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        bulletDirection = FindObjectOfType<DirectionScript>().transform;
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = bulletDirection.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * BulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        float direction = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, direction);

    }
}
