using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void LoadLevel(string name)  //Carrega cena com nome igual ao name 
    {
        SceneManager.LoadScene(name);
    }

    public void PlayGame()
    {
        Debug.Log("Load game");
        AudioManager.instance.StopSound("Menu");
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()              //Sai do jogo
    {
        Debug.Log("Saiu");
        Application.Quit();
    }

    private void Start()
    {
        if (!(AudioManager.instance.IsPlaying("Menu")) && SceneManager.GetActiveScene().name == "Menu")
        {
            AudioManager.instance.PlaySound("Menu");
        }
    }

}
