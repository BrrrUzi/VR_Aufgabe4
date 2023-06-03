using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CammeraSwitch : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;

    void Start()
    {
        // Aktiviere die erste Kamera und deaktiviere die zweite Kamera zu Beginn
        camera1.enabled = true;
        camera2.enabled = false;
    }

    void Update()
    {
        // Überprüfe den Tastatureingang, um zwischen den Kameras umzuschalten
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Wechsle die Aktivierung der Kameras
            camera1.enabled = !camera1.enabled;
            camera2.enabled = !camera2.enabled;
        }
    }
}
