using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Aqui está uma das Design Patterns: Singleton!
public class Game_Controller : MonoBehaviour
{
    //Por ser static, os status do player estão em um unico valor, sem serem replicados
    //Nós queremos inicializa-los apenas uma vez!
    public static Game_Controller instance;

    private static int health = 10;
    private static int maxHealth = 10;
    private static float fireRate = 0.5f;
    private static int damage = 1;
    private static float moveSpeed = 5f;
    private static int exp = 0;

    //Primeiro, nossos status devem estar privados
    //Vamos ter que "replica-los" para que outros scripts possam acessá-los
    
    //Minusculo = variaveis privadas
    //Maiusculo = variaveis publicas
    public static int Health {get => health; set => health = value;}
    public static int MaxHealth {get => maxHealth; set => maxHealth = value;}
    public static float FireRate {get => fireRate; set => fireRate = value;}
    public static int Damage {get => damage; set => damage = value;}
    public static float MoveSpeed {get => moveSpeed; set => moveSpeed = value;}
    public static int Exp {get => exp; set => exp = value;}


    private void Awake(){

        if(instance == null)
        {
            instance = this;
        }

    }
    //Uma vez inicializado, podemos chamar Game_Controller em qualquer lugar do jogo!

    public static void DamagePlayer(int damage) //Tomei dano
    {
        health -= damage;
        Debug.Log("Vida");
        Debug.Log (health);

        if(health <= 0)     //Dano zerou minha vida
        {
            KillPlayer();
        }

    }

    public static void HealPlayer(int healAmount)     //Estou me curando
    {
        Debug.Log (health);
        health = Mathf.Min(maxHealth, health + healAmount);
    }

    public static void MaxHealthChange (int maxHealthAmount)
    {
        maxHealth += maxHealthAmount;
    }

    public static void MoveSpeedChange(float speed)     //Estou mais rápido
    {
        moveSpeed += speed;
    }

    public static void ExpChange(int xp)
    {
        if (exp >= 100)
        {
            exp = 0;
        }
        exp += xp;
    }

    public static void FireRateChange(float rate)       //Consigo atirar mais rápido
    {
        fireRate -= rate;
    }

    public static void DamageChange(int dam)          //Meu dano aumentou
    {
        damage += dam;
    }

    public static void KillPlayer()
    {
        SceneManager.LoadScene("DeathScene");
    }

}
