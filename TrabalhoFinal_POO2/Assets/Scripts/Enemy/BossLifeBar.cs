using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class BossLifeBar : MonoBehaviour, IObs
    {
        private int bossLife; 
        private int bossMaxLife = 100; // ****dar um jeto de pegar a vida do boss de forma que se mudar lá aqui muda tambem

        [SerializeField] public Image greenBar;
        [SerializeField] public Image yellowBar;
        [SerializeField] public Image redBar;

        private Vector3 lifeBarScale; // tamanho da barra (pode precisar de mais de uma)
        private float lifePercent; // percentual de vida para o calculo do tamanho das barras

        private void Start()
        {
            bossLife = bossMaxLife;
            lifeBarScale = greenBar.rectTransform.localScale;
            //inicializar a vida maxima do boss;
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

        public void SetBossLife(int life)
        {
            bossLife = life;
        }

        private void updateLifebar()
        {
            lifeBarScale.x = (float)bossLife / bossMaxLife;

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