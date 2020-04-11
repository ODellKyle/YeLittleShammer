using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    public Animator animator;
    public static bool bossDefeated = false;
    public static bool bossActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        mvmt = GetComponent<PlayerMovement>();
        jump = true;
        bossActivated = true;
    }

    void LateUpdate()
    {
        animator.SetBool("bossDefeated", bossDefeated);
        Move();
        if (hp <= 0)
        {
            bossDefeated = true;
            bossActivated = false;
        }
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
