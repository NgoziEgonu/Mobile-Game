using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
using TMPro;

public class Movement : MonoBehaviour
{
    public GameObject dolphin;
    public Rigidbody dolphin_rb;

    ScoreCounter scoreCounter;

    float flip_Rate;
    public float rot_Rate;
    public float speed;
    //public TextMeshProUGUI spins_Counter;

    float tilt_Move;

    bool Grounded = true;
    bool delay = false;


    // Start is called before the first frame update
    void Start()
    {
        flip_Rate = Mathf.Rad2Deg * (100.0f) * Time.deltaTime;
        dolphin_rb = GetComponent<Rigidbody>();
        scoreCounter = FindObjectOfType<ScoreCounter>(); // Reference https://stackoverflow.com/questions/34436458/unity-c-how-to-call-a-function-from-another-script-to-start-animation
    }

    // Update is called once per frame
    void Update()
    {

        //Tilt();

        TouchControls();

        //Flip Mechanic Not working properly yet
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    if (touch.tapCount == 2)
        //    {
        //        dolphin.transform.Rotate(new Vector3(0, 0, flip_Rate ));
        //    }
        //}

    }

    void TouchControls()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && Grounded)
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                dolphin_rb.AddForce(new Vector3(0, speed, 0), ForceMode.Impulse);

                scoreCounter.Scoring();

                Grounded = false;
                delay = true;
            }

            if (touch.phase == TouchPhase.Stationary && !Grounded)
            {
                //Delay is not working properly
                if (delay == true)
                {
                    StartCoroutine(WaitASecond());

                    dolphin.transform.Rotate(new Vector3(0, rot_Rate * Time.deltaTime, 0));
                }

            }

            if (touch.phase == TouchPhase.Ended)
            {
                delay = false;
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

    //void Tilt()
    //{
    //    tilt_Move = Input.acceleration.x * speed;

    //    dolphin.transform.Translate(0, 0, tilt_Move * Time.deltaTime);

    //    //Alternative
    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        dolphin.transform.Translate(0, 0, -speed * Time.deltaTime);
    //    }

    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        dolphin.transform.Translate(0, 0, speed * Time.deltaTime);
    //    }

    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Grounded = true;
        }
    }
    
    IEnumerator WaitASecond()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Delaying milady");
    }
}
