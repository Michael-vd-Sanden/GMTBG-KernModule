using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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

    private SpriteRenderer[] Players;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

        Players = GetComponentsInChildren<SpriteRenderer>();
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
            foreach (SpriteRenderer s in Players)
            {
                s.flipX = false;
            }
        }
        else if (moveBy < 0f)
        {
            foreach (SpriteRenderer s in Players)
            {
                s.flipX = true;
            }
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