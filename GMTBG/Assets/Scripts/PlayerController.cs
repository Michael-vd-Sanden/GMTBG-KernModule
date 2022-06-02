using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public float timeInvincible = 2f;
    private bool isInvincible;
    private float invincibleTimer;

    //[SerializeField] private Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    public int health
    {
        get
        { return currentHealth; }
    }

    new Rigidbody2D rigidbody;
    float horizontal;
    float vertical;

    public float speed = 3f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();

        //if (isInvincible)
        //{
        //    invincibleTimer -= Time.deltaTime;
        //    if (invincibleTimer < 0)
        //    { isInvincible = false; }
        //}
    }

    private void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        float moveBy = horizontal * speed;
        rigidbody.velocity = new Vector2(moveBy, rigidbody.velocity.y);
        if (moveBy > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (moveBy < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;

        rigidbody.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            { return; }

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}