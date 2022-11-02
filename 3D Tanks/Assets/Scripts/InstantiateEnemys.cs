using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantiateEnemys : MonoBehaviour
{
    public List<GameObject> enemysList;
    public List<Vector3> respawnPoints;

    [SerializeField] float timer;
    [SerializeField] float timerReset;

    public bool allEnemyDead;

    GameObject tankEnemy;

    public int enemysDestroyed;
    int totalEnemys;

    public int enemysOnStart;
    GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        totalEnemys = enemysList.Count;
        allEnemyDead = false;
    }
    private void Update()
    {
        if(enemysList.Count >= 1)
        {
            InstantiateTanks();
        }
        NextLevel();
    }
    void InstantiateTanks()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            int i = Random.Range(0, enemysList.Count);
            tankEnemy = Instantiate(enemysList[i], respawnPoints[Random.Range(0, respawnPoints.Count)], transform.rotation) as GameObject;
            timer = timerReset;
            enemysList.RemoveAt(i);
        }
    }

    public void NextLevel()
    {
        if(totalEnemys + enemysOnStart <= enemysDestroyed && SceneManager.GetActiveScene().buildIndex <= 3)
        {
            gameController.textMoveLevel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R) )
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            
        }
        else if (totalEnemys + enemysOnStart <= enemysDestroyed && SceneManager.GetActiveScene().buildIndex == 4)
        {
            gameController.textMoveLevel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                gameController.CheckGameState(GameController.GameState.Victory);
            }
            
        }
    }
}
