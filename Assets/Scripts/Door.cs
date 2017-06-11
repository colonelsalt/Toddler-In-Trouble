using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public string connectsTo;
    public Vector2 entryPosition;

    private RoomManager roomManager;
    private Player player;
    private GameObject transitionPanel;

    private void Start() {
        roomManager = FindObjectOfType<RoomManager>();
        transitionPanel = GameObject.Find("Transition panel");
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        // If player entered door
        Player player = collision.GetComponent<Player>();
        if (player != null) {
            LoadTransition();
            player.transform.position = entryPosition;
            roomManager.LoadRoom(connectsTo);
        }
    }

    private void LoadTransition() {
        if (transitionPanel != null) {
            transitionPanel.GetComponent<Animator>().SetTrigger("transitionOutTrigger");
        }
    }
}
