using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class GameManager : MonoBehaviour
{
    bool gameOver = false;
    bool isGamePaused = false;
    public GameObject gameOverScreen;
    public GameObject objectivesScreen;

    private void Start()
    {
        gameOverScreen.SetActive(false);
        objectivesScreen.SetActive(false);
    }
    public void GameOver()
    {
        if (gameOver == false)
        {
            gameOverScreen.SetActive(true);
            gameOver = true;
            Debug.Log("It's ovah");
        }
    }

    public void ObjectiveMenu()
    {
        if (isGamePaused == false)
        {
            Pause();
        }
        else if (isGamePaused == true)
        {
            Resume();
        }
    }

    void Pause()
    {
        isGamePaused = true;
        objectivesScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    void Resume()
    {
        isGamePaused = false;
        objectivesScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

}
