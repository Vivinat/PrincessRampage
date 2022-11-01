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

    // Update is called once per frame
    void Update()
    {
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
            SceneManager.LoadScene(nextStage);
        }
    }
}
