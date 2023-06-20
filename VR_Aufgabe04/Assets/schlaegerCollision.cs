using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class schlaegerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //CollisionHandler colHandler = GetComponent<CollisionHandler>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Test");
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag.Equals("Ball")) {
            Debug.Log("LOL");
            Vector3 vector = new Vector3(0, 1, 0);
            col.gameObject.transform.Translate(vector);
        }
    }
}
