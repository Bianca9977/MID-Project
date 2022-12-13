using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeToLightScene()
    {
        SceneManager.LoadScene("LightScene");
    }
    public void ChangeToTemperatureScene()
    {
        SceneManager.LoadScene("TemperatureScene");
    }
    public void ChangeToWaterScene()
    {
        SceneManager.LoadScene("first_scene");
    }
    public void ChangeToMainScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void ChangeToMiddleScene()
    {
        SceneManager.LoadScene("MiddleScene");
    }
    public void ChangeToFinalScene()
    {
        SceneManager.LoadScene("FinalScene");
    }

}
