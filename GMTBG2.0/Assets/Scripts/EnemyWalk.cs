using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] private Transform pointRight, pointLeft;
    [SerializeField] private SpriteRenderer enemySprite;
    [SerializeField] private Animator enemyAnimator;
    public Transform currentTarget;

    private void Start()
    {
        
    }
    private void Update()
    {
        EnemyMove();
    }

    public void EnemyMove()
    {
        if (transform.position.x >= pointRight.position.x - 0.5f)
        {
            currentTarget = pointLeft;
            enemySprite.flipX = false;
            //enemyAnimator.SetTrigger("idle");
        }
        else if(transform.position.x <= pointLeft.position.x + 0.5f)
        {
            currentTarget = pointRight;
            enemySprite.flipX = true;
            //enemyAnimator.SetTrigger("idle");
        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, 1f * Time.deltaTime);
    }

}
