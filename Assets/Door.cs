using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public string connectsTo;
    public Vector2 entryPosition;

    private RoomManager roomManager;
    private Player player;

    private void Start() {
        roomManager = FindObjectOfType<RoomManager>();
        player = FindObjectOfType<Player>();
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        // If player entered door
        if (collision.GetComponent<Player>() != null) {
            roomManager.LoadRoom(connectsTo);
            player.transform.position = entryPosition;
        }
    }
}
