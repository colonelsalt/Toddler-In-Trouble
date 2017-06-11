using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevelOnDeath : MonoBehaviour {

	public void ResetFromStart() {
        FindObjectOfType<RoomManager>().ResetLevel();
    }
}
