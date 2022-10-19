using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class GameManager : MonoBehaviour
{
    bool gameOver = false;
    public GameObject gameOverScreen;

    private void Start()
    {
        gameOverScreen.SetActive(false);
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
}
