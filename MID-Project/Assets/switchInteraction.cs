using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchInteraction : MonoBehaviour
{
    public GameObject plantObj;
    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;

    public Collider2D col;
    private bool turnLeft = false, turnRight = true;

    public GameObject colorPlane;
    public Material redColor, blueColor; // public variables 
    Material currentColor; //private variable in which we store the current color value of the material
    MeshRenderer myRenderer;

    private bool flowerGrowFinal = false, flowerDead = false, flowerInitial = true;
    public Sprite plantDead, plantFinal, plantInitial;

    public Canvas finalCanvas;
    public float timeRemaining = 5;

    public AudioClip endSound, flowerGrow;

    public Animator animator1;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = colorPlane.GetComponent<MeshRenderer>();
        myRenderer.material = blueColor;
        currentColor = redColor;

        finalCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (flowerGrowFinal)
        {
            if (timeRemaining > 0)

            {
                timeRemaining -= Time.deltaTime;

            }

            else
            {
                finalCanvas.gameObject.SetActive(true);
                AudioSource.PlayClipAtPoint(endSound, transform.position);
                flowerGrowFinal = false;
            }
        }

        if (switchLight.lightSwitch)
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
                        if (Mathf.Abs(x) > Mathf.Abs(y))
                        {

                            Debug.Log((x > 0) + " " + (transform.localRotation.eulerAngles.z > 180f) + " " + (transform.localRotation.eulerAngles.z <= 360f) + " actual rotation " + transform.localRotation.eulerAngles.z);

                            //rotate right
                            if ((x > 0) && (transform.localRotation.eulerAngles.z > 180f) && (transform.localRotation.eulerAngles.z <= 360f) && turnRight)
                            {
                                turnLeft = true;
                                transform.Rotate(new Vector3(0, 0, 1) * -180.0f * Time.deltaTime);
                                myRenderer.material.Lerp(myRenderer.material, currentColor, 0.2f);

                                if (transform.localRotation.eulerAngles.z <= 180f)
                                {
                                    turnRight = false;
                                    turnLeft = true;
                                    transform.Rotate(new Vector3(0, 0, 1) * 180.0f * Time.deltaTime);
                                    Debug.Log("turn right " + transform.localRotation.eulerAngles.z);
                                    currentColor = blueColor;
                                }

                            }
                            else if ((x <= 0) && (transform.localRotation.eulerAngles.z > 180f) && (transform.localRotation.eulerAngles.z <= 360f) && turnLeft)
                            {

                                transform.Rotate(new Vector3(0, 0, 1) * 180.0f * Time.deltaTime);
                                myRenderer.material.Lerp(myRenderer.material, currentColor, 0.2f);

                                if ((transform.localRotation.eulerAngles.z > 0f) && (transform.localRotation.eulerAngles.z < 90f))
                                {
                                    turnRight = true;
                                    turnLeft = false;
                                    transform.Rotate(new Vector3(0, 0, 1) * -180.0f * Time.deltaTime);
                                    Debug.Log("turn left " + transform.localRotation.eulerAngles.z);
                                    currentColor = redColor;
                                }
                            }

                            if ((transform.localRotation.eulerAngles.z > 260f) && (transform.localRotation.eulerAngles.z < 295f)) {
                                plantObj.gameObject.GetComponent<SpriteRenderer>().sprite = plantFinal;
                                AudioSource.PlayClipAtPoint(flowerGrow, new Vector3(0, 0, 0));
                                flowerGrowFinal = true;
                                flowerDead = false;
                                flowerInitial = false;

                                animator1.enabled = false;
                                animator1.gameObject.SetActive(false);

                            } else if (transform.localRotation.eulerAngles.z > 320f)
                            {
                                plantObj.gameObject.GetComponent<SpriteRenderer>().sprite = plantInitial;
                                flowerGrowFinal = false;
                                flowerDead = false;
                                flowerInitial = true;
                            } else if (transform.localRotation.eulerAngles.z < 210f)
                            {
                                plantObj.gameObject.GetComponent<SpriteRenderer>().sprite = plantDead;
                                flowerGrowFinal = false;
                                flowerDead = true;
                                flowerInitial = false;
                            }

                        }
                    }
                }
            }
        }

      
    }
}
