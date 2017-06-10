using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int damage = 1;

    private void Start() {
        GameObject parent = GameObject.Find("Enemies");
        if (parent == null) {
            parent = new GameObject("Enemies");
        }
        transform.SetParent(parent.transform);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject collidedWith = collision.gameObject;

        if (collidedWith.GetComponent<Player>() != null) {
            collidedWith.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
