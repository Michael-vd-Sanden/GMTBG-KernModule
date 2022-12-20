using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingControlls : MonoBehaviour
{
    public CameraController mainCam;
    private bool attackRadius = false;
    [SerializeField] private EnemyController enemy;
    [SerializeField] private PlayerController movement;
    [SerializeField] public float attackDamage;
    [SerializeField] private SceneSelect sceneManager;
    [SerializeField] private EffectController effects;
    [SerializeField] private Animator swordAnimator;
    [SerializeField] private PlayerGrowth growth;

    private PlayerGrowth player;

    [SerializeField] private float swordTimer = 0f;
    public float MaxSwordTimer = 2f;
    private bool activateTimer = false;

    void Start()
    {
        attackDamage = 2f;
        player = FindObjectOfType<PlayerGrowth>();
    }

    void Update()
    {
        if (activateTimer)
        {
            swordTimer -= Time.deltaTime;
            if(swordTimer <= 0)
            {
                activateTimer = false;
            }
        }
        SwingSword();  
    }

    public void SetAttackDamage(float newDamage)
    {
        attackDamage = newDamage;
    }

    public void SwingSword()
    {
        if (Input.GetMouseButtonDown(0) && swordTimer <= 0)
        {
            swordTimer = MaxSwordTimer;
            activateTimer = true;
            swordAnimator.SetTrigger("SwordSwing");
            if (attackRadius)
            {
                //attack
                if (enemy != null)
                {
                    enemy.GetHit(attackDamage);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemySmall")
        {
            enemy = collision.gameObject.GetComponent<EnemyController>();
            attackRadius = true;
        }
        if(collision.tag == "enemyMedium" && growth.health > 2)
        {
            enemy = collision.gameObject.GetComponent<EnemyController>();
            attackRadius = true;
        }
        if(collision.tag == "enemyBig" && growth.health > 3)
        {
            enemy = collision.gameObject.GetComponent<EnemyController>();
            attackRadius = true;
        }

        //if (collision.tag == "enemySmall" || collision.tag == "enemyMedium" || collision.tag == "enemyBig" || collision.tag == "enemyBoss")
        //{
        //    enemy = collision.gameObject.GetComponent<EnemyController>();
        //    attackRadius = true;
        //}
        else if (collision.tag == "spawnPoint")
        {
            GameObject flag = collision.gameObject;
            movement.setSpawnpoint(flag);
            SpriteRenderer spriteFlag = flag.GetComponent<SpriteRenderer>();
            BoxCollider2D colliderFlag = flag.GetComponent<BoxCollider2D>();
            spriteFlag.flipX = false;
            colliderFlag.enabled = false;
        }
        else if (collision.tag == "sceneTrigger")
        {
            sceneManager.loadEndScene();
        }
        else if (collision.tag == "finish")
        {
            effects.Win();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "enemyMedium" && growth.health <= 2)
        {
            enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.SetWalk();
            enemy = null;
            attackRadius = false;
        }
        if (collision.tag == "enemyBig" && growth.health <= 3)
        {
            enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.SetWalk();
            enemy = null;
            attackRadius = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "enemySmall" || collision.tag == "enemyMedium" || collision.tag == "enemyBig" || collision.tag == "enemyBoss")
        {
            enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.SetWalk();
            enemy = null;
            attackRadius = false;
        }
    }
}
