 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
using TMPro;

public class Movement : MonoBehaviour
{
    public GameObject dolphin;
    public Rigidbody dolphin_rb;

    //[SerializeField]
    //private Animator anim;

    ScoreCounter scoreCounter;

    float rot_Rate;
    public float speed;
    public TextMeshProUGUI spins_Counter;

    public int spins;
    float rot1;
    float rot2;
    float rot_Difference;

    float tilt_Move;

    [SerializeField]
    bool Grounded = true;
    [SerializeField]
    bool Something = true;


    // Start is called before the first frame update
    void Start()
    {
        rot_Rate = 250.0f;
        dolphin_rb = GetComponent<Rigidbody>();
        scoreCounter = FindObjectOfType<ScoreCounter>();

        //anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Tilt need reworking
        //Tilt();

        TouchControls();

        //Flip();
        

    }

    public void TouchControls()
    {
        if (Input.touchCount > 0)
        {
            if (Something)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began && Grounded)
                {
                    Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                    dolphin_rb.AddForce(new Vector3(0, speed, 0), ForceMode.Impulse);

                    scoreCounter.Scoring();

                    StartCoroutine(WaitASecond());
                }

                if (touch.phase == TouchPhase.Stationary && !Grounded)
                {

                    rot1 = dolphin.transform.rotation.eulerAngles.y;

                    dolphin.transform.Rotate(new Vector3(0, rot_Rate * Time.deltaTime, 0));

                    rot2 = dolphin.transform.rotation.eulerAngles.y;

                    rot_Difference = rot2 - rot1;

                    if (rot_Difference < 0) //Reference: https://stackoverflow.com/questions/44117470/counting-rotations-unity-c
                    {
                        spins++;
                        scoreCounter.score += 10;
                        spins_Counter.text = "" + spins + " spins";
                    }

                }

                if (touch.phase == TouchPhase.Ended)
                {
                    Something = false;
                }
            }
            

        }

        //Alternative for Keyboard
        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            dolphin_rb.AddForce(new Vector3(0, speed, 0), ForceMode.Impulse);

            Grounded = false;
        }
    }

    //void Flip()
    //{
    //    //Flip Mechanic Not working properly yet
    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);
    //        if (touch.tapCount == 2 && !anim.GetBool("isFlipping"))
    //        {
    //            anim.SetBool("isFlipping", true);
    //            flips++;
    //            //scoreCounter.score += 3;
    //            Debug.Log("Flip");
    //            // anim.SetBool("isFlipping", false);
                
    //            Invoke(nameof(ResetFlip), 0.4f);
    //        }         
    //    }
    //}
    //void ResetFlip()
    //{
    //    anim.SetBool("isFlipping", false);
    //}

    void Tilt()
    {
        tilt_Move = Input.acceleration.x * speed;

        dolphin.transform.Translate(0, 0, tilt_Move * Time.deltaTime);

        //Alternative
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dolphin.transform.Translate(0, 0, -speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            dolphin.transform.Translate(0, 0, speed * Time.deltaTime);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            
            Grounded = true;
            Something = true;
        }
    }
    
    IEnumerator WaitASecond()
    {
        yield return new WaitForSeconds(0.15f);
        Grounded = false;
        //Debug.Log("Delaying as I should");
    }
}
