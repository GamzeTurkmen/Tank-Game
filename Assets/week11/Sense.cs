using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sense : MonoBehaviour,ISense {
    protected float elapsedTime;//gecen zaman
    protected float detectionRate; //sıklıgı

    protected TankAspect tAspect = TankAspect.ENEMY;
    // Use this for initialization
    void Start () {
        Initialize();

    }
	
	// Update is called once per frame
	void Update () {
        elapsedTime = Time.time;
        if (elapsedTime > detectionRate)
        {
            UpdateSense();
            detectionRate = elapsedTime + 0.5f;

        }

    }
    public abstract void Initialize();
    public abstract void UpdateSense();
}
