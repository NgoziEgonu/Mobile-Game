using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objectives : MonoBehaviour
{
    Movement movement;
    AnimationController animController;

    public TextMeshProUGUI objective1;
    public TextMeshProUGUI objective2;

    int spinsIndex;
    int flipsIndex;
    

    // Start is called before the first frame update
    void Start()
    {
        movement = FindObjectOfType<Movement>();
        animController = FindObjectOfType<AnimationController>();

        spinsIndex = Random.Range(1, 12);
        flipsIndex = Random.Range(1, 4);

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
            objective1.fontStyle = FontStyles.Strikethrough;
            Debug.Log("Objective 1 complete");
        }

        if (animController.flips == flipsIndex)
        {
            objective2.fontStyle = FontStyles.Strikethrough;
            Debug.Log("Objective 2 complete");
        }
    }

    void DisplayObjective()
    {

        if (spinsIndex > 1)
        {
            objective1.text = "Spin " + spinsIndex + " times";
        }
        else
        {
            objective1.text = "Spin " + spinsIndex + " time";
        }

        if (flipsIndex > 1)
        {
            objective2.text = "Flip " + flipsIndex + " times";
        }
        else
        {
            objective2.text = "Flip " + flipsIndex + " time";
        }

    }
}
