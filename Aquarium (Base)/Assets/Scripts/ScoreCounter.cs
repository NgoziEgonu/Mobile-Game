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
    //public TextMeshProUGUI spinCounter;

    // Start is called before the first frame update
    void Start()
    {
        score = 0.0f;
       // spins = 0.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score++;
        }
        score_Text.text = "Score: " + score;

        //if (dolphin.transform.rotation.y > 0.0f)
        //{
        //    if (dolphin.transform.rotation.y > 290.0f)
        //    {
        //        spins++;
        //        Debug.Log(spins);
        //    }
        //}
    }
}
