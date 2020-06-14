using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarTimer : MonoBehaviour
{
    Image fillImage;
    float timeAmt = 10;
    float time;

    void Start()
    {
        fillImage = this.GetComponent<Image>();
        time = timeAmt;
    }

    void Update()
    {
        if(time > 0) {
            time -= Time.deltaTime;
            fillImage.fillAmount = time / timeAmt;
        }
    }
}
