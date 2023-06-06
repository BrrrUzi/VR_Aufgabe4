using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public Rigidbody body;
    Camera camera;
    public float stopVelocity;
    public float shotPower;
    public float maxPower;
    bool isAiming;
    bool isIdle;
    bool isShooting;
    Vector3? worldPoint;



    
    void Awake()
    {
        camera = Camera.main;
        body.maxAngularVelocity = 1000;
        isAiming = false;

    }

   
    void Update()
    {
        if(body.velocity.magnitude < stopVelocity)
        {
            ProcessAim();

            if(Input.GetMouseButtonDown(0))
            {
                if(isIdle)
                {
                    isAiming = true;
                }
                if(Input.GetMouseButtonUp(0)) { 
                isShooting = true;  
                }

            }

        }



    }
    private void FixedUpdate()
    {
        if(body.velocity.magnitude < stopVelocity )
        {
            stop();
        }

        if (isShooting)
        {
            Shoot(worldPoint.Value);
            isShooting=false;
        }
    }

    private void ProcessAim()
    {
        if(!isAiming && !isIdle)return;

        worldPoint = CastMouseClickRay();
        if (worldPoint.HasValue) return;
    }


    private Vector3? CastMouseClickRay()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) { return hit.point; }
        else return null;
    }

    private void stop()
    {
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;

        isIdle = true;
    }

    private void Shoot(Vector3 point)
    {
        isAiming = false;
        Vector3 horizontalWorldPoint = new Vector3(point.x, transform.position.y, point.z);

        Vector3 direction = (horizontalWorldPoint - transform.position).normalized;
        float strenght = Vector3.Distance(transform.position, horizontalWorldPoint);
        body.AddForce(direction * strenght * shotPower);

    }

}
