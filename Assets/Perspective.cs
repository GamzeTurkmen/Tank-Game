using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : Sense {

    float fieldOfView=60f;
    float viewDistance=100f;
    Transform playerTank;
    Vector3 dir;
    public Transform rayDirection;

    public override void Initialize()
    {
        playerTank = GameObject.FindGameObjectWithTag("Player").transform;

    }
    public override void UpdateSense()
    {
        Vector3 dir = playerTank.position - transform.position;
        if (Vector3.Angle(dir, transform.forward) < fieldOfView)
        {
            RaycastHit hitInfo;
            if(Physics.Raycast(rayDirection.position,dir,out hitInfo,viewDistance))
            {
                Aspect aspect = hitInfo.collider.GetComponent<Aspect>();
                if (aspect != null)
                {
                    if (aspect.tankAspect == tAspect)
                        Debug.Log("enemy detected");

                }
            }
        }
    }
    
}
