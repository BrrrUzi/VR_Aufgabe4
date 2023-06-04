using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;

    private bool isFirstPerson = true;

    public ScriptGroupController scriptGroupController; // Referenz auf das ScriptGroupController-Skript

    void Start()
    {
        scriptGroupController.DisableScripts();
        camera1.enabled = true;
        camera2.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isFirstPerson = !isFirstPerson;

            if (isFirstPerson)
            {
                camera1.enabled = true;
                camera2.enabled = false;
            }
            else
            {
                camera1.enabled = false;
                camera2.enabled = true;

                // Rufe die EnableScripts()-Methode des ScriptGroupController-Skripts auf
                scriptGroupController.EnableScripts();
            }
        }
    }
}