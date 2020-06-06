using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovimient : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2;
    private Vector3 movement = new Vector3();

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    void Update(){

        ProcessInputs();
        Move();

    }

    private void ProcessInputs()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);
        movement.Normalize();
    }
 
    private void Move()
    {
        transform.position = transform.position + (movement * speed * Time.deltaTime);
    }
}
