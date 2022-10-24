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

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    //Procure o player
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
            currentState = EnemyState.Attack;
        }
        if(Vector3.Distance(transform.position, player.transform.position) >= attackRange)  //Se estiver na distancia correta
        {
            currentState = EnemyState.Follow;
        }

    }

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

    public void Die()
    {
        Destroy(gameObject);
    }
}
