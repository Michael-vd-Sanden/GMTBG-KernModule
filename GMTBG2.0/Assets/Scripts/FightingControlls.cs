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

    private PlayerGrowth player;

    void Start()
    {
        attackDamage = 2f;
        player = FindObjectOfType<PlayerGrowth>();
    }

    void Update()
    {
        SwingSword();
    }

    public void SetAttackDamage(float newDamage)
    {
        attackDamage = newDamage;
    }

    public void SwingSword()
    {
        if (Input.GetMouseButtonDown(0) && attackRadius)
        {
            //attack
            if (enemy != null)
            {
                enemy.GetHit(attackDamage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemySmall" || collision.tag == "enemyMedium" || collision.tag == "enemyBig" || collision.tag == "enemyBoss")
        {
            enemy = collision.gameObject.GetComponent<EnemyController>();
            attackRadius = true;
        }
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
            sceneManager.loadMainScene();
        }
        else if (collision.tag == "finish")
        {
            effects.Win();
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
