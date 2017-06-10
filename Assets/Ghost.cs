using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    public float speed;

    private Player player;
    private Rigidbody2D mBody;

    void Start () {
        player = FindObjectOfType<Player>();
        mBody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        Vector3 playerPos = player.transform.position;
        transform.rotation.SetLookRotation(playerPos);
	}
}
