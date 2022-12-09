using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class BossLifeBar : MonoBehaviour, IObs
    {
        private int bossLife; 
        private int bossMaxLife = 0;

        [SerializeField] public Image greenBar;
        [SerializeField] public Image yellowBar;
        [SerializeField] public Image redBar;

        private Vector3 lifeBarScale; // tamanho da barra
        private float lifePercent; // percentual de vida para o calculo do tamanho das barras

        private void Start()
        {
            var bossInstance = GameObject.FindObjectOfType<Enemy_Controller>(); // Verificar depois. Aqui ele pode pegar qualquer inimigo. 99% de certeza que quando a barra de vida iniciar sóvai ter o Boss no jogo. Porém isso é gambiarra.
            bossMaxLife = bossInstance.getEnemyLife();
            print("VIDA MAX: " + bossMaxLife);
            print("vida do Boss: " + bossLife);
            lifeBarScale = greenBar.rectTransform.localScale;
            print("lifeScale: " + lifeBarScale.x);
            print("lifeScale (DdA):  " + lifeBarScale.x);
        }
        
        public void updateObs(ISubj subj, EnemyState state)
        {
            var enemy = (Enemy_Controller)subj;
            if (state == EnemyState.Damage)
            {
                bossLife = enemy.life;
                updateLifebar(); // executa as instruções para diminuir a barra de vida;
            }
        }

        private void updateLifebar()
        {
            lifeBarScale.x = (float)bossLife / bossMaxLife;
            
            print("vida do Boss: " + bossLife);
            print("lifeScale: " + lifeBarScale.x);

            if (lifeBarScale.x <= 0.67) // vida em 3/3
            {
                greenBar.rectTransform.localScale = lifeBarScale;
                greenBar.enabled = true;
                yellowBar.enabled = false;
                redBar.enabled = false;
            }
            if (lifeBarScale.x < 0.67 && lifeBarScale.x > 0.34) // vida em 2/3
            {
                yellowBar.rectTransform.localScale = lifeBarScale;
                greenBar.enabled = false;
                yellowBar.enabled = true;
                redBar.enabled = false;
            }
            if (lifeBarScale.x < 0.34) // vida em 1/3
            {
                redBar.rectTransform.localScale = lifeBarScale;
                greenBar.enabled = false;
                yellowBar.enabled = false;
                redBar.enabled = true;
            }
        }
    }
}