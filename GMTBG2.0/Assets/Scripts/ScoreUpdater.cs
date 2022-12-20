using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    public FloatReference deaths;
    public FloatReference kills;

    [SerializeField] private TMP_Text deathCount;
    [SerializeField] private TMP_Text killCount;

    private void Start()
    {
        deathCount.text = deaths.Value.ToString();
        killCount.text = kills.Value.ToString();
    }
}
