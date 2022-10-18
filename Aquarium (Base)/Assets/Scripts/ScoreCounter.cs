using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    float score;
    //float spins;

    public GameObject dolphin;

    public TextMeshProUGUI score_Text;

    // Start is called before the first frame update
    void Start()
    {
        score = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void Scoring()
    {
        score += 5;
        score_Text.text = "Score: " + score;
        Debug.Log("Scoring");
    }


}
