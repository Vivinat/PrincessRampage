using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//Aqui está uma das Design Patterns: Singleton!
public class Game_Controller : MonoBehaviour
{


    //Por ser static, os status do player estão em um unico valor, sem serem replicados
    //Nós queremos inicializa-los apenas uma vez!
    private int health = 10;
    private int maxHealth = 10;
    [SerializeField] Image heart1;
    [SerializeField] Image heart2;
    [SerializeField] Image heart3;
    [SerializeField] Image heart4;
    [SerializeField] Image heart5;
    private float fireRate = 0.5f;
    private int damage = 1;
    private float moveSpeed = 5f;
    private int exp = 0;

    //Primeiro, nossos status devem estar privados
    //Vamos ter que "replica-los" para que outros scripts possam acessá-los
    
    //Minusculo = variaveis privadas
    //Maiusculo = variaveis publicas
    public int Health {get => health; set => health = value;}
    public int MaxHealth {get => maxHealth; set => maxHealth = value;}
    public float FireRate {get => fireRate; set => fireRate = value;}
    public int Damage {get => damage; set => damage = value;}
    public float MoveSpeed {get => moveSpeed; set => moveSpeed = value;}
    public int Exp {get => exp; set => exp = value;}

    public static Game_Controller instance;
    TextMeshProUGUI healthText;

    private void Start()
    {
        healthText = GameObject.FindWithTag("HealthText").GetComponent<TextMeshProUGUI>();
        healthText.text = Health.ToString();
    }

    private void Awake(){
        if (FindObjectsOfType<Game_Controller>().Length > 1)
        {
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
        // if (instance == null)
        // {
        //     print("Nova instancia");
        //     instance = this;
        // }else{
        //     print("Instancia velha destruida");
        //     Destroy(gameObject);
        // }   
    }
    //Uma vez inicializado, podemos chamar Game_Controller em qualquer lugar do jogo!


    public void DamagePlayer(int damage) //Tomei dano
    {
        AudioManager.instance.PlaySound("PlayerDamage");
        Health -= damage;
        healthText.text = Health.ToString();
        // remover coração:

        if (Health < 9)
        {
            heart5.enabled = false;
        }

        if (Health < 7)
        {
            heart4.enabled = false;
        }

        if (Health < 5)
        {
            heart3.enabled = false;
        }

        if (Health < 3)
        {
            heart2.enabled = false;
        }

        if (Health < 1)
        {
            heart1.enabled = false;
        }

        // fim remove coração

        if(Health <= 0)     //Dano zerou minha vida
        {
            KillPlayer();
        }

    }

    public void HealPlayer(int healAmount)     //Estou me curando
    {
        Debug.Log (health);
        health = Mathf.Min(maxHealth, health + healAmount);
    }

    public void MaxHealthChange (int maxHealthAmount)
    {
        maxHealth += maxHealthAmount;
    }

    public void MoveSpeedChange(float speed)     //Estou mais rápido
    {
        moveSpeed += speed;
    }

    public void ExpChange(int xp)                //Ganhei XP
    {
        if (exp >= 100)
        {
            exp = 0;
        }
        exp += xp;
    }

    public void FireRateChange(float rate)       //Consigo atirar mais rápido
    {
        fireRate -= rate;
    }

    public void DamageChange(int dam)          //Meu dano aumentou
    {
        damage += dam;
    }
    public void KillPlayer() //Morri
    {
        AudioManager.instance.StopSound("Battle2");
        SceneManager.LoadScene("DeathScene");
        health = 10;
    }

}
