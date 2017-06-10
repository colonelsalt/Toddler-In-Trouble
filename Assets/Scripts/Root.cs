using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour {
	void dispatchPowerOnEvent() {;
		Debug.Log ("POWER ON");
		BroadcastMessage ("handlePowerOn");
	}
	void dispatchPowerOffEvent() {
		Debug.Log ("POWER OFF");
		BroadcastMessage("handlePowerOff");
	}
}
