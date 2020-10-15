using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{
    
    private Transform body;
    private Transform camera;
    private Transform hand;
    private Light flashlight;
    
    private float[] recvPacket = new float[6];


    void Start()
    {
        camera = transform.GetChild(0);
        body = transform.GetChild(1);
        hand = camera.GetChild(0);
        flashlight = hand.GetChild(0).GetComponent<Light>();
    }
    
    void Update()
    {

        transform.position = new Vector3(recvPacket[0], recvPacket[1], recvPacket[2]); //change

        /////////////////////////////////

        camera.localRotation = Quaternion.Euler(recvPacket[3], 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, recvPacket[4], 0f);

        /////////////////////////////////
    
        hand.localRotation = Quaternion.Euler(
            90f + 1.5f*(Mathf.PerlinNoise(0, 1f*Time.time)-0.5f), 
            1.5f*(Mathf.PerlinNoise(1f*Time.time, 0)-0.5f), 
            0f);

        ////////////////////////////////
    
        flashlight.enabled = recvPacket[5] > 0; //change

        float noise = Mathf.PerlinNoise(0, 10f*Time.time);

        flashlight.intensity = Mathf.Min(40f + noise*160f, 80f);
    }
}
