using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    protected PlayerMovement mvmt;
    protected Transform target;
    //TODO: Program so enemy can find platforms and utilize
    //private Transform platform;
    [Range (.01f, 2f)] [SerializeField] public float accuracy = .01f;
    [Range(.5f, 10f)] [SerializeField] public float startJumpDistance = 1f;
    [Range(1f, 10f)] [SerializeField] public float lockOnDistance = 5f;
    [Range(1f, 4f)] [SerializeField] public float offset = 1f;
    public int damage = 5;
    public float coolDown = .1f;
    private float timer;

    public void TakeDamage(int damage) 
    {
        hp -= damage;

        if (hp <= 0)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        hp = Random.Range(100, 150);
        speed = Random.Range(5f, 15f);
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

    private void Strike(Player player) 
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

    public Transform FindPlatform() 
    {
        int layerMask = 8;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up * 100f, layerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, -Vector2.up, 4f, layerMask);


        if(hit.collider != null)
        {

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * hit.distance, Color.black);
            Debug.Log("cast hit!");
        }

        return hit.transform;
    }

    public void JumpPlatform(Transform platform, Vector3 velocityVector) 
    {
        velocityVector = platform.position - this.transform.position;
        
        Debug.DrawRay(transform.position, velocityVector, Color.black);
        if (velocityVector.x < platform.localPosition.x + offset && velocityVector.x > 0)
            velocity = speed;
        else if (velocityVector.x > platform.localPosition.x + -offset && velocityVector.x < 0)
            velocity = -speed;
        else
            jump = true;

        //if (velocityVector.y > accuracy + startJumpDistance)
            //jump = true;
    }
}
