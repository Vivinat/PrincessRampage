using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        print("Estou na cena: " + SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "FinalBoss")
        {
            var time = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
            Destroy(time);
        }
        if (SceneManager.GetActiveScene().name == "DeathScene")
        {
            Destroy(gameObject);
        }
    }
}
