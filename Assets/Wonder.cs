using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wonder : MonoBehaviour {


    Vector3 randomTargetPos;
    float rotSpeed, moveSpeed;
    float minX, maxX, minZ, maxZ;
    private void Start()
    {
        InitializeParameters();


    }
    private void InitializeParameters()
    {
        rotSpeed = 5f;
        moveSpeed = 5f;
        float value = 10f;
        minX = -value;
        maxX = value;
        minZ = -value;
        maxZ  = value;

    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(randomTargetPos, transform.position) < 2f)
          FindNewTarget();
        MoveToTarget();



    }
    private void FindNewTarget()
    {
        float xPos = Random.Range(minX, maxX);
        float zPos= Random.Range(minZ, maxZ);
        randomTargetPos = new Vector3(xPos, transform.position.y, zPos);

    }
    private void MoveToTarget()
    {
        Vector3 dir = randomTargetPos - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotSpeed);

        transform.Translate(Vector3.forward * moveSpeed);

    }
}
