using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    private LoadScenes loadScenes;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        loadScenes = gameManager.GetComponent<LoadScenes>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        loadScenes.loadBattleScene();
    }
}
