using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLinie : MonoBehaviour
{
    public Color[] colors; // Array der Farben für die einzelnen Abschnitte der Linie
    private LineRenderer lineRenderer;




    void Start()
    {


        {
            lineRenderer = GetComponent<LineRenderer>();

            // Überprüfe, ob genügend Farben für die Anzahl der gewünschten Abschnitte vorhanden sind
            if (colors.Length < lineRenderer.positionCount)
            {
                Debug.LogError("Nicht genügend Farben für die Anzahl der Abschnitte vorhanden!");
                return;
            }

            // Setze die Farben für die einzelnen Abschnitte der Linie
            for (int i = 0; i < lineRenderer.positionCount; i++)
            {
                lineRenderer.SetColors(colors[i], colors[i]);
            }


        }
    }
}
