using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartUI : MonoBehaviour {
	private bool active = false;
	private float blinkInterval = 0.05f;

	public void blinkAndDie() {
		Debug.Log ("Calling blinkAndDie");
		StartCoroutine (coroutine());
	}

	private IEnumerator coroutine() {
		SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		if (spriteRenderer != null) {

			for (int i = 0; i < 20; i++) {
				spriteRenderer.enabled = active;
				active = !active;
				yield return new WaitForSeconds(blinkInterval);
			}

			Destroy (gameObject);
			yield return null;
		}
	}
}
