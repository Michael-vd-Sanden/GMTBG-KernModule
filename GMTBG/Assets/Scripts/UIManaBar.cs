using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManaBar : MonoBehaviour
{
    [SerializeField] private SpriteRenderer mana1;
    [SerializeField] private SpriteRenderer mana2;
    [SerializeField] private SpriteRenderer mana3;

    public void MinusMana()
    {
        if(mana3.enabled)
        {
            mana3.enabled = false;
        }
        else if(mana2.enabled)
        {
            mana2.enabled = false;
        }
        else if(mana1.enabled)
        {
            mana1.enabled = false;
        }
        else
        {
            Debug.Log("OUT OF MANA");
        }
    }

    public void PlusMana()
    {
        if (mana1.enabled == false)
        {
            mana1.enabled = true;
        }
        else if (mana2.enabled == false)
        {
            mana2.enabled = true;
        }
        else if (mana3.enabled == false)
        {
            mana3.enabled = true;
        }
        else
        {
            Debug.Log("TOO MUCH MANA");
        }
    }
}
