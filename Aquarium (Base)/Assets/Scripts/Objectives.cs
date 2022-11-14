using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objectives : MonoBehaviour
{
    Movement movement;
    public TextMeshProUGUI objective;

    int spinsIndex;
    

    // Start is called before the first frame update
    void Start()
    {
        movement = FindObjectOfType<Movement>();

        spinsIndex = Random.Range(1, 12);

        DisplayObjective();
    }

    // Update is called once per frame
    void Update()
    {
        Level1Objective();
        
    }

    void Level1Objective()
    {
        if (movement.spins == spinsIndex)
        {
            objective.fontStyle = FontStyles.Strikethrough;
            Debug.Log("Boop");
        }
    }

    void DisplayObjective()
    {

        if (spinsIndex > 1)
        {
            objective.text = "Spin " + spinsIndex + " times";
        }
        else
        {
            objective.text = "Spin " + spinsIndex + " time";
        }
        
    }
}
