using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarFilling : MonoBehaviour
{
    private Transform bar;

    void Awake()
    {
        bar = transform.Find("Bar");
    }

    public void SetSize(float sizeNormalized){
        bar.localScale = new Vector3(sizeNormalized,1f);
    }
    public Vector3 GetScale(){
        return bar.localScale;
    }
    
}
