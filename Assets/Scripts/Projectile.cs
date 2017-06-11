using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
        Health otherHealth = other.GetComponent<Health>();
        if (otherHealth != null) {
            otherHealth.TakeDamage(1);
        }
		Destroy(gameObject);
	}
}
