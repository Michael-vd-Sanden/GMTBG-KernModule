using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScores : MonoBehaviour
{
    public FloatVariable deaths;
    public FloatVariable kills;

    private void Start()
    {
        deaths.Value = 0f;
        kills.Value = 0f;
    }

    public void upDeaths()
    {
        deaths.Value++;
    }

    public void upKills()
    {
        kills.Value++;
    }
}
