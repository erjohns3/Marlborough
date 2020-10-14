using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    public float gravity = -9.81f;
    public float bounce = 0.04f;
    
    private CharacterController controller;
    private float velY = 0f;
    private float step = 0f;
    private float movement = 0f;
    private bool isGrounded = true;
    private Transform body;
    private Transform camera;
    

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        camera = transform.GetChild(0);
        body = transform.GetChild(1);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.normal.y > 0.5){
            isGrounded = true;
        }else if(hit.normal.y < -0.9 && hit.moveDirection.y > 0 && velY > 0){
            velY = 0;
        }
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false; 
        }

        if(!Physics.CheckSphere(transform.position, 0.1f)){
            isGrounded = false;
        }

        if(Input.GetKey(KeyCode.LeftControl)){
            speed = 8;
        }else{
            speed = 4;
        }

        if(Input.GetKey(KeyCode.LeftShift)){
            speed = 8;
        }else{
            speed = 4;
        }

        if(isGrounded){
            if(Input.GetKeyDown(KeyCode.Space)){
                velY = 4;
                isGrounded = false;
            }else{
                velY = 0;
            }
        }else{
            velY += gravity * Time.deltaTime;
        }

        float posX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float posZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if(posX !=0 || posZ != 0){
            movement += 1.5f * Mathf.Max(Mathf.Abs(posX), Mathf.Abs(posZ));
            step = Mathf.Abs(Mathf.Sin(movement));
        }else{
            step = Mathf.Max(step - 5f*Time.deltaTime, 0);
            movement = Mathf.Asin(step);
        }
        

        float posY = velY * Time.deltaTime;

        body.transform.localPosition = new Vector3(0f, 0.9f+step*bounce, 0f);
        camera.transform.localPosition = new Vector3(0f, 1.68f+step*bounce, 0f);

        controller.Move(transform.right*posX + transform.forward*posZ + Vector3.up*posY);
    }
}
