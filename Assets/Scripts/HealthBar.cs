using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
	public GameObject heartUI;
	private Stack<GameObject> hearts;
	// Use this for initialization
	void Start () {
		hearts = new Stack<GameObject> ();
	}

	void addHeart() {
		GameObject heart = Instantiate(heartUI);
		heart.transform.position = new Vector2(
			this.transform.position.x + hearts.Count * 1.5f,
			this.transform.position.y + 0.0f
		);
		hearts.Push (heart);
	}

	void removeHeart() {
		GameObject heart = hearts.Pop ();
		HeartUI heartUI = heart.GetComponent<HeartUI> ();
		heartUI.blinkAndDie();
	}

	void livesRemaining(int lives) {
		Debug.Log ("Updating heart display.");
		if (hearts.Count < lives) {
			while (hearts.Count < lives) {
				Debug.Log ("  - Adding heart.");
				addHeart ();
			}
		} else {
			while (hearts.Count > lives) {
				Debug.Log ("  - Removing heart.");
				removeHeart ();
			}
		}
	}
}
