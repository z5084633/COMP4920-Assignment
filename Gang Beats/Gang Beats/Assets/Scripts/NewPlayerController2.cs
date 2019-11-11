using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController2 : MonoBehaviour
{

    public float speed;
    public Animator mainAnimator;
    public float jumpForce = 20;
    public GameObject bullet;
    public GameObject bulletSpawnLoaction;
    public bool playerOne;

    private Rigidbody2D rb;
    private bool isDead = false;
    private float moveHorizontal;
    private bool facingRight = true;

    public int maxHealth = 100;
    private int health;

    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
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


        if (!facingRight && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight && moveHorizontal < 0)
        {
            Flip();
        }


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

        GameObject Spawnedbullet = Instantiate(bullet, bulletSpawnLoaction.transform.position, gameObject.transform.rotation);


        Spawnedbullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;

        if (gameObject.transform.localScale.x < 0)
        {
            Spawnedbullet.transform.Rotate(new Vector3(0, 180, 0));
            Spawnedbullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * 10;
        }
        else {
            Spawnedbullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;
        }


    }

    public int getHealth() {
        return health;
    }

    void Attack1End()
    {

        

    }
}
