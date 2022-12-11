using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureSliderControl : MonoBehaviour
{
    public GameObject overlay;
    public Slider overlaySlider;
    private float initialScale;
    private Vector3 objectScale;
    public Text PlantStatus;


    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale.y;

        objectScale = transform.localScale;    

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeOverlay()
    {
        OscMessage message = new OscMessage();

        message.address = "/Direction";

        var sliderValue = overlaySlider.value;

        transform.localScale = new Vector3(objectScale.x, (initialScale - sliderValue), objectScale.z);

        if (sliderValue > 2.5)
        {
            PlantStatus.text = "Plant dead";
        }
        else if ((sliderValue <= 2) && (sliderValue > 1.5))
        {
            PlantStatus.text = "Plant grow";
        }
    }


}
