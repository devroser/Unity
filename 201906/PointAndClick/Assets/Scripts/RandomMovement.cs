using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed;
    public bool restless;
    public float minTimeToChangeDirection;
    public float maxTimeToChangeDirection;

    private Rigidbody rb;
    
    private Vector2 randomDirection;
    private Vector2 randomSpeed;

    private float timeToChangeDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        updateEnemyMovement();

        if(restless == true){
            StartCoroutine(RestlessEnemy());
        }
    }

    private void updateEnemyMovement()
    {
        RandomDirection();
        RandomSpeed();
        SetVelocity();
    }

    private void RandomDirection()
    {
        randomDirection = new Vector2(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f));
    }
    
    private void RandomSpeed()
    {
        randomSpeed = new Vector2(randomDirection.x*speed, randomDirection.y*speed );
    }
    
    private void SetVelocity()
    {
        rb.velocity = randomSpeed;
    }

    IEnumerator RestlessEnemy()
    {
        timeToChangeDirection = Random.Range(minTimeToChangeDirection,maxTimeToChangeDirection);
            
        while(true){
            yield return new WaitForSeconds(timeToChangeDirection);
            updateEnemyMovement();
        }
    }

}
