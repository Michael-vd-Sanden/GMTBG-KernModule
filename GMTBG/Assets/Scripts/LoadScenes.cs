using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{

    public void loadBattleScene()
    {
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Additive);  
    }

    public void loadMainScene()
    {
        SceneManager.UnloadSceneAsync("BattleScene");
        //SceneManager.LoadScene("MainScene");
    }

    public string getActiveScene()
    {
        return SceneManager.GetActiveScene().name;
    }
}
