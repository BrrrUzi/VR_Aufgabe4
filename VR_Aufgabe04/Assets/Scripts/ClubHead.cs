using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubHead : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 posI;
    private Vector3 posF;
    private Vector3 vel;
    private float velMag;
    public float maxVel;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        //Store initial and final position at start
        posI = posF = transform.position;
    }

    private void FixedUpdate()
    {
        //Update initial and final positions
        posI = posF;
        posF = transform.position;
        //_rb.MovePosition(transform.position - (transform.forward * Time.fixedDeltaTime * maxVel));
        /*
        if(_rb.velocity != Vector3.zero)
        {
            Debug.Log(_rb.velocity + "| " + _rb.position);
        }
        */
    }

    public Vector3 getVelocity()
    {
        //Calculate velocity
        vel = (posF - posI) * 40;
        velMag = vel.magnitude;
        //Limit velocity
        /*if (velMag > maxVel)
        {
            vel = vel.normalized * maxVel;
        }
        */
        Debug.Log("Pos1" + posF + " Pos2" + posI);
        Debug.Log(vel * 100);
        return vel;
    }
}
