using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [Header("Mouse Look")]
    public bool lockCursor;
    public float senitivity = 2f;
    public Transform player;
    float camVerticalRotation = 0f;
    float mouseX;
    float mouseY;

    [Header("Camera-Collision")]
    Vector3 cameraDirection;
    float camDistance;
    Vector2 cameraDistanceMinMax = new Vector2(0f, 0f);
    public Transform cam;
  

    void Start()
    {
        cameraDirection = cam.transform.localPosition.normalized;
        camDistance = cameraDistanceMinMax.y;



        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
    }

    void LateUpdate()
    {   
        //Inputs
        mouseX = Input.GetAxisRaw("Mouse X") * senitivity * Time.deltaTime;
        mouseY = Input.GetAxisRaw("Mouse Y") * senitivity * Time.deltaTime;
        
        
        camVerticalRotation -= mouseY;
  
        camVerticalRotation = Mathf.Clamp(camVerticalRotation, -60f, 60);
        transform.localRotation = Quaternion.Euler(camVerticalRotation, 0f, 0f);

        player.Rotate(Vector3.up * mouseX) ;

        CheckCameraOcclusionAndCollision(cam);


    }


    public void CheckCameraOcclusionAndCollision(Transform cam)
    {
        Vector3 desiredCameraPosition = transform.TransformPoint(cameraDirection * cameraDistanceMinMax.y);
        RaycastHit hit;
        if(Physics.Linecast(transform.position, desiredCameraPosition, out hit))
        {
            camDistance = Mathf.Clamp(hit.distance, cameraDistanceMinMax.x, cameraDistanceMinMax.y);
        }
        else
        {
            camDistance = cameraDistanceMinMax.y;
        }

        cam.localPosition = cameraDirection * camDistance;
    }


}
