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
    //public GameObject attackCollider;
    public bool playerOne;

    protected PlayerHealth playerHealth;

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

    public AudioClip JumpSound;
    
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
        hpBar.fillAmount = (float)playerHealth.getHealth() / (float)playerHealth.getMaxHealth();
    }

    private void Start()
    {
        if (this.buffs == null){
            this.buffs = new List<Buff>();
        }
        playerHealth = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
    }

    private string item;
    public void setItem(string item) {
        this.item = item;
    }
    public void addBuff(Buff buff) {
        if (this.buffs == null){
            this.buffs = new List<Buff>();
        }
        this.buffs.Add(buff);
    }
    private void useItem() {
        Debug.Log("Use Item!");
        if (item == null) {
            return;
        }
        Debug.Log("ITEM = " + item);

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

        //Debug.Log(isGrounded);
        //trackLoc(); // probably going to rather use the big health bars

        if (isDead)
        {
            return;
        }

        if (playerHealth.getHealth() <= 0) {
            killPlayer();
        }

        ////////// key input start

        if (playerOne)
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal") * speed;
            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce);
                PlayJumpSound();
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
                PlayJumpSound();
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
            rb.velocity = new Vector2(0,0);
            return;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        rb.velocity = new Vector2(moveHorizontal, rb.velocity.y);
    }

    public virtual void PlayJumpSound() {

        AudioSource.PlayClipAtPoint(JumpSound, new Vector3());

    }
    public int shieled = 0;
    public void takeDamage(int amount)
    {
        if (this.shieled != 0) {
            amount = amount / 3;
        }
    }
    public void addHp(int amount){
        playerHealth.addHealth(amount);
    }
/*    public int getHp(){
        return playerHealth.getHealth();
    }*/
    public void Flip()
    {

        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }

    public int getHealth() {
        return playerHealth.getHealth();
    }

    public bool IsDead() {

        return isDead;
    }

    void killPlayer()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        rb.gravityScale = 0;
        isDead = true;
        mainAnimator.SetBool("death", true);
    }
    public void setName(string str) {

        //need to decide if we want the name here? probably best to do it somewhere else.
        //nameLabel.text = str;
    }
}