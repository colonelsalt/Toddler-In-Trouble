using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 3f;
    private static Player instance;
    private ArrayList inventory;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        inventory = new ArrayList();
    }

    private void Update () {
		Vector2 desiredVelocity = new Vector2 (
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical")
		);

		desiredVelocity *= speed;

		Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D> ();
		rigidBody2D.velocity = desiredVelocity;
	}

    public void PickupItem(Item item) {
        if (item == Item.Gun && !inventory.Contains(item)) {
            inventory.Add(item);
        }
    }
}