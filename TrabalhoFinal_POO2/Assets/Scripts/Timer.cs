using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //RedSlimeSpawn.SetActive(true);

    public TextMeshProUGUI timerText;
    public float currentTime = 0f;   //Tempo atual
    public bool countDown = true;      //Queremos que o contador acrescente ou decresça?
    public bool hasLimit = true;       //Temos um limite?
    public float timerLimit = 10f;    //Se tivermos, qual?
    public string nextStage;
    private int timeSpawn = 10;
    private int SpawnFlag = 1;

    public GameObject RedSlimeSpawn;
    public GameObject GrSlimeSpawn;
    public GameObject GoblinSpawn;
    public GameObject OrSlimeSpawn;
    public GameObject SkeletonSpawn;
    public GameObject MushroomSpawn;
    public GameObject GolenSpawn;
    public GameObject WitchSpawn;

    // Update is called once per frame
    void Update()
    {
        //Operador ternário
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if (SceneManager.GetActiveScene().name == "Endless_Mode")
        {
            if (currentTime >= timeSpawn && SpawnFlag == 1)
            {
                RedSlimeSpawn.SetActive(true);
                GrSlimeSpawn.SetActive(true);
                GoblinSpawn.SetActive(true);
                timeSpawn += 15;
                SpawnFlag += 1;
            }
            if (currentTime >= timeSpawn && SpawnFlag == 2)
            {
                OrSlimeSpawn.SetActive(true);
                SkeletonSpawn.SetActive(true);
                MushroomSpawn.SetActive(true);
                timeSpawn += 15;
                SpawnFlag += 1;
            }
            if (currentTime >= timeSpawn && SpawnFlag == 3)
            {
                GolenSpawn.SetActive(true);
                timeSpawn += 15;
                SpawnFlag += 1;
            }
            if (currentTime >= timeSpawn && SpawnFlag == 4)
            {
                WitchSpawn.SetActive(true);
                timeSpawn += 15;
                SpawnFlag += 1;
            }
            else
            {
                
            }
        }

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

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(nextStage);    
            }

            SceneManager.LoadScene(nextStage);
            enabled = false;
        }
        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.00");
    }
}
