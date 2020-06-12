using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByRaycast : MonoBehaviour
{

    void Update()
    {
        DestroyOnClick();
    }

    private void DestroyOnClick()
    {
        if (LeftMouseClicked())
        {
            DetectRayCastHitAndDestroy();
        }
    }
    private bool LeftMouseClicked(){
        return Input.GetMouseButtonDown(0);
    }        
    private void DetectRayCastHitAndDestroy()
    {
        RaycastHit rayCastHit;
        Ray ray = GetScreenPointToRay();

        if (RayCastHits(ray,out rayCastHit))
        {
            DestroyGameObject(rayCastHit);
        }
    }

    private static Ray GetScreenPointToRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    private bool RayCastHits(Ray ray, out RaycastHit rayCastHit)
    {
        return Physics.Raycast(ray, out rayCastHit);
    }
    private void DestroyGameObject(RaycastHit rayCastHit)
    {
        BoxCollider boxCollider = rayCastHit.collider as BoxCollider;
        if (boxCollider != null)
        {
            Destroy(boxCollider.gameObject);
        }
    }
}
