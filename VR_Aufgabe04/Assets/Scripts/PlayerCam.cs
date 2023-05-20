using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public Transform orientation;
    float xRot;
    float yRot;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {   
        //Input der Maus X-Achse
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX;
        //Input der Maus Y-Achse
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY;

        yRot += mouseX;
        xRot += mouseY;
        //damit man auf der X-Achse nicht um den körper drehen kann
        xRot = Mathf.Clamp(xRot, sensX - 90f, 90f);

        //Cam orientation und Rotation
        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.rotation = Quaternion.Euler(0, yRot, 0);

    }
}
