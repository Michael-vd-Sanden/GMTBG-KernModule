using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPlayers : MonoBehaviour
{
    [SerializeField] private GameObject players;

    void Start()
    {
        players = GameObject.FindGameObjectWithTag("Player");
    }

    public void setPlayersToFalse()
    {
        players.SetActive(false);
    }

    public void setPlayersToTrue()
    {
        players.SetActive(true);
    }
}
