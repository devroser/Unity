using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    
    public Vector2 spawnValues;	
    public int enemyCount;
	public float startWait;
    public float spawnWait;
	

    void Start()
    {
        StartCoroutine (SpawnWaves());
    }

    void Update()
    {
        
    }


    IEnumerator SpawnWaves(){

		yield return new WaitForSeconds(startWait);
		while(true){
			for(int i = 0; i < enemyCount; i++){
				Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y));
				Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, spawnPosition,spawnRotation);
                yield return new WaitForSeconds(spawnWait);
			}
		}
	}
}
