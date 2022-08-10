using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private FightingControlls player;

    void Start()
    {
        if(gameObject.tag == "enemySmall")
        { health = 5; }
        if(gameObject.tag == "enemyMedium")
        { health = 20; }
        if(gameObject.tag == "enemyBig")
        { health = 50; }
        if(gameObject.tag == "enemyBoss")
        { health = 100; }
        player = FindObjectOfType<FightingControlls>();
    }

    void Update()
    {
        
    }

    public void GetHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            player.Grow();
            Destroy(gameObject);
        }
    }
}
