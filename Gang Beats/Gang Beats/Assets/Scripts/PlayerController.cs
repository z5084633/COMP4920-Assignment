using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Animator mainAnimator;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Vector2 moveInput;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveInput = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        FaceMouse();
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput = moveInput.normalized;
        moveVelocity = moveInput * speed;

        if (Input.GetMouseButtonDown(0)) {

            mainAnimator.SetTrigger("Attack");

        }

    }

    void FixedUpdate()
    {
        rb.angularVelocity = 0;
        rb.velocity = moveVelocity * Time.fixedDeltaTime;
    }

    void FaceMouse() {

        Vector3 MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        Vector2 direction = new Vector2(MousePosition.x - transform.position.x, MousePosition.y - transform.position.y);
        transform.up = direction;

    }

}
