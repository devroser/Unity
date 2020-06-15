using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject nextEnemyLevel;
    public GameObject countDownBar;

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
            
            GameObject nextEnemyLevelObject = Instantiate(nextEnemyLevel, transform.position, transform.rotation) as GameObject;
            GameObject countDownBarObject = Instantiate(countDownBar, new Vector3(transform.position.x,transform.position.y-2f), transform.rotation) as GameObject;
            countDownBarObject.transform.parent = nextEnemyLevelObject.transform;
            
        }
    }
    private bool isObjectWithGreaterID(Collision collision){
        return gameObject.GetInstanceID() > collision.gameObject.GetInstanceID();
    }
}
