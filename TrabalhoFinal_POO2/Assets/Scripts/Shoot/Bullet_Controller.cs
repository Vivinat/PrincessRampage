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


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Enemy"){ //Se minha bala acerta alguma coisa com a tag Enemy
            collider.gameObject.GetComponent<Enemy_Controller>().Die();
            Destroy(gameObject);
        }
        if(collider.tag == "Wall"){ //Se minha bala acerta uma parede
            Destroy(gameObject);
        }

    }

}
