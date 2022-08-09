using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingControlls : MonoBehaviour
{
    public CameraController mainCam;
    private bool attackRadius = false;
    [SerializeField] private EnemyController enemy;
    [SerializeField] private PlayerController movement;
    [SerializeField] private int attackDamage;

    void Start()
    {
        attackDamage = 2;
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
            if(enemy != null)
            {
                enemy.GetHit(attackDamage);
            } 
        }
    }

    public void Grow()
    {
        movement.jumpForce += 0.2f;
        attackDamage += 1;
        gameObject.transform.localScale += new Vector3 (0.2f, 0.2f);
        mainCam.cameraPlusX -= 0.04f;
        mainCam.cameraPlusY -= 0.1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy = collision.gameObject.GetComponent<EnemyController>();
        attackRadius = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy = null;
        attackRadius = false;
    }
}
