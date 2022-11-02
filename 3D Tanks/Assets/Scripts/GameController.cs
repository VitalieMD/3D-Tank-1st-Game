using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    public enum GameState { MainMenu, Paused, Playing, GameOver, Victory};
    public GameState currentState;
    public Slider ammoSlider;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI totalEnemysDestroyedText;
    public TextMeshProUGUI finalScoreText;
    public GameObject textMoveLevel;
    public int tankDestroyedCounter;
    public int tanksDestroyedToFinish;
    public GameObject youWonPanel, gameOverPanel, allUIGame, mainMenuPanel, pausedMenuPanel;

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "0StartMenu")
        {
            CheckGameState(GameState.MainMenu);
        }
        else
        {
            CheckGameState(GameState.Playing);
        }
    }
    private void Start()
    {
        textMoveLevel.SetActive(false); 
    }

    private void Update()
    {
        SetBulletUpgrade();
        DisplayScore();
        DisplayLives();
        DisplayFinalScore();
        DisplayFinalEnemysDestroyed();
        CheckInputs();
    }
    public void CheckGameState(GameState newGameState)
    {
        currentState = newGameState;
        switch (currentState)
        {
            case GameState.MainMenu:
                MainMenuSetup();
                break;
            case GameState.Paused:
                Manager.gamePaused = true;
                Time.timeScale = 0f;
                GamePaused();
                break;
            case GameState.Playing:
                Manager.gamePaused = false;
                Time.timeScale = 1f;
                GameActive();
                break;
            case GameState.GameOver:
                Manager.gamePaused = true;
                Time.timeScale = 0f;
                GameOver();
                break;
            case GameState.Victory:
                Manager.gamePaused = true;
                Time.timeScale = 0f;
                Victory();
                break;

               

        }
    }
    public void MainMenuSetup()
    {
        youWonPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        allUIGame.SetActive(false);
        pausedMenuPanel.SetActive(false);
    }

    public void GameActive()
    {
        youWonPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        allUIGame.SetActive(true);
        pausedMenuPanel.SetActive(false);
    }

    public void GamePaused()
    {
        youWonPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        allUIGame.SetActive(false);
        pausedMenuPanel.SetActive(true);
    }
    public void GameOver()
    {
        youWonPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        allUIGame.SetActive(false);
        pausedMenuPanel.SetActive(false);
    }
    public void Victory()
    {
        youWonPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        allUIGame.SetActive(false);
        pausedMenuPanel.SetActive(false);
    }

    void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentState == GameState.Playing)
            {
                CheckGameState(GameState.Paused);
            }
            else if(currentState == GameState.Paused)
            {
                CheckGameState(GameState.Playing);
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("1Level1");
        CheckGameState(GameState.Playing);
    }

    public void PauseGame()
    {
        CheckGameState(GameState.Paused);
    }

    public void ResumeGame()
    {
        CheckGameState(GameState.Playing);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("0StartMenu");
        CheckGameState(GameState.MainMenu);
    }
    public void LoadPlayerTank()
    {
        SceneManager.LoadScene("PlayerTank");
    }
    public void LoadPurpleTank()
    {
        SceneManager.LoadScene("PurpleTank");
    }
    public void LoadRedTank()
    {
        SceneManager.LoadScene("RedTank");
    }
    public void LoadYellowTank()
    {
        SceneManager.LoadScene("YellowTank");
    }
    public void LoadGreenTank()
    {
        SceneManager.LoadScene("GreenTank");
    }
    public void LoadBlueTank()
    {
        SceneManager.LoadScene("BlueTank");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TextMoveLevel()
    {
        textMoveLevel.SetActive(true);
    }

    public void SetBulletUpgrade()
    {
        ammoSlider.value = Manager.bulletUpgrades;
    }
    public void DisplayScore()
    {
        scoreText.text = Manager.score.ToString();
    }
    public void DisplayLives()
    {
        livesText.text = "Lives: " + Manager.lives.ToString();
    }
    public void DisplayFinalEnemysDestroyed()
    {
        totalEnemysDestroyedText.text = "Total Enemys Destroyed: " + Manager.totalEnemysDestroyed.ToString();
    }
    public void DisplayFinalScore()
    {
        finalScoreText.text = "Your Score: " + Manager.score.ToString();
    }

}
