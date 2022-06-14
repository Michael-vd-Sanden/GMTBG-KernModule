using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMonster : MonoBehaviour
{
    public MonsterScript[] monsters;
    [SerializeField] private int monsterIndex = 0;

    [SerializeField] private GameObject arrow;

    public void ChangeMonsterIndex()
    {
        if (monsterIndex == 2)
        { monsterIndex = 0; }
        else
        { monsterIndex++; }

        if(monsterIndex == 0)
        {
            arrow.transform.position = new Vector3(0, 0, 0);
        }
        else if (monsterIndex == 1)
        {
            arrow.transform.position = new Vector3(0.8f, 0, 0);
        }
        else if (monsterIndex == 2)
        {
            arrow.transform.position = new Vector3(-0.8f, 0, 0);
        }
    }

    public MonsterScript getActiveMonster()
    {
        return monsters[monsterIndex];
    }

    public bool checkIfActive()
    {
        for (int i = 0; i < monsters.Length; i++)
        {
            if(monsters[i].isActiveAndEnabled == true)
            {
                return false;
            }
        }
        return true;
    }
}
