using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TankHealth : MonoBehaviour {

    public Text healthText;
    float health = 100f;

	// Use this for initialization
	void Start ()
    {
        NewMethod();

    }

    private void NewMethod()
    {
        healthText.text = health.ToString();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
            Die();
        healthText.text = health.ToString();

    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
