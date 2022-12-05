using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



namespace DefaultNamespace
{
    public class Counter : MonoBehaviour, IObs
    {
        private int totalScore;
        private int points;
        public TextMeshProUGUI scoreText;

        void Start()
        {

            scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>(); // pega o texto da 
            totalScore = 0;// zera a pontuação;
            setScoreText(getTotalPoints().ToString());

        }
        
        public void updateObs(Enemy_Controller enemy, EnemyState state)
        {

            if (state == EnemyState.Born)// se o inimigo foi criado
            {
                enemy.register(this);// inimigo.registra(a si mesmo/couter);
            }
            else if (state == EnemyState.Die) // senão, se for destruido
            {
                 // pega o inimigo.ponto: (verificar com o vinícus qauntos pontos cada inimigo dá)
                if (enemy.enemyType == EnemyType.Melee)
                {
                    points = 10; 
                }
                else if (enemy.enemyType == EnemyType.Ranged)
                {
                    points = 30;
                }
                totalScore += points; // soma no total;
                points = 0; // para garantir que não vai somar ponto sem termatado o inimigo;
                setScoreText(totalScore.ToString()); // mostra na tela;
                print("TOTAL SCORE: " + getTotalPoints().ToString());
                enemy.unregister(this); // inimigo.desregistra(a si mesmo/couter);
            }
        }

        public int getTotalPoints()
        {
            return totalScore;
        }

        private void setScoreText(string score)     //Converse com o texto na UI
    {
        scoreText.text = score;
    }
    }
}

