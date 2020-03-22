using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public PlayerMovement mvmt;

    public void TakeDamage(int damage) 
    {
        hp -= damage;

        if (hp <= 0)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        mvmt = GetComponent<PlayerMovement>();
        hp = 100;
        speed = 20f;
        jump = true;
    }

    // Update is called once per frame
    void Update()
    {
        //jump = Player.Instance.jump;
    }

    void FixedUpdate()
    {
        jump = Player.Instance.jump;
        mvmt.Move(0f, jump);
        jump = false;
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }
}
