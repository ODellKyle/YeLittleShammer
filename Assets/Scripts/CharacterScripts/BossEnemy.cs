using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    public static bool bossDefeated = false;
    // Start is called before the first frame update
    void Start()
    {
        hp = 1000;
        speed = 5f;
        damage = 5;
        mvmt = GetComponent<PlayerMovement>();
        jump = true;
    }

    void LateUpdate()
    {
        Move();
        if (hp <= 0)
            bossDefeated = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time - timer > coolDown)
        {
            Player player = collision.collider.GetComponent<Player>();

            if (player != null)
            {
                Strike(player);
                timer = Time.time;
            }
        }
    }
}
