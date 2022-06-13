using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public int maxHealth = 5;
    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
