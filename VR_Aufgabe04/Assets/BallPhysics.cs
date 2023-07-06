using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    Vector3 origin;
    Rigidbody _rb;
    Collision other;
    bool hasCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        _rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Schlaeger"))
        {
            this.other = other;
            other.gameObject.GetComponent<Collider>().isTrigger = true;
            hasCollided = true;
            GetComponent<Rigidbody>().velocity = other.gameObject.GetComponent<ClubHead>().getVelocity() * 1.25F;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (hasCollided && _rb.velocity == Vector3.zero)
        {
            other.gameObject.GetComponent<Collider>().isTrigger = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.position = origin;
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
