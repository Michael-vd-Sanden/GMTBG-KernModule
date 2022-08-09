using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private FightingControlls player;

    void Start()
    {
        health = 5;
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
