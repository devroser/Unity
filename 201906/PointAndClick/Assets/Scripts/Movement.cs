using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private Vector3 movement = new Vector3();
    
    void Awake(){}

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
