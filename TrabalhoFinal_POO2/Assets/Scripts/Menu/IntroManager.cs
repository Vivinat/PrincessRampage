using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    void Update(){
        //Na proxima vez que essa animação tocar (Ou seja, quando normalizedTime for maior que zero, leve o player pro menu)
        if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
        SceneManager.LoadScene("Menu");
        }    
    }

}
