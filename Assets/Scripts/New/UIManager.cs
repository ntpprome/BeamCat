using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   [SerializeField] private GameObject gameOverScreen;
   [SerializeField] private GameObject gamePlayScreen;
   [SerializeField] private TextMeshProUGUI scoreText;
   [SerializeField] private TextMeshProUGUI finalScoreText;
   [FormerlySerializedAs("highScore")] [SerializeField] private TextMeshProUGUI highScoreText;

   private void Start()
   {
       GameManager.Instance.Player.OnGameOver += GameOver;
       GameManager.Instance.Player.OnGameScore += OnGameScore;
       GameManager.Instance.Player.OnGameRestart += OnGameStart;
   }

   void GameOver()
   {
     gameOverScreen.SetActive(true); 
     gamePlayScreen.SetActive(false);
     scoreText.text = "";

   }
   void OnGameStart()
   {
       gameOverScreen.SetActive(false); 
        gamePlayScreen.SetActive(false);
       scoreText.text = 0.ToString();
       
   }
   void OnGameRestart()
   {
       gameOverScreen.SetActive(false); 
        gamePlayScreen.SetActive(false);
       scoreText.text = 0.ToString();
       
   }
   void OnGameScore( int score)
   {
     int highscore = GameManager.Instance.Player.GetHighScore() > score ? GameManager.Instance.Player.GetHighScore() : score;
     highscore = math.max(0, highscore);
     score = math.max(0, score);
       finalScoreText.text = $"Score: {score.ToString()}" ;
       highScoreText.text = $"High Score: {highscore.ToString()}" ;
       scoreText.text = score.ToString("000");
   }
}
