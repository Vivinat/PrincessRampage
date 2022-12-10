using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//Usaremos uma máquina finita de estados
public enum EnemyState
{
    //Quero que meu inimigo faça o que?
    Born,
    Follow,
    Die,
    Attack,
    Damage,
};

public enum EnemyType
{
    //Qual o tipo dele?
    Melee,
    Ranged
};

namespace DefaultNamespace{
        public class Enemy_Controller : MonoBehaviour, ISubj
    {
        GameObject player;
        public EnemyState currentState = EnemyState.Follow; //O inimigo sempre sabe onde vocêe está!
        public EnemyType enemyType;

        public float speed;         //O quão rápido o inimigo é?
        public float attackRange;   //O quão perto o inimigo tem que estar do player?
        public int enemyDamage;
        private bool cooldownAttack = false;
        public int cooldown;
        public int life;
        public int XP;
        public GameObject bulletPrefab;

        //Quero que o inimigo pisque quando tome dano!
        [SerializeField]
        private Material flashMaterial;

        [SerializeField]
        private float duration;

        private SpriteRenderer spriteRenderer;
        private Material originalMaterial;
        private Coroutine flashRoutine;

        private ProgressBar progressBar;
        private Game_Controller gameController;
        
        private IObs counterScore;
        protected List<IObs> observers;
        private IObs bossLifeBar;
        
        void Awake()
        {
            observers = new List<IObs>();
        }
        
        // Start is called before the first frame update
        void Start()
        {
            gameController = FindObjectOfType<Game_Controller>();
            progressBar = FindObjectOfType<ProgressBar>();
            player = GameObject.FindGameObjectWithTag("Player");    //Procure o player
            spriteRenderer = GetComponent<SpriteRenderer>();        //Pegue o renderizador do inimigo
            originalMaterial = spriteRenderer.material;

            if (enemyType == EnemyType.Ranged)
            {
                bossLifeBar = GameObject.FindObjectOfType<BossLifeBar>();
                register(bossLifeBar);
                notify(this, currentState);
            }

            if (SceneManager.GetActiveScene().name == "Endless_Mode")
            {   
                counterScore = FindObjectOfType<Counter_Controller>();
                register(counterScore);
            }
        }

        // Update is called once per frame
        void Update()
        {   //O que o inimigo vai fazer?
            switch(currentState)
            {
                case(EnemyState.Follow):
                Follow();
                break;
                case(EnemyState.Die):
                Die();
                break;
                case(EnemyState.Attack):
                Attack();
                break;
            }

            if(Vector3.Distance(transform.position, player.transform.position) <= attackRange)  //Se estiver na distancia correta
            {
                currentState = EnemyState.Attack;   //Consigo atacar
            }
            if(Vector3.Distance(transform.position, player.transform.position) >= attackRange)  //Se estiver na distancia correta
            {
                currentState = EnemyState.Follow;   //Consigo seguir
            }

        }

        //Segue o player
        void Follow()
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        void Attack()
        {
            if (!cooldownAttack)
            {   
                switch(enemyType)
                {
                    case(EnemyType.Melee):
                        gameController.DamagePlayer(enemyDamage);  //Ataque!
                        StartCoroutine(CoolDown());
                    break;
                    case(EnemyType.Ranged): //Se for ranged
                        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;   //Instancie uma bala
                        bullet.GetComponent<Bullet_Controller>().GetPlayer(player.transform);
                        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
                        bullet.GetComponent<Bullet_Controller>().isEnemyBullet = true;  //Precisamos diferenciar as balas do player e do inimigo!
                        StartCoroutine(CoolDown());
                    break;
                }
            }
        }

        private IEnumerator CoolDown(){
            cooldownAttack = true;      
            yield return new WaitForSeconds(cooldown);
            cooldownAttack = false; 
        }

        //Tomei dano
        public void TakeDamage(int damage)
        {
            Flash();        //Vou piscar para sinalizar que tomei dano
            life -= damage;
            if (enemyType == EnemyType.Ranged)
            {
                currentState = EnemyState.Damage;
                notify(this, currentState);
            }
            if (life <= 0)
            {
                currentState = EnemyState.Die;
            }
        }

        public void Die()
        {
            GetComponent<LootBag>().InstantiateLoot(transform.position);    //Na posição em que ele se encontra, o loot é instanciado
            gameController.ExpChange(XP);
            progressBar.Increment(XP);                             //ATENÇAO: SE NAO TIVER A BARRA DE XP NO CENARIO, ESTE COMANDO QUEBRA O GAME
            AudioManager.instance.PlaySound("EnemyKill");

            if (SceneManager.GetActiveScene().name == "Endless_Mode"){
                notify(this, this.currentState); // notifica passando a si mesmo (inimigo) e o seu estaado de destruido;
            }

            Destroy(gameObject);
        }



        //Tomei dano e agora vou piscar
        private IEnumerator FlashRoutine()
        {
            spriteRenderer.material = flashMaterial;    //Troque o material do inimigo pelo flashMaterial
            yield return new WaitForSeconds(duration);  //Espere
            spriteRenderer.material = originalMaterial; //Devolva o material original do inimigo
            flashRoutine = null;                        //No termino da routine, flashRoutine torna-se null
        }

        public void Flash()
        {
            if (flashRoutine != null)   //Se não é nulo, é por que está acontecendo agora
            {
                StopCoroutine (flashRoutine);   //Se for esse o caso, temos que parar para não bugar
            }
            flashRoutine = StartCoroutine(FlashRoutine());  //Se for nulo, podemos iniciar
        }

        public int getDamage()
        {
            return enemyDamage;
        }

        public void notify(ISubj enemy, EnemyState state)
        {
            foreach (var observer in observers)
            {
                observer.updateObs(enemy, state);
            }
        }

        public void register(IObs obs)
        {
            observers.Add(obs);
        }

        public void unregister(IObs obs)
        {
            observers.Remove(obs);
        }
    }
}