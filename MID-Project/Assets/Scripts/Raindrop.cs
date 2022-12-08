using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raindrop : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector3 pos; //Position

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0)
            {
                Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                //  Debug.Log(wp);
                if (GetComponent<Collider2D>().OverlapPoint(wp))
                {
                    rb.gravityScale = 1.0f;
                }
            }
        } else
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
        Destroy(this.gameObject);
    }
}
