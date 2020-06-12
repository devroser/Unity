using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject nextEnemyLevel;

    void OnCollisionEnter(Collision collision)
    {
        if (hasSameTag(collision) && hasNextEnemyLevel())
        {
            Destroy(gameObject);            
            createNextEnemyLevel(collision);
        }
    }

    private bool hasSameTag(Collision collision){
        return gameObject.tag == collision.gameObject.tag;
    }
    private bool hasNextEnemyLevel(){
        return nextEnemyLevel != null;
    }

    private void createNextEnemyLevel(Collision collision){
        if(isObjectWithGreaterID(collision)){
            Instantiate(nextEnemyLevel, transform.position, transform.rotation);            
        }
    }
    private bool isObjectWithGreaterID(Collision collision){
        return gameObject.GetInstanceID() > collision.gameObject.GetInstanceID();
    }
}
