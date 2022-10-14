using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public GameObject dolphin;
    public Rigidbody dolphin_rb;

    public float rot_Rate;
    public float speed;

    float tilt_Move;

    bool Grounded = true;


    // Start is called before the first frame update
    void Start()
    {
        dolphin_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Tilt();

        TouchControls();

        if (!Grounded)
        {
            //Make the dolphin rotate if finger is held down
            //dolphin.transform.Rotate(new Vector3(0, rot_Rate, 0) * Time.deltaTime);
        }

    }

    void TouchControls()
    {
        //Touch touch = Input.GetTouch(0);

        //if (touch.phase == TouchPhase.Began && Grounded)
        //{
        //    Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //    dolphin_rb.AddForce(new Vector3(0, speed, 0), ForceMode.Impulse);

        //    Grounded = false;
        //}
        //Alternative
        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            //Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            dolphin_rb.AddForce(new Vector3(0, speed, 0), ForceMode.Impulse);

            Grounded = false;
        }

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
