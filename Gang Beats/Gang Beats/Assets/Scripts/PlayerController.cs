using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        FaceMouse();
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * speed;
    }

    void FixedUpdate()
    {

        Vector2 moveAmount = rb.position + moveVelocity * Time.fixedDeltaTime;
        rb.MovePosition(moveAmount);

    }

    void FaceMouse() {

        Vector3 MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        Vector2 direction = new Vector2(MousePosition.x - transform.position.x, MousePosition.y - transform.position.y);
        transform.up = direction;

    }

}
