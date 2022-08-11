using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingControlls : MonoBehaviour
{
    public CameraController mainCam;
    private bool attackRadius = false;
    [SerializeField] private EnemyController enemy;
    [SerializeField] private PlayerController movement;
    [SerializeField] private float attackDamage;
    [SerializeField] private SceneSelect sceneManager;

    void Start()
    {
        attackDamage = 2f;
    }

    void Update()
    {
        SwingSword();
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

    public void Grow()
    {
        movement.jumpForce += 0.3f;
        movement.walkingSpeed += 10f;
        attackDamage += 1f;
        gameObject.transform.localScale += new Vector3 (0.2f, 0.2f);
        mainCam.zoomOut();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemySmall" || collision.tag == "enemyMedium" || collision.tag == "enemyBig" || collision.tag == "enemyBoss")
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
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "enemySmall" || collision.tag == "enemyMedium" || collision.tag == "enemyBig" || collision.tag == "enemyBoss")
        {
            enemy = null;
            attackRadius = false;
        }
    }
}
