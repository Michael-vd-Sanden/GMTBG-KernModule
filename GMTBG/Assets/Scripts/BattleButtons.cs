using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleButtons : MonoBehaviour
{
    [SerializeField] private GameObject attackScreen;
    [SerializeField] private FightScript fight;
    [SerializeField] private GetMonster monster;


    public void AttackKnight()
    {
        fight.isActive = true;
        attackScreen.SetActive(true);
        monster.ChangeMonsterIndex();
    }

    public void HealKnight()
    {

    }

    public void AbilityKnight()
    {

    }
}
