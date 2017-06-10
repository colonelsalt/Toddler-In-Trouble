using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum InputMode{
	Mouse,
	Joystick
}

public class Weapon : MonoBehaviour {
	public GameObject projectile;
	public float projectileSpeed;
	public float projectileInterval;

	private float projectileCooldown;
	private InputMode inputMode;

	void Start () {
		inputMode = Input.GetJoystickNames().Length > 0
			? InputMode.Joystick
			: InputMode.Mouse;
		projectileCooldown = projectileInterval;
	}

	void Update() {
		CheckForMouseActivity();
		CheckForJoystickActivity();
		switch(inputMode) {
			case InputMode.Mouse: HandleMouseInput(); break;
			case InputMode.Joystick: HandleJoystickInput(); break;
		}
		CheckForFireBullet();
	}

	void HandleMouseInput() {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
	}

	void HandleJoystickInput() {
		Vector3 direction = new Vector2 (
			Input.GetAxis("VerticalR"),
			Input.GetAxis("HorizontalR")
		);

		if (direction.magnitude > 0) {
			direction.Normalize();

			float angle = -Mathf.Atan2(direction.y, -direction.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

			inputMode = InputMode.Joystick;
		}
	}

	void CheckForMouseActivity() {
		float x = Input.GetAxis ("Mouse X");
		float y = Input.GetAxis ("Mouse Y");
		if (x != 0 || y != 0) {
			inputMode = InputMode.Mouse;
		}
	}

	void CheckForJoystickActivity() {
		float x = Input.GetAxis ("VerticalR");
		float y = Input.GetAxis ("HorizontalR");
		if (x != 0 || y != 0) {
			inputMode = InputMode.Joystick;
		}
	}

	void CheckForFireBullet() {
		if (projectileCooldown <= 0 && Input.GetAxisRaw ("Fire1") > 0) {
			FireBullet ();
		}

		projectileCooldown -= Time.deltaTime;
	}

	void FireBullet() {
		if (projectile) {
			GameObject bullet = (GameObject)Instantiate (projectile);

			Vector2 bulletDirection = new Vector2 (
				-Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad),
				+Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad)
			);

			bullet.transform.position = new Vector3(
				transform.position.x + bulletDirection.x,
				transform.position.y + bulletDirection.y,
				0.0f
			);

			bullet.transform.rotation = transform.rotation;

			// Uncomment for inherit parent velocity:
			// Rigidbody2D parentBody2D = GetComponentInParent<Rigidbody2D> ();
			Rigidbody2D rigidBody2D = bullet.GetComponent<Rigidbody2D> ();

			rigidBody2D.velocity = /*parentBody2D.velocity + */ bulletDirection * projectileSpeed;
			projectileCooldown = projectileInterval;
		}
	}
}
