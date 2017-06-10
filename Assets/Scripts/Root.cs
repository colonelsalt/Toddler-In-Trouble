using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour {
	public static void broadcastAll(string message) {
		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
		foreach (GameObject i in allObjects) {
			i.SendMessage (message, SendMessageOptions.DontRequireReceiver);
		}
	}
	void dispatchPowerOnEvent() {;
		Debug.Log ("POWER ON");
		broadcastAll ("handlePowerOn");
	}
	void dispatchPowerOffEvent() {
		Debug.Log ("POWER OFF");
		broadcastAll("handlePowerOff");
	}
}
