using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownBarAnimation : MonoBehaviour
{
    public float defaultCountDownTime;
    private float recentCountDownTime;

    private Vector3 barScale;
    private float defaultBarScaleX;

    private float unitaryScale;

    public GameObject countdownBar;
    private BarFilling barFilling;

    void Start()
    {
        PreinitializationVariables();
        StartCoroutine(CountDownBarAnimation());
    }

    private void PreinitializationVariables()
    {
        barFilling = countdownBar.GetComponent<BarFilling>();
        barScale = barFilling.GetScale();
        defaultBarScaleX = barScale.x;

        unitaryScale = defaultBarScaleX / defaultCountDownTime;
        recentCountDownTime = defaultCountDownTime;
    }

    private IEnumerator CountDownBarAnimation(){

        while (CountdownIsNotOver()){
            UpdateCountDownBar();            
            yield return StartCoroutine (CheckCountdownOver());
            yield return StartCoroutine (DecreaseCountdownTime());            
        }
    }

    private bool CountdownIsNotOver(){
        return recentCountDownTime >= 0;
    }
    
    private void UpdateCountDownBar()
    {
        barFilling.SetSize(unitaryScale * recentCountDownTime);
    }

    private IEnumerator CheckCountdownOver(){
        if (CountdownIsOver()){
            EnemyHit();
            yield return StartCoroutine (RestartCountDownBar());
        } 
    }
    private bool CountdownIsOver(){
        return recentCountDownTime == 0;
    }
    private void EnemyHit(){
        Debug.Log("Enemy hit");
    }
    private IEnumerator RestartCountDownBar()
    {
        yield return new WaitForSeconds(1);
        barFilling.SetSize(defaultBarScaleX);
        recentCountDownTime = defaultCountDownTime;
    }

    private IEnumerator DecreaseCountdownTime(){
        yield return new WaitForSeconds(1);
        recentCountDownTime--;
    }

}
