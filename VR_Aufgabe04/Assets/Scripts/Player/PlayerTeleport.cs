using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Teleport"))
            gameObject.transform.position = new Vector3(20f, 0f, 0f);
            Debug.Log("Teleport");
        }
        


    }

