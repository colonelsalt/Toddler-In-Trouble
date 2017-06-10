using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
	private SpriteRenderer lightSpriteRenderer;
	private SpriteRenderer darkSpriteRenderer;

	void initialiseSpriteRenderers() {
		GameObject lightObject = transform.GetChild (1).gameObject;
		GameObject darkObject = transform.GetChild (0).gameObject;
		lightSpriteRenderer = lightObject.GetComponent<SpriteRenderer> ();
		darkSpriteRenderer = darkObject.GetComponent<SpriteRenderer> ();
	}

	void Start () {
		initialiseSpriteRenderers ();
		power(false);
	}
	void power(bool power) {
		lightSpriteRenderer.enabled = power;
		darkSpriteRenderer.enabled = !power;
	}
	void handlePowerOn() {
		power (true);
	}
	void handlePowerOff() {
		power (false);
	}
}
