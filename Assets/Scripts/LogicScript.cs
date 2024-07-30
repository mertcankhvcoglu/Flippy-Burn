using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text highScoreText;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject tapToStartScreen;
    public bool isGameOver = false;
    public bool isGameStarted = false;
    [SerializeField] private AudioClip scoreSound;


    [ContextMenu("Increase Score")]

    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
    }

    private void Awake()
    {
        Time.timeScale = 0f;
    }
    public void addScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
        SoundManager.instance.PlaySound(scoreSound);

        if (playerScore > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", playerScore);
            highScoreText.text = playerScore.ToString();
        }
    }
 
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;
    }

    public void startGame()
    {
        Time.timeScale = 1f;
        tapToStartScreen.SetActive(false);
    }

}