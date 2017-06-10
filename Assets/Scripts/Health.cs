using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 100f;
	
	public void TakeDamage(float amount) {
        // TODO: Activate damage animation here
        Debug.Log(name + " took damage: " + amount);

        health -= amount;
        if (health <= 0) {
            Die();
        }
    }

    public void Die() {
        // TODO: activate death animation here
        if (GetComponent<Player>() != null) {
            FindObjectOfType<RoomManager>().ResetLevel();
        }
        Destroy(gameObject);
    }
}
