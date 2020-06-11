using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject nextEnemyLevel;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasSameTag(collision) && hasNextEnemyLevel())
        {
            Destroy(gameObject);            
            createNextEnemyLevel(collision);
        }
    }

    private bool hasSameTag(Collision2D collision){
        return gameObject.tag == collision.gameObject.tag;
    }
    private bool hasNextEnemyLevel(){
        return nextEnemyLevel != null;
    }

    private void createNextEnemyLevel(Collision2D collision){
        if(isObjectWithGreaterID(collision)){
            Instantiate(nextEnemyLevel, transform.position, transform.rotation);            
        }
    }
    private bool isObjectWithGreaterID(Collision2D collision){
        return gameObject.GetInstanceID() > collision.gameObject.GetInstanceID();
    }
}
