using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistCanvas : MonoBehaviour
{

    void Awake()
    {
        if (FindObjectsOfType<PersistCanvas>().Length > 1)
        {
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "FinalBoss")
        {
            var timeObj = GameObject.Find("Timer");
            if (timeObj != null)
            {
                var time = timeObj.GetComponent<TextMeshProUGUI>();
                Destroy(time);
            }
        }
        else
        {
            var bossLifeBarObj = GameObject.Find("LifeBar");
            
            if(bossLifeBarObj != null)
            {
                var bossLifeBar = GetComponent<TextMeshProUGUI>();
                Destroy(bossLifeBarObj);
            }
        }
        
        if (SceneManager.GetActiveScene().name == "DeathScene")
        {
            Destroy(gameObject);
        }
    }
}
