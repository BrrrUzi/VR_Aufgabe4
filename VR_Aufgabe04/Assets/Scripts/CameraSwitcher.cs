using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    public ScriptGroupController[] scriptControllers;

    private int currentCameraIndex = 0;

    void Start()
    {
        // Aktiviere die erste Kamera und die zugehörigen Skriptgruppe
        SetCameraActive(currentCameraIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Deaktiviere die aktuelle Kamera und die zugehörige Skriptgruppe
            SetCameraActive(currentCameraIndex, false);

            // Inkrementiere den Kamera-Index
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

            // Aktiviere die neue Kamera und die zugehörige Skriptgruppe
            SetCameraActive(currentCameraIndex);
        }
    }

    private void SetCameraActive(int cameraIndex, bool activateScripts = true)
    {
        // Aktiviere die gewünschte Kamera
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = (i == cameraIndex);
        }

        // Aktiviere/deaktiviere die Skriptgruppe der gewünschten Kamera
        if (activateScripts)
        {
            scriptControllers[cameraIndex].EnableScripts();
        }
        else
        {
            scriptControllers[cameraIndex].DisableScripts();
        }
    }
}
