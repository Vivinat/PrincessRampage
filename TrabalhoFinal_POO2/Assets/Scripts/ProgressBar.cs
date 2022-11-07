using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBar : MonoBehaviour
{

    [SerializeField]
    private Slider slider;
    public float FillSpeed = 0.5f;
    private int target = 100;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Increment(101);
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
    }

    public void Increment(int newProgress)
    {
       target = (int)slider.value + newProgress;
    }
}
