using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnimation : MonoBehaviour
{
    [SerializeField] Animator knightAnimator;
    [SerializeField] Animator scoutAnimator;
    [SerializeField] Animator fighterAnimator;
    [SerializeField] Animator healerAnimator;
    LoadScenes loadScenes;

    private void Awake()
    {
        loadScenes = GetComponentInChildren<LoadScenes>();
        checkAnimation();
    }

    private void checkAnimation()
    {
        if (loadScenes.getActiveScene() == "BattleScene")
        {
            knightAnimator.SetBool("InBattle", true);
            scoutAnimator.SetBool("InBattle", true);
            fighterAnimator.SetBool("InBattle", true);
            healerAnimator.SetBool("InBattle", true);
        }
        else if (loadScenes.getActiveScene() == "MainScene")
        {
            knightAnimator.SetBool("InBattle", false);
            scoutAnimator.SetBool("InBattle", false);
            fighterAnimator.SetBool("InBattle", false);
            healerAnimator.SetBool("InBattle", false);
        }
    }
}
