using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Transform GunAim;
    private Rigidbody2D rb;
    public float BulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GunAim = FindObjectOfType<GunAimScript>().transform;
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = GunAim.position - transform.position;
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
