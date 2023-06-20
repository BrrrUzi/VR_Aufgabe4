using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLinie : MonoBehaviour
{
    public Color[] colors; // Array der Farben f�r die einzelnen Abschnitte der Linie
    private LineRenderer lineRenderer;




    void Start()
    {


        {
            lineRenderer = GetComponent<LineRenderer>();

            // �berpr�fe, ob gen�gend Farben f�r die Anzahl der gew�nschten Abschnitte vorhanden sind
            if (colors.Length < lineRenderer.positionCount)
            {
                Debug.LogError("Nicht gen�gend Farben f�r die Anzahl der Abschnitte vorhanden!");
                return;
            }

            // Setze die Farben f�r die einzelnen Abschnitte der Linie
            for (int i = 0; i < lineRenderer.positionCount; i++)
            {
                lineRenderer.SetColors(colors[i], colors[i]);
            }


        }
    }
}
