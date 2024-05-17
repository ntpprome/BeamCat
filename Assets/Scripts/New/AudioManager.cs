using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource gameOverAudioSource;
    [SerializeField] private AudioSource gameScoreAudioSource;
    [SerializeField] private AudioSource gameTapAudioSource;
    private void Start()
    {
        GameManager.Instance.Player.OnGameOver += GameOver;
        GameManager.Instance.Player.OnGamePlayKeyPressed += GamePlayKeyPressed;
        GameManager.Instance.Player.OnGameScore += OnGameScore;
    }

    private void GamePlayKeyPressed()
    {
        gameTapAudioSource?.Play();
        gameOverAudioSource?.Stop();
        gameScoreAudioSource?.Stop();
    }

    private void OnGameScore(int obj)
    {
        gameTapAudioSource?.Stop();
        gameOverAudioSource?.Stop();
        gameScoreAudioSource?.Play();

    }

    private void GameOver()
    {
        gameTapAudioSource?.Stop();
        gameScoreAudioSource?.Stop();
        gameOverAudioSource?.Play();
    }
}
