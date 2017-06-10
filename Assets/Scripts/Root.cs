using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour {
	void dispatchPowerOnEvent() {
		BroadcastMessage("handlePowerOn");
		Debug.Log ("POWER ON");
	}
	void dispatchPowerOffEvent() {
		BroadcastMessage("handlePowerOff");
		Debug.Log ("POWER OFF");
	}
}
