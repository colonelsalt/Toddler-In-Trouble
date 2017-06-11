using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ghost : MonoBehaviour {
	public enum Behaviour {
		Chase, Flee, Sleep
	}

	public Behaviour behaviour;
    public float movementSpeed;

    private Player player;
    private Rigidbody2D mBody;

    void Start () {
        player = FindObjectOfType<Player>();
        mBody = GetComponent<Rigidbody2D>();
        mBody.velocity = Vector3.zero;
	}
	
	void Update () {
		if (player != null) {
			Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D> ();


			if (behaviour == Behaviour.Sleep) {
				rigidBody2D.velocity = Vector2.zero;
			} else {
				Vector2 direction = new Vector2 (
					player.transform.position.x - transform.position.x,
					player.transform.position.y - transform.position.y
				);
				direction.Normalize ();

				if (behaviour == Behaviour.Flee) {
					direction = -direction;
				}

				rigidBody2D.velocity = Time.deltaTime * direction * movementSpeed;
			}
        }
	}
	void handlePowerOn() { Debug.Log ("Powering on ghost.");
		behaviour = Behaviour.Flee;
	}
	void handlePowerOff() {
		behaviour = Behaviour.Chase;
	}
}
