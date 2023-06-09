using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float initialScrollSpeed;

    private int score;
    private float timer;
    private float scrollSpeed;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateSpeed();
    }
    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    private void UpdateScore()
    {
        int scorePreSecond = 10; 
        timer += Time.deltaTime;
        score = (int)(timer * scorePreSecond);
        scoreText.text = string.Format("{0:00000}", score);
    }
    public float GetScrollSpeed()
    {
        return scrollSpeed;
    }
    private void UpdateSpeed()
    {
        scrollSpeed = initialScrollSpeed + timer / 10f;
    }
}
