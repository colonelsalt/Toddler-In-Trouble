using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float damage;

	void OnTriggerEnter2D(Collider2D other) {
        Health otherHealth = other.GetComponent<Health>();
        if (otherHealth != null) {
            otherHealth.TakeDamage(1);
        }
		Destroy(gameObject);
	}
}
