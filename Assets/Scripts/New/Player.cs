using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Player : MonoBehaviour
{
    public Action OnGameOver;
    public Action OnGameRestart;
    public Action OnGamePlayKeyPressed;
    public Action<int> OnGameScore;
    private int _score;
    private Vector3 _direction;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject playerVisuals;
    [SerializeField] private Animator _animator;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float strength = 5f;
    public GameStates _gameStates;
    

    private void Awake()
    {
        _gameStates = GameStates.Stopped;
    }

    private void Update()
    {
        if (_gameStates == GameStates.Playing)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                OnGamePlayKeyPressed?.Invoke();
                _direction = Vector2.up * strength;
            }
            //todo add count for mobile

            _direction.y += gravity * Time.deltaTime;
            transform.position += _direction * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.IncreaseScore();
        _score++;
        OnGameScore?.Invoke(_score);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       GameEnd();
    }

    private void GameEnd()
    {
        _gameStates = GameStates.Stopped;
        OnGameOver?.Invoke();
        _spriteRenderer.enabled = false;
        _animator.SetBool("IsRunning", false);
        playerVisuals.SetActive(false);
        GameManager.Instance.GameOver();
        TrySetHighScore(_score);
    }

    public void GameRestart()
    {
        Debug.Log("func call");
        _score = 0;
        playerVisuals.SetActive(true);
        _spriteRenderer.enabled = true;
        _animator.SetBool("IsRunning", true);
        transform.position = new Vector3(0, 0, 0);
        _direction.y = 0f;
            _gameStates = GameStates.Playing;
        OnGameRestart?.Invoke();
    }
    public void GameExit()
    {
        SceneManager.LoadScene("Menu");

    }
    public bool GameIsRunning()
    {
        return _gameStates == GameStates.Playing;
    }
    
    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
    }
    public  int GetHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            return PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            return 0; // Default value if no high score has been set yet
        }
    }
    public  void TrySetHighScore(int currentScore)
    {
        int highScore = GetHighScore();
        if (currentScore > highScore)
        {
            SetHighScore(currentScore);
        }
    }

   


}



public enum GameStates
{
Playing, 
Stopped,

}
