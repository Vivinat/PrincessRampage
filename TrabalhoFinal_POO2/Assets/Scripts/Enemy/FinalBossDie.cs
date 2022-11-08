using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBossDie : MonoBehaviour
{
    public GameObject finalboss; 
    public string nextStage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Como não tem timer no estagio final, precisamos saber quando a bruxa morre
    void Update()
    {
        //Se ela é null, significa que morreu
        if (finalboss == null)
        {
            GameObject[] spawn = GameObject.FindGameObjectsWithTag("Spawner");
            foreach(GameObject spa in spawn){
                Destroy(spa);
            }
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject ene in enemies){
                Destroy(ene);
            }
            AudioManager.instance.StopSound("Final_Boss");
            SceneManager.LoadScene(nextStage);  //Leva pra proxima cena
        }
    }
}
