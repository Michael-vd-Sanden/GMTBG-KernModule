using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    
    private LoadScenes loadScenes;
    private ManagerPlayers managePlayers;
    private GameObject players;
    private MovementController movement;

    public bool isDefeated = false;

    private void Start()
    {
        players = GameObject.FindGameObjectWithTag("Player");
        movement = players.GetComponent<MovementController>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        loadScenes = gameManager.GetComponent<LoadScenes>();
        managePlayers = gameManager.GetComponent<ManagerPlayers>();
    }

    private void Update()
    {
        if(isDefeated)
        { 
            Destroy(gameObject);
            movement.RemovepurpleTiles();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        movement.SetPlayersBack();
        loadScenes.loadBattleScene();
        managePlayers.setPlayersToFalse();
    }
}
