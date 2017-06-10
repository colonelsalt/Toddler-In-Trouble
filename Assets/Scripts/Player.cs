﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private float speed;

	void Start () {
		speed = 3f;
	}

	void Update () {
		Vector2 desiredVelocity = new Vector2 (
			Input.GetAxisRaw ("Horizontal"),
			Input.GetAxisRaw ("Vertical")
		);

		desiredVelocity *= speed;

		Rigidbody2D rigidBody2D = this.GetComponent<Rigidbody2D> ();
		rigidBody2D.velocity = desiredVelocity;
	}
}