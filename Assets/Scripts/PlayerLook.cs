using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    

    private float rotX = 0;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform.parent;
    }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX, -85f, 85f);

        transform.localRotation = Quaternion.Euler(rotX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
