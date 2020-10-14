using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light flashlight;
    
    void Start()
    {
        flashlight = gameObject.GetComponent<Light>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            flashlight.enabled = !flashlight.enabled;
        }

        float noise = Mathf.PerlinNoise(0, 10f*Time.time);

        flashlight.intensity = Mathf.Min(40f + noise*160f, 80f);
    }
}
