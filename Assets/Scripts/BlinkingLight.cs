using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour {

	Light myLight;
    float range;
    float timer = 0.0f;
    int seconds;
    public int blinktime = 3;

    void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)(timer % 60);
        // every blinktime seconds blinks
        if (seconds % blinktime == 0)
        {
            range = Random.Range(0.0f, 0.5f);
            myLight.intensity = range;
            myLight.color = new Color32(42,135,255,255);
        }
        else
        {
            myLight.intensity = 0.35f;
            myLight.color =  Color.white;
        }
        //myLight.intensity = Mathf.PingPong(Time.time, range);
        
    }
}
