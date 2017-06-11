using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

    private bool lavaActive = true;

    private void handlePowerOn() {
        lavaActive = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
    private void handlePowerOff() {
        lavaActive = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.GetComponent<Player>() != null && lavaActive) {
            collidedWith.GetComponent<Health>().TakeDamage(1);
        }
    }
}
