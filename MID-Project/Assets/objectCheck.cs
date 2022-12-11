using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectCheck : MonoBehaviour
{ 

    public OSC osc;
    public GameObject canvasObj;

    // Start is called before the first frame update
    void Start()
    {
        osc.SetAddressHandler("/Object", OnReceiveObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnReceiveObject(OscMessage message)
    {
        float x = message.GetFloat(0);

        Debug.Log("message " + x);

       // canvasObj.SetActive(false);
    }
}
