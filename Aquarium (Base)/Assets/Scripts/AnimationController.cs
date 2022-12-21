using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    //public Rigidbody dolphin_rb;

    Movement movement;
    ScoreCounter scoreCounter;

    public int flips;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        //dolphin_rb = GetComponent<Rigidbody>();
        movement = FindObjectOfType<Movement>();
        scoreCounter = FindObjectOfType<ScoreCounter>();

        speed = 7.0f;
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

            if (touch.position.y < Screen.height / 1.4f)
            {
                if (touch.tapCount == 2 && !anim.GetBool("isFlipping") && !movement.Grounded)
                {
                    //dolphin_rb.AddForce(new Vector3(0, speed, 0), ForceMode.Impulse);
                    anim.SetBool("isFlipping", true);
                    flips++;
                    scoreCounter.score += 3;
                    Debug.Log("Flip");
                    // anim.SetBool("isFlipping", false);

                    Invoke(nameof(ResetFlip), 1.0f);
                }
            }
        }
    }
    void ResetFlip()
    {
        anim.SetBool("isFlipping", false);
    }
}
