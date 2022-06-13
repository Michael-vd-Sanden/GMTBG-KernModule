using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMonster : MonoBehaviour
{
    public MonsterScript[] monsters;
    [SerializeField] private int monsterIndex = -1;

    public void ChangeMonsterIndex()
    {
        if (monsterIndex == 2)
        { monsterIndex = 0; }
        else
        { monsterIndex++; }
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
