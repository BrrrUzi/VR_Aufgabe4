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
        bahnOrigin = transform.position + new Vector3(0, 0.2f, 0.3f);
        //schild = transform.GetChild(1).gameObject.GetComponent<BahnSchild>();
        int count = 0;
        while (count < transform.childCount) {
            if (transform.GetChild(count).gameObject.GetComponent<BahnSchild>() != null) {
                schild = transform.GetChild(count).gameObject.GetComponent<BahnSchild>();
                break;
            }
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
