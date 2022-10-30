using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    public float currentTime = 0f;   //Tempo atual
    public bool countDown = true;      //Queremos que o contador acrescente ou decresça?
    public bool hasLimit = true;       //Temos um limite?
    public float timerLimit = 10f;    //Se tivermos, qual?

    // Update is called once per frame
    void Update()
    {
        //Operador ternário
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        //Precisamos saber se estamos decrescendo o timer ou acrescendo
        if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            GameObject[] spawn = GameObject.FindGameObjectsWithTag("Spawner");
            foreach(GameObject spa in spawn){
                Destroy(spa);
            }
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject ene in enemies){
                Destroy(ene);
            }

            enabled = false;
        }
        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.00");
    }
}