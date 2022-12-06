using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LastScore_Controller : MonoBehaviour
    {
        private int lastScore = 0;

        public int LastScore { get => lastScore; set => lastScore = value; }

        public TextMeshProUGUI lastScoreText;

        private void Start()
        {
            if(PlayerPrefs.HasKey("RoundLastScore"))
            {
                LastScore = PlayerPrefs.GetInt("RoundLastScore");
            }
            lastScoreText = GameObject.Find("LastScore").GetComponent<TextMeshProUGUI>();
            setLastScoreText(LastScore.ToString());

        }

        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void setLastScoreText(string lastScore)
        {
            lastScoreText.text = lastScore;
        }
    }
}