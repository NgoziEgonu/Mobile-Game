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
    public int fundsCount;

    [SerializeField]
    bool objective1Complete = false;
    bool objective2Complete = false;

    


    // Start is called before the first frame update
    void Start()
    {
        movement = FindObjectOfType<Movement>();
        animController = FindObjectOfType<AnimationController>();

        spinsIndex = Random.Range(1, 3); //12
        flipsIndex = Random.Range(1, 4);

        DisplayObjective();

        fundsCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Level1Objective();
    }

    void Level1Objective()
    {
        if (movement.spins == spinsIndex && objective1Complete == false)
        {
            objective1.fontStyle = FontStyles.Strikethrough;
            Debug.Log("Objective 1 complete");
            objective1Complete = true;
            fundsCount += 10;
        }

        if (animController.flips == flipsIndex && objective2Complete == false)
        {
            objective2.fontStyle = FontStyles.Strikethrough;
            Debug.Log("Objective 2 complete");
            objective2Complete = true;
            fundsCount += 10;
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
