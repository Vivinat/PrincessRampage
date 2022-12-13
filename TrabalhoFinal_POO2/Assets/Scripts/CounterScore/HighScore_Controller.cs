using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class HighScore_Controller : MonoBehaviour
    {
        private int highScore = 0;
        public int HighScore { get => highScore; set => highScore = value; }
        public TextMeshProUGUI highScoreText;

        private void Start()
        {
            if(PlayerPrefs.HasKey("RoundHighScore"))
            {
                HighScore = PlayerPrefs.GetInt("RoundHighScore");
            }

            highScoreText = GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();
            setHighScoreText(HighScore.ToString());
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        
        public void setHighScoreText(string highScore)
        {
            highScoreText.text = highScore;
        }

    }
}