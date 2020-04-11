using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float dirX = 0;
    private float dirY = 0;
    public float speed = 400f;
    public int damage = 13;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 velX = transform.right;
        Vector3 velY = Vector3.zero;
        rb = GetComponent<Rigidbody2D>();
        if (Input.GetButton("Fire3"))
        {
            dirX = Input.GetAxisRaw("Fire3");

        }

        if (Input.GetButton("Fire2"))
        {
            dirY = Input.GetAxisRaw("Fire2");
        }

        if(dirX != 0 || dirY != 0) 
        {
            velX = new Vector3(dirX, 0, 0);
            velY = new Vector3(0, dirY, 0);
        }
        rb.velocity = (speed * Time.fixedDeltaTime) * (velX + velY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null) 
        {
            enemy.TakeDamage(damage);
        }

        if(!collision.CompareTag("Projectile") && !collision.CompareTag("Player"))
            Destroy(gameObject);
    }
}
