using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleButtons : MonoBehaviour
{
    [SerializeField] private GameObject attackScreen;
    [SerializeField] private FightScript fight;

    //KNIGHT
    public void AttackKnight()
    {
        fight.SetSuccessbarScale(0.8f);
        fight.isActive = true;
        attackScreen.SetActive(true);
    }
    public void HealKnight()
    {

    }
    public void AbilityKnight()
    {

    }

    //FIGHTER
    public void AttackFighter()
    {
        fight.SetSuccessbarScale(0.5f);
        fight.isActive = true;
        attackScreen.SetActive(true);
    }
    public void HealFighter()
    {

    }
    public void Abilityfighter()
    {

    }

    //SCOUT
    public void AttackScout()
    {
        fight.SetSuccessbarScale(0.2f);
        fight.isActive = true;
        attackScreen.SetActive(true);
    }

    //HEALER
    public void AttackHealer()
    {
        fight.SetSuccessbarScale(0.1f);
        fight.isActive = true;
        attackScreen.SetActive(true);
    }
}
