using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    [SerializeField] private float startHealth;
    [SerializeField] private FightingControlls player;
    [SerializeField] private PlayerController playerHealth;
    [SerializeField] private SpriteMask healthMask;
    [SerializeField] private SpriteRenderer enemySprite;
    [SerializeField] private Animator enemyAnimator;

    private float damage;
    private float health;
    public float walkingSpeed = 100f;
    public enum stateEnum { Walk, Attack}
    public stateEnum state;

    [SerializeField] private Transform pointRight, pointLeft;
    [SerializeField] private Transform currentTarget;

    void Start()
    {
        if(gameObject.tag == "enemySmall")
        { startHealth = 5f;  damage = 1f; }
        if (gameObject.tag == "enemyMedium")
        { startHealth = 20f; damage = 5f; }
        if(gameObject.tag == "enemyBig")
        { startHealth = 50f;  damage = 10f; }
        if(gameObject.tag == "enemyBoss")
        { startHealth = 100f; damage = 15f; }
        player = FindObjectOfType<FightingControlls>();
        playerHealth = FindObjectOfType<PlayerController>();
        health = startHealth;
        rigidbody2d = GetComponent<Rigidbody2D>();

        //float tempPointRight = transform.position.x + 2f;
        //float tempPointLeft = transform.position.x - 2f;
        //pointRight = new Vector3(tempPointRight, 0);
        //pointLeft = new Vector3(tempPointLeft, 0);
    }

    void Update()
    {
        //Walk();
        CheckState();
    }

    public void GetHit(float damage)
    {
        health -= damage;

        if (health > 0)
        {
            float percentage = (damage / startHealth) ;
            if (gameObject.tag == "enemyMedium")
            {  percentage *= 3;  }
            if (gameObject.tag == "enemyBig")
            { percentage *= 5;  }
            if (gameObject.tag == "enemyBoss")
            { percentage *= 10;  }
            Vector3 tempPercentage = new Vector3(percentage, 0);
            healthMask.transform.position -= tempPercentage;
            Debug.Log(percentage);
        }

        if (health <= 0)
        {
            player.Grow();
            Destroy(gameObject);
        }
    }

    private void CheckState()
    {
        switch(state)
        {
            case stateEnum.Walk: StartCoroutine(WalkBehaviour());
                break;
            case stateEnum.Attack: StartCoroutine(AttackBehaviour());
                break;
        }
    }

    public void SetAttack()
    {
        state = stateEnum.Attack;
    }
    public void SetWalk()
    {
        state = stateEnum.Walk;
    }

    private void Walk()
    {
        if (transform.position.x >= pointRight.position.x - 0.5f)
        {
            currentTarget = pointLeft;
            enemySprite.flipX = false;
        }
        else if (transform.position.x <= pointLeft.position.x + 0.5f)
        {
            currentTarget = pointRight;
            enemySprite.flipX = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, walkingSpeed * Time.deltaTime);
    }

    private IEnumerator WalkBehaviour()
    {
        if (transform.position.x >= pointRight.position.x - 0.5f)
        {
            currentTarget = pointLeft;
            enemySprite.flipX = false;
        }
        else if (transform.position.x <= pointLeft.position.x + 0.5f)
        {
            currentTarget = pointRight;
            enemySprite.flipX = true;
        }
        if(gameObject.tag != "enemyBoss")
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, walkingSpeed * Time.deltaTime);
        }
        yield return null;
    }

    private IEnumerator AttackBehaviour()
    {
        yield return new WaitForSeconds(1f);
        if (state == stateEnum.Attack)
        {
            playerHealth.changeHealth(-damage);
        }
        yield return null;
    }
}
