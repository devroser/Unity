using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemy;    
    public Vector2 spawnIntervalCoordinates;	
    
    public float secondsToRespawn;

    void Start()
    {
        InvokeRepeating("SpawnEnemy",1.0f,secondsToRespawn);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-spawnIntervalCoordinates.x, spawnIntervalCoordinates.x), Random.Range(-spawnIntervalCoordinates.y, spawnIntervalCoordinates.y));
		Quaternion spawnRotation = Quaternion.identity;
        Instantiate(enemy,spawnPosition,spawnRotation);   
    }
    
}
