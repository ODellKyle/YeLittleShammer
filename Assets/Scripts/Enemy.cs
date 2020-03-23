using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public PlayerMovement mvmt;
    public Transform target;

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
        jump = true;
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Player.Instance.transform.position.magnitude - this.transform.position.magnitude < 5)
            target = Player.Instance.transform;
        else
            target = null;

        velocity = speed * -target.
        if(target != null) 
        {
            mvmt.Move(velocity * Time.fixedDeltaTime, false);
        }
    }*/

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
