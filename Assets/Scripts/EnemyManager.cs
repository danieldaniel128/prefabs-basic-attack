using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Transform> enemySpawnPoints;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate = 2;
    private float _nextActionTime = 0.0f;
    private int _firstEnemySpawnPointNumber = -1;

   
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextActionTime)
        {
            _nextActionTime += spawnRate;
            if (_firstEnemySpawnPointNumber < enemySpawnPoints.Count - 1)
            {
                _firstEnemySpawnPointNumber++;
                Debug.Log("spawn point is: " + _firstEnemySpawnPointNumber);
            }
            else
            {
                _firstEnemySpawnPointNumber = 0;
            }

            CreateEnemy(_firstEnemySpawnPointNumber);
        }
    }

    private void CreateEnemy(int enemySpawnPointNumber)
    {
        Vector3 localSpawnPoint = new Vector3(enemySpawnPoints[enemySpawnPointNumber].position.x,
            enemySpawnPoints[enemySpawnPointNumber].position.y,
            enemySpawnPoints[enemySpawnPointNumber].position.z);
        Instantiate(enemyPrefab,localSpawnPoint,enemySpawnPoints[enemySpawnPointNumber].localRotation );
        // Instantiate(enemyPrefab, enemySpawnPoints[enemySpawnPointNumber] );
    }    
}
