using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Transform target;
    float rotSpeed = 5f;
    float moveSpeed = 8f;

	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, target.position) < 2f) return;
        MoveToTarget();

       }
    private void MoveToTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }
}
