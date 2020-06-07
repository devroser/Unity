using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByRaycast : MonoBehaviour
{

    private Vector2 currentMousePosition;
    private Vector2 worldMousePosition;
    

    void Start(){}

    void Update()
    {
        ProcessInputs();
        DestroyOnClick();
    }

    private void ProcessInputs()
    {
        currentMousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
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
