using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private bool isSpawnerActive = true;
    [SerializeField] private GameObject enemyPrefab;

    public float spawnRate = 5f;
    public int maxEnemys = 4;
    public List<GameObject> enemyCount;

    GameObject[] spawn; 

    void Start()
    {
        spawn = GameObject.FindGameObjectsWithTag("SpawnPoint");
        StartCoroutine(SpawnRoutine());
    }


    void Update()
    {
        if (gameObject == false)
        {
            isSpawnerActive = false;
        }

        foreach (GameObject enemy in enemyCount)
        {
            if (enemy.gameObject == false)
            {
                enemyCount.Remove(enemy);
            }
        }
    }

    IEnumerator SpawnRoutine()
    {
        Vector3 basicVector = new Vector3(0, 0, 0);
        Vector3 plusVector = new Vector3(1, 1, 0);
        Vector3 maxVextor = new Vector3(10, 10, 0);
        while (isSpawnerActive)
        {
            if (enemyCount.Count < maxEnemys)
            {
                foreach (GameObject s in spawn)
                {
                    if (s.transform.childCount > 0)//has child
                    {
                        
                    }
                    else
                    {
                        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                        newEnemy.transform.parent = s.transform;
                        newEnemy.transform.position = new Vector3(0, 0, 0);
                        enemyCount.Add(newEnemy);
                        yield return new WaitForSeconds(spawnRate);
                    }
                }
                
                //GameObject newEnemy = Instantiate(enemyPrefab, transform.position + basicVector, Quaternion.identity);
                
                basicVector += plusVector;
                if(basicVector == maxVextor)
                {
                    basicVector = new Vector3(0, 0, 0);
                }
            }
            
        }
    }

    public bool isSpawnPointAvailable()
    {

        
        return false;
    }
}
