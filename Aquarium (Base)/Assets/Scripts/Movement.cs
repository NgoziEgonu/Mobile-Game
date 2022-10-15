using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.UI;
using TMPro;

public class Movement : MonoBehaviour
{
    public GameObject dolphin;
    public Rigidbody dolphin_rb;

    public float rot_Rate;
    public float speed;

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;

    private Vector3 rot;

    float spins;
    public TextMeshProUGUI spins_Counter;

    float tilt_Move;

    bool Grounded = true;


    // Start is called before the first frame update
    void Start()
    {
        dolphin_rb = GetComponent<Rigidbody>();
        spins = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        Tilt();

        TouchControls();

        if (!Grounded)
        {
            //Dolphin is not rotating
            dolphin.transform.Rotate(rot.x, rot.y + ( speed * Time.deltaTime), rot.z);
            Debug.Log("I'm spinning");
        }

        if ((Mathf.Rad2Deg * dolphin.transform.rotation.y) == 100.0f)
        {
            spins++;
            Debug.Log(spins);

            spins_Counter.text = "" + spins;
        }

        //Debug.Log((Mathf.Rad2Deg * dolphin.transform.rotation.y));

    }

    void TouchControls()
    {
        Touch touch = Input.GetTouch(0);

        if (Input.touchCount > 0 && touch.phase == TouchPhase.Began && Grounded)
        {
            touchStartPos = touch.position;
        }

        if (Input.touchCount > 0 && touch.phase == TouchPhase.Ended && Grounded)
        {
            touchEndPos = touch.position;

            if (touchEndPos.y > touchStartPos.y)
            {
                Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

                dolphin_rb.AddForce(new Vector3(0, speed, 0), ForceMode.Impulse);

                Grounded = false;
            }
        }



        //if (touch.phase == TouchPhase.Began && Grounded)
        //{
        //    Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //    dolphin_rb.AddForce(new Vector3(0, speed, 0), ForceMode.Impulse);

        //    Grounded = false;
        //}
        //Alternative
        //if (Input.GetKey(KeyCode.Space) && Grounded)
        //{
        //    //Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //    dolphin_rb.AddForce(new Vector3(0, speed, 0), ForceMode.Impulse);

        //    Grounded = false;
        //}

    }
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Grounded = true;
        }
    }
}
