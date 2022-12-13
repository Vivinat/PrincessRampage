using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{

    [SerializeField]
    private Slider slider;
    public float FillSpeed = 0.5f;
    private int target = 0;

    public static ProgressBar instance; 

    // Start is called before the first frame update
    void Start()
    {
        //Increment(101);
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < target)
        {
            slider.value += FillSpeed;
        }
        if (slider.value >= 100)
        {
            slider.value = 0f;
            target = 0;
        }

        if (SceneManager.GetActiveScene().name == "DeathScene")
        {
            Destroy(gameObject);
        }
    }

    public void Increment(int newProgress)
    {
        print("Tome XP");
        target = (int)slider.value + newProgress;
    }
}
