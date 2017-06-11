using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour {

    private Health health;
	
    private void handlePowerOn() {
        GetComponent<WalkingAnimations>().enabled = true;
        health = gameObject.AddComponent<Health>();
        health.health = 12;
    }

    private void handlePowerOff() {
        if (health != null) {
            Destroy(health);
        }
        GetComponent<WalkingAnimations>().enabled = false;
    }
}
