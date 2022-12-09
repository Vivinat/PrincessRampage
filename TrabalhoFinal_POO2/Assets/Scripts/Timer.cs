using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    public float currentTime = 0f;   //Tempo atual
    public bool countDown = true;      //Queremos que o contador acrescente ou decresça?
    public bool hasLimit = true;       //Temos um limite?
    public float timerLimit = 10f;    //Se tivermos, qual?
    public string nextStage;
    private int timeSpawn = 10;
    private int SpawnFlag = 1;

    //Queria ter feito um vetor de spawners, mas o unity tava chorando demais
    public GameObject RedSlimeSpawn;
    public GameObject GrSlimeSpawn;
    public GameObject GoblinSpawn;
    public GameObject OrSlimeSpawn;
    public GameObject SkeletonSpawn;
    public GameObject MushroomSpawn;
    public GameObject GolenSpawn;
    public GameObject WitchSpawn;

    void Start()
    {
        timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        //Operador ternário
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if (SceneManager.GetActiveScene().name == "Endless_Mode")   //Se voce estiver no endless
        {
            if (currentTime >= timeSpawn && SpawnFlag == 1) //Ligue estes spawners e set a flag para que este comando não se repita
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

            GameObject[] spawn = GameObject.FindGameObjectsWithTag("Spawner");  //Quando tempo acaba, spawners são destruidos
            foreach(GameObject spa in spawn){
                Destroy(spa);
            }

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");  //E os inimigos também
            foreach(GameObject ene in enemies){
                Destroy(ene);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(nextStage);  //Coloquei essa key de precaução, por que aconteceu uma vez do tp não funfar  
            }

            SceneManager.LoadScene(nextStage);
            enabled = false;
        }
        SetTimerText();
    }

    private void SetTimerText()     //Converse com o texto na UI
    {
        timerText.text = currentTime.ToString("0.00");
    }
}
