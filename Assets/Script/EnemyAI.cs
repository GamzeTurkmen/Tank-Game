using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    NavMeshAgent navMeshAgent;
    Animator fsm;
    Transform player;
    float maxCheckDistance = 10f;
    public Transform rayOrigin;
    Vector3 randomTargetPos;
    float rotSpeed, moveSpeed;
    float minX, maxX, minZ, maxZ;
 
    void Start () {
       
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        fsm = GetComponent<Animator>();
        
        rotSpeed = 5f;
        moveSpeed = 5f;
        float value = 10f;
        minX = -value;
        maxX = value;
        minZ = -value;
        maxZ = value;
}
    private void Update()
    {
        Patrol();
    }
    void FixedUpdate () { 
        float d = Vector3.Distance(player.position, transform.position);
        fsm.SetFloat("distance", d);
        RaycastHit hitInfo;
        Vector3 dir = player.position - rayOrigin.position;
        dir = dir.normalized;

        float distanceFromwayPoint = Vector3.Distance(player.position, transform.position);
        fsm.SetFloat("distanceFromWaypoint", distanceFromwayPoint); //unitydeki fsm animator ile ayarlanan dğişkene  hesaplanan değer gönderilir //görünürlüğü hesapla

        Debug.DrawRay(rayOrigin.position, dir * maxCheckDistance,Color.red);
      
        if (Physics.Raycast(rayOrigin.position, dir, out hitInfo, maxCheckDistance))
        {
            if (hitInfo.transform.tag == "Player")
            {
                fsm.SetBool("isVisible", true);
            }
            else
            {
                fsm.SetBool("isVisible", false);
            }
        }
        else
        {
            fsm.SetBool("isVisible", false);
        }
    }
 
    public void SetLookRotation()
    {
        if (!player)
        {
            return;
        }
        Vector3 dir = player.position - transform.position;
        dir = dir.normalized;
        Quaternion rot = new Quaternion();
        rot.SetLookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.1f);
    }
    public void Chase()
    {
        navMeshAgent.SetDestination(player.position);
    }

    public void Patrol()
    {
        if (Vector3.Distance(transform.position, randomTargetPos) < 2f) return;
          FindNewTarget();
        MoveToTarget();
    }
    public void Shoot()
    {
        transform.GetComponent<TankShooting>().Shoot();
    }
     private void FindNewTarget()
    {
        float xPos = UnityEngine.Random.Range(minX, maxX);
        float zPos = UnityEngine.Random.Range(minZ, maxZ);
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
