using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public float score;
    int spins;

    public GameObject dolphin;

    Movement movement;
    GameManager gameManager;

    public TextMeshProUGUI score_Text;

    // Start is called before the first frame update
    void Start()
    {
        score = 0.0f;
        movement = FindObjectOfType<Movement>();
        gameManager = FindObjectOfType<GameManager>();
        spins = movement.spins;
    }

    public void Scoring()
    {
        score += 5;
        score_Text.text = "Score: " + score;
        //Debug.Log("Scoring");

        if (score >= 30)
        {
            gameManager.GameOver();
            movement.spins_Counter.gameObject.SetActive(false);
        }
    }


}
