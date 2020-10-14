using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotX = 90f + 1.5f*(Mathf.PerlinNoise(0, 1f*Time.time)-0.5f);
        float rotY = 1.5f*(Mathf.PerlinNoise(1f*Time.time, 0)-0.5f);
        transform.localRotation = Quaternion.Euler(rotX, rotY, 0f);
    }
}
