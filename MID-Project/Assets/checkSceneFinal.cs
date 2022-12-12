using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkSceneFinal : MonoBehaviour
{
    private bool gameEnd = false;
    public Canvas finalCanvas;
    public static Canvas finalCanvasCopy;

    // Start is called before the first frame update
    void Start()
    {
        finalCanvasCopy = finalCanvas;

        finalCanvasCopy.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGameEnd()
    {
        Debug.Log("game end");
    }
}
