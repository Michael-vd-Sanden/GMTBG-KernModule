using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float startHealth;
    [SerializeField] private FightingControlls player;
    [SerializeField] private PlayerGrowth playerHealth;
    [SerializeField] private SpriteMask healthMask;
    [SerializeField] private RectTransform maskHealth;
    [SerializeField] private EffectController effects;
    private float TotalDamage = 0f;

    private SpriteRenderer enemySprite;
    private Animator enemyAnimator;

    private float damage = 1f;
    [SerializeField] private float health;
    public float walkingSpeed = 100f;
    public enum stateEnum { Walk, Attack}
    public stateEnum state;

    [SerializeField] private Transform pointRight, pointLeft;
    [SerializeField] private Transform currentTarget;

    public enum moodEnum { Fight, Ignore, Squash}
    public moodEnum mood;

    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        enemyAnimator = GetComponent<Animator>();
        player = FindObjectOfType<FightingControlls>();
        playerHealth = FindObjectOfType<PlayerGrowth>();
        health = startHealth;
    }

    void Update()
    {
        CheckState();
        CheckMood();
        CheckRelationship();
    }

    public void GetHit(float damage)
    {
        TotalDamage += damage;
        health -= damage;

        if (health > 0)
        {
            float percentage = (TotalDamage / startHealth) ;
            //if (gameObject.tag == "enemyMedium")
            //{  percentage *= 3;  }
            //if (gameObject.tag == "enemyBig")
            //{ percentage *= 5;  }
            //if (gameObject.tag == "enemyBoss")
            //{ percentage *= 10;  }
           
            Vector3 tempPercentage = new Vector2(-percentage, 0.65f);
            maskHealth.anchoredPosition = tempPercentage;
            //healthMask.transform.position -= tempPercentage;
            Debug.Log(percentage);
        }

        if (health <= 0)
        {
            if (gameObject.tag == "enemyBoss")
            {
                effects.Win();
            }
            playerHealth.changeHealth(1f);
            Destroy(gameObject);
        }
    }


    public void CheckRelationship()
    {
        switch (playerHealth.health)
        {
            case 1:
                if(gameObject.tag == "enemySmall")
                {
                    mood = moodEnum.Fight;
                }
                else if (gameObject.tag == "enemyMedium" || gameObject.tag == "enemyBig")
                {
                    mood = moodEnum.Ignore;
                }
                break;
            case 2:
                if (gameObject.tag == "enemySmall")
                {
                    mood = moodEnum.Fight;
                }
                else if (gameObject.tag == "enemyMedium" || gameObject.tag == "enemyBig")
                {
                    mood = moodEnum.Ignore;
                }
                break;
            case 3:
                if (gameObject.tag == "enemySmall")
                {
                    mood = moodEnum.Squash;
                }
                if (gameObject.tag == "enemyMedium")
                {
                    mood = moodEnum.Fight;
                }
                if (gameObject.tag == "enemyBig")
                {
                    mood = moodEnum.Ignore;
                }
                break;
            case 4:
                if (gameObject.tag == "enemySmall" || gameObject.tag == "enemyMedium")
                {
                    mood = moodEnum.Squash;
                }
                if (gameObject.tag == "enemyBig")
                {
                    mood = moodEnum.Fight;
                }
                break;
            case 5:
                if (gameObject.tag == "enemySmall" || gameObject.tag == "enemyMedium")
                {
                    mood = moodEnum.Squash;
                }
                if (gameObject.tag == "enemyBig")
                {
                    mood = moodEnum.Fight;
                }
                break;
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

    private void CheckMood()
    {
        switch(mood)
        {
            case moodEnum.Fight:
                NoBool();
                enemyAnimator.SetBool("Angry", true);
                break;
            case moodEnum.Ignore:
                NoBool();
                enemyAnimator.SetBool("Bored", true);
                break;
            case moodEnum.Squash:
                NoBool();
                enemyAnimator.SetBool("Scared", true);
                break;
        }
    }

    private void NoBool()
    {
        enemyAnimator.SetBool("Angry", false);
        enemyAnimator.SetBool("Scared", false);
        enemyAnimator.SetBool("Bored", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && mood == moodEnum.Fight)
        {
            SetAttack();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SetWalk();
        }
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
        yield return new WaitForSecondsRealtime(1f);
        if (state == stateEnum.Attack)
        {
            playerHealth.changeHealth(-damage);
        }
        yield break;
    }
}
