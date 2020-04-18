using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float xMovement;
    private Rigidbody2D body;
    public float movementSpeed;
    public float jumpForce;
    public float wallJumpForce;

    private bool isGrounded;
    private bool wallLeft;
    private bool wallRight;
    public Transform groundCheck;
    public Transform wallCheckLeft;
    public Transform wallCheckRight;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body = this.GetComponent<Rigidbody2D>();
        Move();
    }



    void Move()
    {
        if (isGrounded||body.velocity.x==0)
        {
            xMovement = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;
            body.velocity = new Vector2(xMovement, body.velocity.y);
        }
        
        
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        wallLeft = Physics2D.OverlapCircle(wallCheckLeft.position, groundCheckRadius, groundLayer);
        wallRight = Physics2D.OverlapCircle(wallCheckRight.position, groundCheckRadius, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }else if (Input.GetKeyDown(KeyCode.Space) && wallLeft)
        {
            body.velocity = new Vector2(wallJumpForce,jumpForce);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && wallRight)
        {
            body.velocity = new Vector2(-wallJumpForce,jumpForce);
        }
    }
    void Update() {

        Jump();
    }

}
