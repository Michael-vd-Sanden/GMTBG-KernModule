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

    public float health;
    public float maxHealth = 10f;
    public Transform spawnPoint;

    private bool facingRight = true;
    [SerializeField] private SpriteRenderer playerSprite;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    void Update()
    {
        CheckIfGrounded();
        Jump();
        if(Input.GetKeyDown(KeyCode.F))
        {
            changeHealth(-1);
            Debug.Log(health);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float moveBy = x * walkingSpeed * Time.fixedDeltaTime;
        if (x > 0 && !facingRight)
        {
            playerSprite.flipX = false;
            facingRight = true;
        }
        else if(x < 0 && facingRight)
        {
            playerSprite.flipX = true;
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

    void changeHealth(float hp)
    {
        health += hp;
        if (health <= 0)
        {
            respawn();
            health = maxHealth;
        }
    }

    public void setSpawnpoint(GameObject point)
    {
        spawnPoint = point.transform;
    }

    public void respawn()
    {
        gameObject.transform.position = spawnPoint.position;
    }
}
