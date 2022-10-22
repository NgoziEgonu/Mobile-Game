using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameOver = false;
    bool isGamePaused = false;
    public GameObject gameOverScreen;
    public GameObject objectivesScreen;
    [SerializeField] InterstitialAds interstitialAds;

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
            interstitialAds.ShowAd();
            Debug.Log("It's ovah");
        }
    }

    public void ObjectiveMenu()
    {
        if (isGamePaused == false)
        {
            Pause();
            Time.timeScale = 0.0f;
        }
        else if (isGamePaused == true)
        {
            Resume();
            Time.timeScale = 1.0f;
        }
    }

    void Pause()
    {
        isGamePaused = true;
        objectivesScreen.SetActive(true);
        //Time.timeScale = 0.0f;
    }

    void Resume()
    {
        isGamePaused = false;
        objectivesScreen.SetActive(false);
        //Time.timeScale = 1.0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

}
