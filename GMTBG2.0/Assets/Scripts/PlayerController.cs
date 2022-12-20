using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;

    public float walkingSpeed = 5f;
    public float jumpForce = 15f;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    //public float health;
    //public float maxHealth = 10f;
    //private int timesDied = 0;
    //private bool isInvincible;
    //private float invincibleTimer;
    //public float timeInvincible= 2f;
    public Transform spawnPoint;
    private FightingControlls fight;

    private bool facingRight = true;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private SpriteRenderer swordSprite;
    [SerializeField] public SpriteMask healthMask;
    [SerializeField] public Animator playerAnimator;
    [SerializeField] public Animator swordAnimator;
    [SerializeField] private SceneSelect scenes;

    [SerializeField] public GameObject DeathScreen;
    [SerializeField] public ResetScores scores;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        fight = GetComponent<FightingControlls>();
        //health = maxHealth;
    }

    void Update()
    {
        CheckIfGrounded();
        Jump();

        //if (isInvincible)
        //{
        //    invincibleTimer -= Time.deltaTime;
        //    if (invincibleTimer < 0)
        //    { isInvincible = false; }
        //}
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
            swordSprite.flipX = false;
            swordSprite.transform.localPosition = new Vector3(0.375f, 0.064f, 0);
            facingRight = true;
        }
        else if(x < 0 && facingRight)
        {
            playerSprite.flipX = true;
            swordSprite.flipX = true;
            swordSprite.transform.localPosition = new Vector3(-0.375f, 0.064f, 0);
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

    //public void changeHealth(float hp)
    //{
    //    if (hp < 0)
    //    {
    //        if (isInvincible)
    //        {
    //            return;
    //        }
    //        playerAnimator.SetTrigger("hit");
    //        isInvincible = true;
    //        invincibleTimer = timeInvincible;
    //    }
    //    health = Mathf.Clamp(health + hp, 0, maxHealth);
    //    float percentage = (hp / maxHealth);
    //    Vector3 tempPercentage = new Vector3(percentage, 0);
    //    healthMask.transform.position += tempPercentage;

    //    Debug.Log(health);
    //    if (health <= 0) //death
    //    {
    //        StartCoroutine(DeathBehaviour());
    //    }
    //}

    //public void checkGameOver()
    //{
    //    timesDied++;
    //    switch (timesDied)
    //    {
    //        case 1: life3.SetActive(false);
    //            break;
    //        case 2: life2.SetActive(false);
    //            break;
    //        case 3: life1.SetActive(false);
    //            break;
    //        case 4: scenes.loadEndScene();
    //            break;
    //    }
    //}

    public void setSpawnpoint(GameObject point)
    {
        spawnPoint = point.transform;
    }

    public void respawn()
    {
        scores.upDeaths();
        gameObject.transform.position = spawnPoint.position;
    }

    //private IEnumerator DeathBehaviour()
    //{
    //    Time.timeScale = 0;
    //    DeathScreen.SetActive(true);
    //    fight.enabled = false;

    //    yield return new WaitForSecondsRealtime(2f);

    //    DeathScreen.SetActive(false);
    //    fight.enabled = true;
    //    Time.timeScale = 1;

    //    respawn();
    //    health = maxHealth;
    //    healthMask.transform.localPosition = new Vector3(0, -0.7f);
    //    checkGameOver();
    //    yield break;
    //}
}
