using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        attackCollider.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

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

    void Flip()
    {

        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }

    public void takeDamage(int amount)
    {

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
}