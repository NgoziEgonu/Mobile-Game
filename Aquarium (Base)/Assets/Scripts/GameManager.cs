using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameOver = false;
    bool isGamePaused = false;

    float posZ;

    public GameObject snack;
    public GameObject gameOverScreen;
    public GameObject objectivesScreen;

    public TextMeshProUGUI fundsUI;

    [SerializeField] InterstitialAds interstitialAds;
    Objectives objectives;
    
    Vector3 SnackSpawn;

    private void Start()
    {
        gameOverScreen.SetActive(false);
        objectivesScreen.SetActive(false);

        objectives = GetComponent<Objectives>();

        posZ = Random.Range(0, 15);

        SnackSpawn = new Vector3(-9.43f, 7.0f, posZ);

        LaunchSnack();
    }

    void Update()
    {
        AddFunds();

        //if () PRESS A KEY TO RESPAWN OBJECT
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

    public void StartGame()
    {
        SceneManager.LoadScene(0);
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

    void AddFunds()
    {
        fundsUI.text = "Funds: " + objectives.fundsCount;
    }

    public void LaunchSnack()
    {
        Instantiate(snack, SnackSpawn, Quaternion.identity);
    }
}
