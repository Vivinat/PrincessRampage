using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    [SerializeField]
    private string soundName;

    private void Start()
    {
        if (soundName == "")
            Destroy(this);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlaySound(soundName);
            Destroy(this, 0.1f);
        }
    }
}
