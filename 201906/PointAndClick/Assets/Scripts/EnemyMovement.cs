using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rigidBody2;

    private Vector3 movement = new Vector3();
    private Vector2 currentMousePosition;
    private Vector2 worldMousePosition;
    
    void Awake()
    {
        rigidBody2 = GetComponent<Rigidbody2D>();
        
    }

    void Update(){
        
        ProcessInputs();
        
        Move();
        DestroyOnClick();
    }

    private void ProcessInputs()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);
        movement.Normalize();
        currentMousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
    }    

    private void Move()
    {
        transform.position = transform.position + (movement * speed * Time.deltaTime);

    }

    private void DestroyOnClick()
    {
        if (LeftMouseClicked())
        {
            DetectRayCastCollisionAndDestroy();
        }
    }
    private bool LeftMouseClicked(){
        return Input.GetMouseButtonDown(0);
    }        
    private void DetectRayCastCollisionAndDestroy()
    {
       worldMousePosition = UpdateWorldMousePosition();
       
       RaycastHit2D hit = Physics2D.Raycast(worldMousePosition, Vector2.zero);
       if(hit.collider != null) {
           Destroy(hit);
        }
    }
    private Vector2 UpdateWorldMousePosition()
    {
        return Camera.main.ScreenToWorldPoint (currentMousePosition);
    }
    private void Destroy(RaycastHit2D hit){
        if(hit.collider.gameObject==gameObject){
        Destroy(gameObject); 
        }        
    }
}
