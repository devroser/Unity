using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed;
    
    private Rigidbody2D rb2D;
    
    private Vector2 randomDirection;
    private Vector2 randomSpeed;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
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
        randomSpeed = new Vector2(Random.Range(-randomDirection.x,randomDirection.x)*speed, Random.Range(-randomDirection.y,randomDirection.y)*speed );
    }
    
    private void SetVelocity()
    {
        rb2D.velocity = randomSpeed;
    }

}
