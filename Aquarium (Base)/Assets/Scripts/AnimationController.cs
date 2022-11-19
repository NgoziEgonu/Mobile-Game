using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    ScoreCounter scoreCounter;

    public int flips;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
    }
    void Flip()
    {
        //Flip Mechanic Not working properly yet
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.tapCount == 2 && !anim.GetBool("isFlipping"))
            {
                anim.SetBool("isFlipping", true);
                flips++;
                scoreCounter.score += 3;
                Debug.Log("Flip");
                // anim.SetBool("isFlipping", false);

                Invoke(nameof(ResetFlip), 0.4f);
            }
        }
    }
    void ResetFlip()
    {
        anim.SetBool("isFlipping", false);
    }
}
