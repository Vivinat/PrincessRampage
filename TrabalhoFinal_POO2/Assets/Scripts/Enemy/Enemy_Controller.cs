using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Usaremos uma máquina finita de estados
public enum EnemyState
{
    //Quero que meu inimigo faça o que?
    Follow,
    Die,
    Attack
}

public class Enemy_Controller : MonoBehaviour
{
    GameObject player;
    public EnemyState currentState = EnemyState.Follow; //O inimigo sempre sabe onde vocêe está!
    public float speed;         //O quão rápido o inimigo é?
    public float attackRange;   //O quão perto o inimigo tem que estar do player?
    public int enemyDamage;
    private bool cooldownAttack = false;
    public int cooldown;
    public int life;
    public int XP;

    //Quero que o inimigo pisque quando tome dano!
    [SerializeField]
    private Material flashMaterial;

    [SerializeField]
    private float duration;

    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    //Procure o player
        spriteRenderer = GetComponent<SpriteRenderer>();        //Pegue o renderizador do inimigo
        originalMaterial = spriteRenderer.material;             
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
        if (!cooldownAttack)    //Se não estiver em cooldown
            Game_Controller.DamagePlayer(enemyDamage);  //Ataque!
            Debug.Log("Ataquei");
            StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown(){
        Debug.Log("Entrei em cooldown");
        cooldownAttack = true;      
        yield return new WaitForSeconds(cooldown);
        Debug.Log("Posso atacar de novo");
        cooldownAttack = false; 
    }

    //Tomei dano
    public void TakeDamage(int damage)
    {
        Flash();        //Vou piscar para sinalizar que tomei dano
        life -= damage; 
        if (life <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Game_Controller.ExpChange(XP);
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
}
