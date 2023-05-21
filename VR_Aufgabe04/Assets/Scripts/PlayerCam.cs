using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float senitivity = 2f;
    public Transform player;
    float camVerticalRotation = 0f;
    
  

    void Start()
    {   
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void Update()
    {   
        //Inputs
        float mouseX = Input.GetAxisRaw("Mouse X") * senitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * senitivity * Time.deltaTime;

        camVerticalRotation -= mouseY;

        camVerticalRotation = Mathf.Clamp(camVerticalRotation, -60f, 60);
        transform.localRotation = Quaternion.Euler(camVerticalRotation, 0f, 0f);

        player.Rotate(Vector3.up * mouseX) ;


    }
}
