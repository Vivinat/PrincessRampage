using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountManager : MonoBehaviour
{
    public float count;
    public float deadline = 10;
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count < deadline)
        {
            count += Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }
}
