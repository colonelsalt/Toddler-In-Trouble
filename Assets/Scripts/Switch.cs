using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
	private static int numberOfActiveSwitches = 0;

	private void incrementActiveLightSwitches() {
		Debug.Log ("incrementActiveLightSwitches " + numberOfActiveSwitches);
		if (numberOfActiveSwitches++ == 0) {
			Root.broadcastAll ("handlePowerOn");
		}
	}

	private void decrementActiveLightSwitches() {
		Debug.Log ("decrementActiveLightSwitches " + numberOfActiveSwitches);
		if (--numberOfActiveSwitches == 0) {
			Root.broadcastAll ("handlePowerOff");
		}
	}

	public float lightSwitchDuration;
	private float timeRemaining;
	private bool touchingPlayer;
	private bool state;

	void Start () {
		setGraphicState (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (touchingPlayer) {
			press();
		}
		if (timeRemaining > 0) {
			timeRemaining -= Time.deltaTime;
			if (timeRemaining <= 0) {
				setState(false);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		touchingPlayer = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		touchingPlayer = false;
	}

	private void setGraphicState(bool state) {
		GameObject offGraphic = transform.GetChild (1).gameObject;
		GameObject onGraphic = transform.GetChild (0).gameObject;

		SpriteRenderer offGraphicSpriteRenderer = offGraphic.GetComponent<SpriteRenderer> ();
		SpriteRenderer onGraphicSpriteRenderer = onGraphic.GetComponent<SpriteRenderer> ();

		offGraphicSpriteRenderer.enabled = !state;
		onGraphicSpriteRenderer.enabled = state;
	}

	private void setModelState(bool state) {
		if (this.state != state) {
			if (state)
				incrementActiveLightSwitches ();
			else
				decrementActiveLightSwitches ();

			this.state = state;
		}
	}

	private void setState(bool state) {
		setGraphicState (state);
		setModelState (state);
	}

	void press() {
		setState (true);
		timeRemaining = lightSwitchDuration;
	}
}
