using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public RoomManager roomManager;
    public string connectsTo;

    private void Start() {
        roomManager = FindObjectOfType<RoomManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        // If player entered door
        if (collision.GetComponent<Player>() != null) {
            roomManager.LoadRoom(connectsTo);
        }
    }
}
