using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{

    public float speed;
    public Animator mainAnimator;
    public float jumpForce = 20;
    public GameObject attackCollider;

    private Rigidbody2D rb;
    private float moveHorizontal;
    private bool facingRight = true;
    
    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    // Start is called before the first frame update
    void Start()
    {
        attackCollider.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal") * speed;

        if (!facingRight && moveHorizontal > 0) {
            Flip();
        } else if (facingRight && moveHorizontal < 0) {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded) {
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.S) )
        {
            mainAnimator.SetTrigger("attack");
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

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        rb.velocity = new Vector2(moveHorizontal, rb.velocity.y);
    }

    void Flip() {

        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    
    }

    void Attack1Start() {

        attackCollider.SetActive(true);

    }

    void Attack1End()
    {

        attackCollider.SetActive(false);

    }
}
