using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownBarAnimation : MonoBehaviour
{
    public GameObject countdownBar;
    private BarFilling barFilling;

    void Start()
    {
        barFilling = countdownBar.GetComponent<BarFilling>();
		barFilling.SetSize(.4f);
    }
    
}
