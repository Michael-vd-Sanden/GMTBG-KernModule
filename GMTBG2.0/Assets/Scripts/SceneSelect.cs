using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    public void loadTutorialLevel()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void loadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void loadEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void quit()
    {
        Application.Quit();
    }
}
