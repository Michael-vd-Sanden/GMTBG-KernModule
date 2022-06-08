using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void loadBattleScene()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
