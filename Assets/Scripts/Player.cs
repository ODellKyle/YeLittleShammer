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
    public AudioClip jumpingSound;
    public AudioClip dyingSound;
    public AudioClip hitSound;
    public Animator animator;
    private bool hasDied;

    // Start is called before the first frame update
    void Start()
    {
        jump = true;
        mvmt = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
            hasDied = true;
        else
            hasDied = false;
        animator.SetBool("hasDied", this.hasDied);
        velocity = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(this.velocity));
        
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

        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = hitSound;
        audio.Play();
        if (hp <= 0)
        {
            StartCoroutine(Dying());
        }
    }

    IEnumerator Dying() 
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = dyingSound;
        audio.Play();

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("GameOverScene");
        this.Inactive(false);
        Player.Instance.transform.position = new Vector3(6f, -3.86f, 0f);
        hp = 100;
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

    public void Inactive(bool active) 
    {
        this.enabled = active;
        if(inventory[0])
            weapon.SetActive(active);
    }

    public void NewGame() 
    {
        this.inventory[0] = false;
        this.inventory[1] = false;
    }
}
