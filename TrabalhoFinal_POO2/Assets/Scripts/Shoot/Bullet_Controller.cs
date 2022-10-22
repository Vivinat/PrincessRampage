using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    public float lifeTime; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathDelay()); //Coroutine para saber quando destruimos a bala

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeathDelay(){
        yield return new WaitForSeconds(lifeTime);  //Espere a quantidade de tempo definido por lifeTime
        Destroy(gameObject);       //Depois, destrua o objeto (a bala)
    }
}
