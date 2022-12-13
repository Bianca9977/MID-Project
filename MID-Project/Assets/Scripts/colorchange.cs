using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorchange : MonoBehaviour
{

    public Material redColor, blueColor; // public variables 
    Material currentColor; //private variable in which we store the current color value of the material
    MeshRenderer myRenderer;


    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material = blueColor;
        currentColor = blueColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            if (currentColor == blueColor)
            {
                currentColor = redColor;
            }

            else
            {
                currentColor = blueColor;
            }
        }
        
        
        //lerp = gradually transition from the color of the game object to current color with interpolating factor of 0.1 
        myRenderer.material.Lerp(myRenderer.material, currentColor, 0.1f);
    }
}
