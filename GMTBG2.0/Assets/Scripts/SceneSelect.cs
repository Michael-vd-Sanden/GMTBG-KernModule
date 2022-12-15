using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    public void loadTutorialLevel()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void loadMainScene()
    {
        SceneManager.LoadScene("Main2.0Scene");
    }

    public void loadEndScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void quit()
    {
        Application.Quit();
    }
}
