using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void Start()
    {
       
    }
    public void Quitgame()
    {
        Debug.Log("Quit");
        Application.Quit();
        Debug.Log("Quit");
    }
}
