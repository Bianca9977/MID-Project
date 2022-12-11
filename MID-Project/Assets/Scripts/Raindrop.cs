using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raindrop : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D col;
    private Vector3 pos; //Position

    public Text phaseDisplayText;
    private Touch theTouch;
    private float timeTouchEnded;
    private float displayTime = 2f;
    private bool addDrop = false;


    // Start is called before the first frame update
    void Start()
    {
     //   rb = this.gameObject.GetComponent<Rigidbody2D>();
      //  col = this.gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                if (col.OverlapPoint(wp))
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

                    if (col.OverlapPoint(wp))
                    {
                        rb.gravityScale = 1.0f;
                        dropCounter.increaseCounter();
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

            if (col.OverlapPoint(pos))
            {
                Debug.Log("overlap");
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

            if (!addDrop)
            {
                dropCounter.increaseCounter();
                addDrop = true;
            }
        }
    }
}
