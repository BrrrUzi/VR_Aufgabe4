using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bahn1 : MonoBehaviour
{
    public GameObject[] cubes; // Array, um die W�rfelobjekte zu halten

    public void MergeAllCubes()
    {
        // Erzeuge ein leeres Spielobjekt f�r den kombinierten W�rfel
        GameObject combinedCube = new GameObject("CombinedCube");

        // Gehe alle W�rfel im Array durch
        foreach (GameObject cube in cubes)
        {
            // Position des aktuellen W�rfels auf die Position des kombinierten W�rfels setzen
            cube.transform.position = combinedCube.transform.position;

            // Skalierung des kombinierten W�rfels auf die Summe der Skalierungen aller W�rfel setzen
            combinedCube.transform.localScale += cube.transform.localScale;

            // Rotationswinkel des kombinierten W�rfels auf den Durchschnitt der Rotationswinkel aller W�rfel setzen
            combinedCube.transform.rotation = Quaternion.Slerp(combinedCube.transform.rotation, cube.transform.rotation, 1f / cubes.Length);

            // Aktuellen W�rfel als Kindobjekt zum kombinierten W�rfel hinzuf�gen
            cube.transform.parent = combinedCube.transform;
        }
    }
}
