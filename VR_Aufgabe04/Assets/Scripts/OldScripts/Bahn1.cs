using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bahn1 : MonoBehaviour
{
    public GameObject[] cubes; // Array, um die Würfelobjekte zu halten

    public void MergeAllCubes()
    {
        // Erzeuge ein leeres Spielobjekt für den kombinierten Würfel
        GameObject combinedCube = new GameObject("CombinedCube");

        // Gehe alle Würfel im Array durch
        foreach (GameObject cube in cubes)
        {
            // Position des aktuellen Würfels auf die Position des kombinierten Würfels setzen
            cube.transform.position = combinedCube.transform.position;

            // Skalierung des kombinierten Würfels auf die Summe der Skalierungen aller Würfel setzen
            combinedCube.transform.localScale += cube.transform.localScale;

            // Rotationswinkel des kombinierten Würfels auf den Durchschnitt der Rotationswinkel aller Würfel setzen
            combinedCube.transform.rotation = Quaternion.Slerp(combinedCube.transform.rotation, cube.transform.rotation, 1f / cubes.Length);

            // Aktuellen Würfel als Kindobjekt zum kombinierten Würfel hinzufügen
            cube.transform.parent = combinedCube.transform;
        }
    }
}
