using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    private static Player instance;
    public static Player Instance { get { return instance; } }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }

        inventory = ItemPickup.Items.items;
        weapon.SetActive(false);
    }

    public PlayerMovement mvmt;
    public GameObject weapon;
    public int currentLevel;
    public List<bool> inventory;


    // Start is called before the first frame update
    void Start()
    {
        jump = true;
        collider = GetComponent<BoxCollider2D>();
        mvmt = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetButtonDown("Jump"))
            jump = true;
    }



    private void LateUpdate()
    {
        Move();
    }


    public void TakeDamage(int damage) 
    {
        hp -= damage;

        if(hp <= 0) 
        {
            SceneManager.LoadScene("GameOverScene");
            this.enabled = false;
            Player.Instance.transform.position = new Vector3(6f, -3.86f, 0f);
            hp = 100;
        }
    }

    public override void Move()
    {
        mvmt.Move(velocity * Time.fixedDeltaTime, jump);
        jump = false;
    }
    public void ActivateItem(int itemNumber) 
    {
        if(itemNumber == 0) 
        {
            weapon.SetActive(true);
        }
    }
}
