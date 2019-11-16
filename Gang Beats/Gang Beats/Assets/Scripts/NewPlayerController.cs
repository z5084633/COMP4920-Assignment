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

    private void trackLoc()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 targetPos = new Vector3(namePos.x, namePos.y + 40, namePos.z);
        nameLabel.transform.position = targetPos;
        bar.transform.position = targetPos;
        hpBar.fillAmount = (float)playerHealth.getHealth() / (float)playerHealth.getMaxHealth();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerHealth.setMaxHealth(120);
        playerHealth.GameStart();

        attackCollider.SetActive(false);
        rb = GetComponent<Rigidbody2D>();

    }


    // Update is called once per frame
    void Update()
    {


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
    public void setName(string str) {
        nameLabel.text = str;
    }
}