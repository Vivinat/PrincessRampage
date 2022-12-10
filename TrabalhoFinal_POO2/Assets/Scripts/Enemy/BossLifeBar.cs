using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class BossLifeBar : MonoBehaviour, IObs
    {
        private int life; 
        private int maxLife;

        [SerializeField] public Image greenBar;
        [SerializeField] public Image yellowBar;
        [SerializeField] public Image redBar;

        private Vector3 lifeBarScale; // tamanho da barra
        private float lifePercent; // percentual de vida para o calculo do tamanho das barras

        private void Start()
        {
            lifeBarScale = greenBar.rectTransform.localScale; // Inicializa com o valor da barra no seu estado inicial (cheia)
        }
        
        public void updateObs(ISubj subj, EnemyState state)
        {
            var enemy = (Enemy_Controller)subj;
            if (state == EnemyState.Born)
            {
                maxLife = enemy.life;
                life = maxLife;
                lifePercent = lifeBarScale.x / maxLife;
            }
            else if (state == EnemyState.Damage)
            {
                life = enemy.life;
                updateLifebar(); // executa as instruções para diminuir a barra de vida;
            }
        }

        private void updateLifebar()
        {
            lifeBarScale.x = lifePercent * life;                
            greenBar.rectTransform.localScale = lifeBarScale;
            yellowBar.rectTransform.localScale = lifeBarScale;
            redBar.rectTransform.localScale = lifeBarScale;
            

            if (lifeBarScale.x <= 0.67) // vida em 3/3
            {
                greenBar.enabled = true;
                yellowBar.enabled = false;
                redBar.enabled = false;
            }
            else if (lifeBarScale.x < 0.67 && lifeBarScale.x > 0.34) // vida em 2/3
            {
                greenBar.enabled = false;
                yellowBar.enabled = true;
                redBar.enabled = false;
            }
            else if (lifeBarScale.x < 0.34) // vida em 1/3
            {
                greenBar.enabled = false;
                yellowBar.enabled = false;
                redBar.enabled = true;
            }
        }
    }
}