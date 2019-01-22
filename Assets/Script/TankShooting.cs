using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour {

    public Transform shellSpawn;
    public GameObject shellPrefab;
    public float moveSpeed = 1000f;
    public bool isAI = false;

    
	// Use this for initialization
	void FixedUpdate () {
        if (isAI) return;
        if (Input.GetKey(KeyCode.Mouse0))
            Shoot();
       }
    float nextShoot = 0f;
    float frequency = 10f;

	
	public void Shoot()
    {
        if (Time.time > nextShoot)
        {
            GameObject sheel = Instantiate(shellPrefab, shellSpawn.position, Quaternion.identity);
            sheel.GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed * Time.deltaTime;
            nextShoot = Time.time + 1f / frequency;

        }
    }
}
