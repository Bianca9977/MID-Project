using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropCounter : MonoBehaviour
{

    public static GameObject waterLevel, plantObj;
    public Sprite waterLevel2, waterLevel3, waterLevel4, plantGrow;
    private static int counter = 0;
    private static Sprite waterLevel2Copy, waterLevel3Copy, waterLevel4Copy, plantGrowCopy;

    public AudioClip waterSound, flowerGrow;
    public static AudioClip waterSoundCopy, flowerGrowCopy;

    // Start is called before the first frame update
    void Start()
    {
        waterLevel2Copy = waterLevel2;
        waterLevel3Copy = waterLevel3;
        waterLevel4Copy = waterLevel4;
        plantGrowCopy = plantGrow;

        waterLevel = GameObject.Find("waterLevel");
        plantObj = GameObject.Find("middlePlant");

        waterSoundCopy = waterSound;
        flowerGrowCopy = flowerGrow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void increaseCounter()
    {
        counter++;
        Debug.Log("counter " + counter);

        if (counter == 2)
        {
            waterLevel.gameObject.GetComponent<SpriteRenderer>().sprite = waterLevel2Copy;
            AudioSource.PlayClipAtPoint(waterSoundCopy, new Vector3(0,0,0));
        } 
        if (counter == 4)
        {
            waterLevel.gameObject.GetComponent<SpriteRenderer>().sprite = waterLevel3Copy;
            AudioSource.PlayClipAtPoint(waterSoundCopy, new Vector3(0, 0, 0));
        }
        if (counter == 6)
        {
            waterLevel.gameObject.GetComponent<SpriteRenderer>().sprite = waterLevel4Copy;
            AudioSource.PlayClipAtPoint(waterSoundCopy, new Vector3(0, 0, 0));
            plantObj.gameObject.GetComponent<SpriteRenderer>().sprite = plantGrowCopy;
            AudioSource.PlayClipAtPoint(flowerGrowCopy, new Vector3(0, 0, 0));
        }
    }
}
