using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DefaultNamespace
{
        public class Bullet_Controller : MonoBehaviour
    {
        public float lifeTime; 
        private int damage;
        public bool isEnemyBullet = false;

        private Vector2 lastPos;
        private Vector2 curPos;
        private Vector2 playerPos;
        private Game_Controller gameController;   

        // Start is called before the first frame update
        void Start()
        {
            gameController = FindObjectOfType<Game_Controller>();
            StartCoroutine(DeathDelay()); //Coroutine para saber quando destruimos a bala
        }

        // Update is called once per frame
        void Update()
        {
            if(!isEnemyBullet){         //Se eu não sou uma bala inimiga
                damage = gameController.Damage;    //Preciso saber se meu dano mudou
            }
            else
            {
                curPos = transform.position;        //Se eu for uma bala inimiga
                transform.position = Vector2.MoveTowards(transform.position, playerPos,5f * Time.deltaTime);    //Atira na direção do player
                if (curPos == lastPos)
                {
                    Destroy(gameObject);
                }
                lastPos = curPos;
            }
        }

        public void GetPlayer(Transform player)
        {
            playerPos = player.position;
        }

        IEnumerator DeathDelay(){
            yield return new WaitForSeconds(lifeTime);  //Espere a quantidade de tempo definido por lifeTime
            Destroy(gameObject);       //Depois, destrua o objeto (a bala)
        }


        void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.tag == "Enemy" && !isEnemyBullet){                                  //Se minha bala acerta alguma coisa com a tag Enemy
                collider.gameObject.GetComponent<Enemy_Controller>().TakeDamage(damage);    //Essa coisa toma dano
                Destroy(gameObject);
            }
            if(collider.tag == "Wall"){ //Se minha bala acerta uma parede
                Destroy(gameObject);    //Minha bala é destruída
            }
            if(collider.tag == "Player" && isEnemyBullet)   //Se eu sou um inimigo e acerto o player
            {
                gameController.DamagePlayer(10);            //Ele toma dano
                Destroy(gameObject);
            }

        }

    }
}
