using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleButtons : MonoBehaviour
{
    [SerializeField] private GameObject attackScreen;
    [SerializeField] private FightScript fight;
    [SerializeField] GetMonster getMonster;

    [SerializeField] private Button AtKnight;
    [SerializeField] private Button HKnight;
    [SerializeField] private Button AbKnight;

    [SerializeField] private Button AtFighter;
    [SerializeField] private Button HFighter;
    [SerializeField] private Button AbFighter;

    [SerializeField] private Button AtScout;
    [SerializeField] private Button HScout;
    [SerializeField] private Button AbScout;

    [SerializeField] private Button AtHealer;
    [SerializeField] private Button HHealer;
    [SerializeField] private Button AbHealer;

    //KNIGHT
    public void AttackKnight()
    {
        fight.SetSuccessbarScale(0.8f);
        fight.isActive = true;
        attackScreen.SetActive(true);
        ClickedKnight();
    }
    public void HealKnight()
    {
        ClickedKnight();
        getMonster.ChangeMonsterIndex();
    }
    public void AbilityKnight()
    {
        ClickedKnight();
        getMonster.ChangeMonsterIndex();
    }

    public void ClickedKnight()
    {
        AtKnight.enabled = false;
        HKnight.enabled = false;
        AbKnight.enabled = false;
        CheckIfTurn();
    }

    //FIGHTER
    public void AttackFighter()
    {
        fight.SetSuccessbarScale(0.5f);
        fight.isActive = true;
        attackScreen.SetActive(true);
        ClickedFighter();
    }
    public void HealFighter()
    {
        ClickedFighter();
        getMonster.ChangeMonsterIndex();
    }
    public void Abilityfighter()
    {
        ClickedFighter();
        getMonster.ChangeMonsterIndex();
    }

    public void ClickedFighter()
    {
        AtFighter.enabled = false;
        HFighter.enabled = false;
        AbFighter.enabled = false;
        CheckIfTurn();
    }

    //SCOUT
    public void AttackScout()
    {
        fight.SetSuccessbarScale(0.2f);
        fight.isActive = true;
        attackScreen.SetActive(true);
        ClickedScout();
    }
    public void HealScout()
    {
        ClickedScout();
        getMonster.ChangeMonsterIndex();
    }
    public void AbilityScout()
    {
        ClickedScout();
        getMonster.ChangeMonsterIndex();
    }

    public void ClickedScout()
    {
        AtScout.enabled = false;
        HScout.enabled = false;
        AbScout.enabled = false;
        CheckIfTurn();
    }

    //HEALER
    public void AttackHealer()
    {
        fight.SetSuccessbarScale(0.1f);
        fight.isActive = true;
        attackScreen.SetActive(true);
        ClickedHealer();
    }
    public void HealHealer()
    {
        ClickedHealer();
        getMonster.ChangeMonsterIndex();
    }
    public void AbilityHealer()
    {
        ClickedHealer();
        getMonster.ChangeMonsterIndex();
    }

    public void ClickedHealer()
    {
        AtHealer.enabled = false;
        HHealer.enabled = false;
        AbHealer.enabled = false;
        CheckIfTurn();
    }

    //CHECK IF ALL WENT
    public void CheckIfTurn()
    {
        if(AtFighter.enabled == false && AtHealer.enabled == false && AtKnight.enabled == false && AtScout.enabled == false)
        {
            AtKnight.enabled = true;
            HKnight.enabled = true;
            AbKnight.enabled = true;
            AtFighter.enabled = true;
            HFighter.enabled = true;
            AbFighter.enabled = true;
            AtScout.enabled = true;
            HScout.enabled = true;
            AbScout.enabled = true;
            AtHealer.enabled = true;
            HHealer.enabled = true;
            AbHealer.enabled = true;
        }
    }
}
