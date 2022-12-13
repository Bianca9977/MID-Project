using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchLight : MonoBehaviour
{

    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;
    private string direction;

    public Collider2D col;
    public static bool lightSwitch = false;
    public GameObject lighObj, planeObj;

    // Start is called before the first frame update
    void Start()
    {
        lighObj.gameObject.SetActive(false);
        planeObj.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            if (theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
            }
            else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                touchEndPosition = theTouch.position;

                float x = touchEndPosition.x - touchStartPosition.x;
                float y = touchEndPosition.y - touchStartPosition.y;


                if (col.OverlapPoint(wp))
                {
                    if ((Mathf.Abs(x) < Mathf.Abs(y)) && (!lightSwitch))
                    {
                      if (y < 0)
                        {
                            lightSwitch = true;
                            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, (gameObject.transform.localScale.y + 0.1f), gameObject.transform.localScale.z);
                            lighObj.gameObject.SetActive(true);
                            planeObj.gameObject.SetActive(true);
                        }
                    }
                }

            }
        }
    }
}
