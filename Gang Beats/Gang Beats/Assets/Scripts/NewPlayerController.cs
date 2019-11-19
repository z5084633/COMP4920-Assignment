using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayerController : MonoBehaviour
{

    public float speed;
    public Animator mainAnimator;
    public float jumpForce = 20;
    public GameObject attackCollider;
    public bool playerOne;

    public int maxHealth = 120;
    public int health;

    protected Rigidbody2D rb;
    protected bool isDead = false;
    protected float moveHorizontal;
    protected bool facingRight = true;


    protected bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public Text nameLabel;
    public Image bar;
    public Image hpBar;


    private List<Buff> buffs = null;

    public List<Buff> getBuffs() {
        return this.buffs;
    }
    private void trackLoc()
    {

        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 targetPos = new Vector3(namePos.x, namePos.y + 40, namePos.z);
        nameLabel.transform.position = targetPos;
        bar.transform.position = targetPos;
        hpBar.fillAmount = (float)getHealth() / (float)maxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        buffs = new List<Buff>();

        health = maxHealth;
        attackCollider.SetActive(false);
        rb = GetComponent<Rigidbody2D>();

        trackLoc();
    }
    public void addHp(int n) {
        this.health += n;
        if (this.health > this.maxHealth)
        {
            this.health = this.maxHealth;
        }
    }
    private string item;
    public void setItem(string item) {
        this.item = item;
    }
    public void addBuff(Buff buff) {
        this.buffs.Add(buff);
    }
    private void useItem() {
        Debug.Log("Use Item!");
        if (item == null) {
            return;
        }
        Debug.Log(item);

        switch (item) {
            case "PreFabs/Items/RedPotion":
                // 40 Hp
                addHp(40);
                break;
            case "PreFabs/Items/YellowPotion":
                // Shield
                addBuff(new BuffShield(this, DateTime.Now).buffStart());
                break;
            case "PreFabs/Items/BluePotion":
                // Speed up
                addBuff(new BuffSpeedUp(this, DateTime.Now).buffStart());
                break;
            case "PreFabs/Items/GreenPotion":
                // Hot
                addBuff(new BuffCure(this, DateTime.Now).buffStart());
                break;
        }

        item = null;
    }
    public void Log(String str) {
        Debug.Log(str);
    }
    // Update is called once per frame
    void Update()
    {


        trackLoc();

        if (isDead)
        {
            return;
        }
        ////////// key input start

        if (playerOne)
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal") * speed;
            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                mainAnimator.SetTrigger("attack");
            }
            // Use Item
            if (Input.GetKeyDown(KeyCode.E)) {
                useItem();
            }
        }
        else
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal 2") * speed;
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                mainAnimator.SetTrigger("attack");
            }
            // Use Item
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                useItem();
            }
        }
        if (this.buffs != null)
        {
            DateTime currTime = DateTime.Now;
            foreach (Buff buff in this.buffs)
            {
                buff.update(currTime);
            }
        }



        ///face player the right way
        if (!facingRight && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight && moveHorizontal < 0)
        {
            Flip();
        }

        ///moving animation

        if (moveHorizontal != 0)
        {
            mainAnimator.SetBool("moving", true);
        }
        else
        {
            mainAnimator.SetBool("moving", false);
        }

    }

    void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        rb.velocity = new Vector2(moveHorizontal, rb.velocity.y);
    }

    public void Flip()
    {

        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }
    public int shieled = 0;
    public void takeDamage(int amount)
    {
        if (this.shieled != 0) {
            amount = amount / 3;
        }
        health -= amount;
        if (health <= 0)
        {
            killPlayer();
        }
    }

    void killPlayer()
    {
        isDead = true;
        mainAnimator.SetBool("death", true);
    }

    void Attack1Start()
    {

        attackCollider.SetActive(true);

    }

    void Attack1End()
    {

        attackCollider.SetActive(false);

    }

    public int getHealth()
    {
        return health;
    }
    public void setName(string str) {
        nameLabel.text = str;
    }
}