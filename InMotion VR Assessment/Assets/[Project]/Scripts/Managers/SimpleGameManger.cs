using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleGameManger : MonoBehaviour
{
    public static bool GameIsStarted = false;
    public static bool GameIsRunning = false;

    public GameObject gameoverScreen = default;

    private float delayTillEnemiesSpawn = 3f;

    public static SimpleGameManger instance = null;

    private void Awake()
    {
        instance = this;

        GameIsStarted = false;
        GameIsRunning = false;
    }
    /// <summary>
    /// Enables the spawning of enemy AI.
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartEnemyAI()
    {
        yield return new WaitForSeconds(delayTillEnemiesSpawn);
        GameIsRunning = true;
    }

    public void GameOver()
    {
        gameoverScreen.SetActive(true);
    }

    /// <summary>
    /// Starts the game.
    /// </summary>
    public void OnStartGame()
    {
        GameIsStarted = true;
        StartCoroutine(StartEnemyAI());
    }

    /// <summary>
    /// Simple way to "restart" the game.
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
