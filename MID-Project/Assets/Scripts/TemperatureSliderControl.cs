using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureSliderControl : MonoBehaviour
{
    public GameObject overlay, plantObj;
    public Sprite plantDead, plantFinal, plantInitial;
    public Slider overlaySlider;
    private float initialScale;
    private Vector3 objectScale;

    public AudioClip flowerGrow;
    private bool flowerGrowFinal = false, flowerDead = false, flowerInitial = true;

    public float timeRemaining = 3;
    public Canvas finalCanvas;

    public AudioClip slideSound, negativeSound, endSound;

    private float initialSlider = 0;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale.y;

        objectScale = transform.localScale;

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
    }

    public void changeOverlay()
    {

        var sliderValue = overlaySlider.value;

        if (Mathf.Abs(sliderValue - initialSlider) > 0.5)
        {
            AudioSource.PlayClipAtPoint(slideSound, transform.position);
            initialSlider = sliderValue;
        }

        transform.localScale = new Vector3(objectScale.x, (initialScale - sliderValue), objectScale.z);

        if (sliderValue > 2.5)
        {
            if (!flowerDead)
            {
                plantObj.gameObject.GetComponent<SpriteRenderer>().sprite = plantDead;
                AudioSource.PlayClipAtPoint(negativeSound, transform.position);
                flowerGrowFinal = false;
                flowerDead = true;
                flowerInitial = false;
            }
        }
        else if ((sliderValue <= 2) && (sliderValue > 1.5))
        {
            if (!flowerGrowFinal)
            {
                plantObj.gameObject.GetComponent<SpriteRenderer>().sprite = plantFinal;
                AudioSource.PlayClipAtPoint(flowerGrow, new Vector3(0, 0, 0));
                flowerGrowFinal = true;
                flowerDead = false;
                flowerInitial = false;

                timeRemaining = 3;

            }
        }
        else if (sliderValue <= 1.5)
        {
            plantObj.gameObject.GetComponent<SpriteRenderer>().sprite = plantInitial;
            flowerInitial = true;
            flowerGrowFinal = false;
            flowerDead = false;
        }
    }


}
