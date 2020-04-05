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

    }

    private void LateUpdate()
    {
        if (hp < 0)
            bossDefeated = true;
    }
}
