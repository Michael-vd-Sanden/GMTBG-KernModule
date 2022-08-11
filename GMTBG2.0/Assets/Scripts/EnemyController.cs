using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float startHealth;
    [SerializeField] private FightingControlls player;
    [SerializeField] private SpriteMask healthMask;

    private float health;

    void Start()
    {
        if(gameObject.tag == "enemySmall")
        { startHealth = 5f; }
        if(gameObject.tag == "enemyMedium")
        { startHealth = 20f; }
        if(gameObject.tag == "enemyBig")
        { startHealth = 50f; }
        if(gameObject.tag == "enemyBoss")
        { startHealth = 100f; }
        player = FindObjectOfType<FightingControlls>();
        health = startHealth;
    }

    void Update()
    {
        
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
}
