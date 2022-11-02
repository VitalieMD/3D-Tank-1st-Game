using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public static bool gamePaused;
    static GameController gameController;
    public static int score, lives, damage, bulletUpgrades;
    public static int totalEnemysDestroyed;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        gameController = FindObjectOfType<GameController>();
        lives = 3;
        damage = 20;
        gameController.DisplayScore();
        gameController.DisplayLives();

    }

    void Update()
    {
        MoveToAnyLevel();
    }
    public static void UpdateScore(int scorePoints)
    {
        score += scorePoints;
        gameController.DisplayScore();
    }

    public static void AddLives(int lifeValue)
    {
        lives += lifeValue;
        if(lives < 0)
        {
            gameController.CheckGameState(GameController.GameState.GameOver);
        }
        else
        {
            gameController.DisplayLives();
        }
    }

    public static void AddDamage()
    {
        if(damage <= 35)
        {
            bulletUpgrades++;
            damage += 5;
        }
    }
    void MoveToAnyLevel()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene(4);
        }
    }

}
