using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raindrop : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector3 pos; //Position

    public Text phaseDisplayText;
    private Touch theTouch;
    private float timeTouchEnded;
    private float displayTime = 2f;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                 if (GetComponent<Collider2D>().OverlapPoint(wp))
                 {
                     //rb.gravityScale = 1.0f;          
                 }

                theTouch = Input.GetTouch(0);

                if (theTouch.phase == TouchPhase.Ended)
                {
                    
                    timeTouchEnded = Time.time;
                    phaseDisplayText.text = "eeeeeend";
                }
                else if (Time.time - timeTouchEnded > displayTime)
                {
                    phaseDisplayText.text = "start" + (Time.time - timeTouchEnded);
                    timeTouchEnded = Time.time;

                    if (GetComponent<Collider2D>().OverlapPoint(wp))
                    {
                        rb.gravityScale = 1.0f;          
                    }
                }
            }
            else if (Time.time - timeTouchEnded > displayTime)
            {
                phaseDisplayText.text = "";
            }
        }
       
        else
        {

            pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

            if (GetComponent<Collider2D>().OverlapPoint(pos))
            {
                rb.gravityScale = 1.0f;
            }

        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");

        if (col.gameObject.tag == "Line")
        {
            Destroy(this.gameObject);
        }
    }
}
