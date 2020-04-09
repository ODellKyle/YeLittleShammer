using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    protected PlayerMovement mvmt;
    protected Transform target;
    public AudioClip dyingSound;
    //TODO: Program so enemy can find platforms and utilize
    //private Transform platform;
    [Range (.01f, 2f)] [SerializeField] public float accuracy = .01f;
    [Range(.5f, 10f)] [SerializeField] public float startJumpDistance = 1f;
    [Range(1f, 50f)] [SerializeField] public float lockOnDistance = 5f;
    [Range(1f, 4f)] [SerializeField] public float offset = 1f;
    public int damage = 5;
    public float coolDown = .1f;
    protected float timer;

    public void TakeDamage(int damage) 
    {
        hp -= damage;

        if (hp <= 0)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = dyingSound;
            audio.Play();
            this.damage = 0;
            this.lockOnDistance = 0f;
            Destroy(gameObject, 1f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        mvmt = GetComponent<PlayerMovement>();
        jump = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Move();
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

    protected void Strike(Player player) 
    {
        //perform striking animation
        player.TakeDamage(damage);
    }

    public override void Move()
    {
        if ((Player.Instance.transform.position - this.transform.position).magnitude < lockOnDistance)
            target = Player.Instance.transform;
        else
            target = null;

        if (target != null)
        {
            Vector3 velocityVector = target.position - this.transform.position;
            //Debug.DrawRay(transform.position, velocityVector, Color.black);

            // TODO: program so enemy jumps on platforms when player is above (raycast maybe?)
            if (velocityVector.magnitude > accuracy)
            {
                if (velocityVector.y < 0)
                {
                    //target = FindPlatform();
                    //JumpPlatform(target, velocityVector);
                    if (velocityVector.x > accuracy)
                        velocity = speed;
                    else if (velocityVector.x < -accuracy)
                        velocity = -speed;
                }
                else 
                {
                    //target = Player.Instance.transform;
                    //ChasePlayer();
                    if (velocityVector.x > accuracy)
                        velocity = speed;
                    else if (velocityVector.x < -accuracy)
                        velocity = -speed;
                    else
                        velocity = 0f;
                }

                if (velocityVector.y > accuracy + startJumpDistance)
                    jump = true;
            }
            else
                velocity = 0f;

            mvmt.Move(velocity * Time.fixedDeltaTime, jump);
            jump = false;
        }
        else
            velocity = 0f;
    }

}
