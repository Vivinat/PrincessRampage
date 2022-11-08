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
        Debug.Log("Load game");         //Clicou no botão Jogar
        AudioManager.instance.StopSound("Menu");
        SceneManager.LoadScene("Story_Intro");
    }

    public void PlayEndlessMode()       //Clicou no Endless
    {
        Debug.Log("Endless Mode");
        AudioManager.instance.StopSound("Menu");
        SceneManager.LoadScene("Endless_Mode");
    }

    public void QuitGame()              //Sai do jogo
    {
        Debug.Log("Saiu");
        Application.Quit();
    }

    private void Start()                //Se eu estiver no Menu, toque a musica do menu
    {
        if (!(AudioManager.instance.IsPlaying("Menu")) && SceneManager.GetActiveScene().name == "Menu")
        {
            AudioManager.instance.PlaySound("Menu");
        }
    }

}
