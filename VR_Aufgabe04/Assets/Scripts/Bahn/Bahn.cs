using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bahn : MonoBehaviour
{

    // Das Schild, das zu dieser Bahn gehört
    public BahnSchild schild;

    // Der Ursprung der Bahn
    public Vector3 bahnOrigin;




    // Start is called before the first frame update
    void Start()
    {
        // Fülle globale Variablen
        bahnOrigin = transform.position;
        schild = transform.GetChild(0).gameObject.GetComponent<BahnSchild>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
