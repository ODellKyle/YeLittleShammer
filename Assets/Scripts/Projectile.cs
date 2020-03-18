using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float dirX;
    private float dirY;
    public int damage = 10;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        dirX = 0f;
        dirY = 0f;
        rb = GetComponent<Rigidbody2D>();
        if(Input.GetButton("Fire3"))
            dirX = Input.GetAxisRaw("Fire3") * Time.fixedDeltaTime;
        if(Input.GetButton("Fire2"))
            dirY = Input.GetAxisRaw("Fire2") * Time.fixedDeltaTime;
        rb.velocity = new Vector2(dirX * 400f, dirY * 400f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy != null) 
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
