using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Analytics;

public class ScoreCounter : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI score_Text;

    // Start is called before the first frame update
    void Start()
    {
        score = 0.0f;
    }

    private void Update()
    {
        Scoring();
    }

    void Scoring()
    {
        score_Text.text = "" + score;


        //if (score >= 100)
        //{
        //    AnalyticsResult analyticsResult = Analytics.CustomEvent("MaxScore");
        //    gameManager.GameOver();
        //    movement.spins_Counter.gameObject.SetActive(false);
        //    Time.timeScale = 0.0f;
        //    Debug.Log("analytics result = " + analyticsResult);
        //}
    }
}
