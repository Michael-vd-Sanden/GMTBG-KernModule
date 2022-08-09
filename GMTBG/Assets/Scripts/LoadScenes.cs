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

    public void unloadBattleScene()
    {
        SceneManager.UnloadSceneAsync("BattleScene");
        //SceneManager.LoadScene("MainScene");
    }

    public void loadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void loadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void quitScene()
    {
        Application.Quit();
    }

    public void loadControls(GameObject g)
    {
        g.SetActive(true);
    }

    public void unloadContols(GameObject g)
    {
        g.SetActive(false);
    }

    public string getActiveScene()
    {
        return SceneManager.GetActiveScene().name;
    }
}
