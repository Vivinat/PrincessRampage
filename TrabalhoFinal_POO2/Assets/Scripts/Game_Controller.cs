using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
        //Aqui está uma das Design Patterns: Singleton!
    public class Game_Controller : MonoBehaviour
    {


        //Por ser static, os status do player estão em um unico valor, sem serem replicados
        //Nós queremos inicializa-los apenas uma vez!
        private int health;
        private int maxHealth = 10;
        private double healthPercent; // cada coração tem 20% da vida máxima. Inicialmente seu valor é 20% de 10;
        [SerializeField] Image heart0; // nunca muda, pois não sai da tela e não há nenhu abaixo dele;
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
        public int Health { get => health; set => health = value; }
        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public double HealthPercent { get => healthPercent; set => healthPercent = value; }
        public float FireRate { get => fireRate; set => fireRate = value; }
        public int Damage { get => damage; set => damage = value; }
        public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
        public int Exp { get => exp; set => exp = value; }

        public static Game_Controller instance;
        public static MenuController menu;
        public static Counter_Controller counterScore;
        public int highScore;
        public int lastScore;

        private void Start()
        {
            Health = MaxHealth;
            HealthPercent = (double)MaxHealth / 5;
            heartChange();
        }

        private void Awake()
        {
            if (FindObjectsOfType<Game_Controller>().Length > 1)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
        //Uma vez inicializado, podemos chamar Game_Controller em qualquer lugar do jogo!


        public void DamagePlayer(int damage) //Tomei dano
        {
            AudioManager.instance.PlaySound("PlayerDamage");
            Health -= damage;
            heartChange();

            if (Health <= 0)     //Dano zerou minha vida
            {
                KillPlayer();
            }

        }

        public void HealPlayer(int healAmount)     //Estou me curando
        {
            Health = Mathf.Min(MaxHealth, Health + healAmount);
            heartChange();
        }

        private void heartChange()
        {
            print("Player life: " + Health);
            // 100%
            if (Health >= 5 * HealthPercent)
            {
                heart5.enabled = true;
            }
            // 80%
            if (Health < 5 * HealthPercent && Health >= 4 * HealthPercent)
            {
                heart5.enabled = false;
                heart4.enabled = true;
                heart3.enabled = true;
                heart2.enabled = true;
                heart1.enabled = true;
            }
            // 60%
            if (Health < 4 * HealthPercent && Health >= 3 * HealthPercent)
            {
                heart5.enabled = false;
                heart4.enabled = false;
                heart3.enabled = true;
                heart2.enabled = true;
                heart1.enabled = true;
            }
            // 40%

            if (Health < 3 * HealthPercent && Health >= 2 * HealthPercent)
            {
                heart5.enabled = false;
                heart4.enabled = false;
                heart3.enabled = false;
                heart2.enabled = true;
                heart1.enabled = true;
            }
            // 20%

            if (Health < 2 * HealthPercent && Health >= 1 * HealthPercent)
            {
                heart5.enabled = false;
                heart4.enabled = false;
                heart3.enabled = false;
                heart2.enabled = false;
                heart1.enabled = true;
            }
            // 10%
            if (Health < 1 * HealthPercent)
            {
                heart5.enabled = false;
                heart4.enabled = false;
                heart3.enabled = false;
                heart2.enabled = false;
                heart1.enabled = false;
            }
        }

        public void MaxHealthChange(int maxHealthAmount)
        {
            MaxHealth += maxHealthAmount;
            HealthPercent = (double)MaxHealth / 5;
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
            // para o controle da pontuação a cada jogada no Endless Mode:
            if (SceneManager.GetActiveScene().name == "Endless_Mode")
            {
                counterScore = FindObjectOfType<Counter_Controller>();
                highScore = PlayerPrefs.GetInt("RoundHighScore");
                lastScore = PlayerPrefs.GetInt("RoundLastScore");
                
                if (highScore < counterScore.CurrentScore)
                {
                    highScore = counterScore.CurrentScore;
                    PlayerPrefs.SetInt("RoundHighScore", highScore);
                }
                lastScore = counterScore.CurrentScore;
                PlayerPrefs.SetInt("RoundLastScore", lastScore);
            }
            
            AudioManager.instance.StopSound("Battle2");
            SceneManager.LoadScene("DeathScene");
            Health = MaxHealth;
            Destroy(gameObject);
        }

    }

}