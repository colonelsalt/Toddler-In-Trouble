using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour {

    public AudioClip entranceSound;
    private Health health;

    private void Start() {
        health = GetComponent<Health>();
        AudioSource.PlayClipAtPoint(entranceSound, transform.position);
    }

    private void handlePowerOn() {
        GetComponent<WalkingAnimations>().enabled = true;
        health.health = 12;
        health.isBear = false;
    }

    private void handlePowerOff() {
        health.isBear = true;
        GetComponent<WalkingAnimations>().enabled = false;
    }
}
