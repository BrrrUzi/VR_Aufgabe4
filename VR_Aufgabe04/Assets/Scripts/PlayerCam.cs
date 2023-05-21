using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float senitivity = 2f;
    public Transform orientation;
    float camVerticalRotation = 0;
    float camHorizontalRotation = 2;
  

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {   
        //Inputs
        float mouseX = Input.GetAxisRaw("Mouse X") * senitivity ;
        float mouseY = Input.GetAxisRaw("Mouse Y") * senitivity ;


        camVerticalRotation -= mouseY;
        camHorizontalRotation -= mouseX;
        //damit man auf der X-Achse nicht um den körper drehen kann
        camVerticalRotation = Mathf.Clamp(camVerticalRotation, -90f, 90f);
        //Cam orientation und Rotation
        transform.localEulerAngles = Vector3.right * camVerticalRotation;
        transform.localEulerAngles = Vector3.right * camHorizontalRotation;

        //camHorizontalRotation -= mouseX;
        camVerticalRotation -= mouseY;

    }
}
