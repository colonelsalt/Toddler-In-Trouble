﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float speed = 3f;

    private void Start() {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += SetNewRoomPos;
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

    private void SetNewRoomPos(Scene scene, LoadSceneMode mode) {
        if (transform.position.y < 1 || transform.position.y > 13) {

        } else if (transform.position.x < 1 || transform.position.x > 18) {

        }
    }
}