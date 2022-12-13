using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CountManager : MonoBehaviour
{
    private float count = 0;
    public float deadline = 10;
    public string scene;

    // Update is called once per frame
    void Update()
    {
        if (count < deadline)
        {
            count += Time.deltaTime;
            //Este script basicamente deixa o player um tempinho numa cena e começa a contar até dar tp para proxima cena
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }
}
