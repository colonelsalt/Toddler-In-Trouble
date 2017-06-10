﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 3f;
    private static Player instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Update () {
		Vector2 desiredVelocity = new Vector2 (
			Input.GetAxisRaw ("Horizontal"),
			Input.GetAxisRaw ("Vertical")
		);

		desiredVelocity *= speed;

		Rigidbody2D rigidBody2D = this.GetComponent<Rigidbody2D> ();
		rigidBody2D.velocity = desiredVelocity;
	}
}