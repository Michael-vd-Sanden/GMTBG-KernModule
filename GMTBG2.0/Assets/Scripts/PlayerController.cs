using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public float walkingSpeed = 5f;
    public float jumpForce = 15f;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    private bool facingRight = true;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
        CheckIfGrounded();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float moveBy = x * walkingSpeed * Time.deltaTime;
        Vector3 tempScale = transform.localScale;
        if (x > 0 && !facingRight)
        {
            tempScale.x = tempScale.x * -1;
            transform.localScale = tempScale;
            facingRight = true;
        }
        else if(x < 0 && facingRight)
        {
            tempScale.x = tempScale.x * -1;
            transform.localScale = tempScale;
            facingRight = false;
        }
        rigidbody2d.velocity = new Vector2(moveBy, rigidbody2d.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
        }
    }
    
    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
