using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    public float movementSpeed;
    public float rotationSpeed;

    private Player player;
    private Rigidbody2D mBody;

    void Start () {
        player = FindObjectOfType<Player>();
        mBody = GetComponent<Rigidbody2D>();
        mBody.velocity = Vector3.zero;
	}
	
	void Update () {
        if (player != null) {
            Vector3 playerPos = player.transform.position;
            transform.LookAt(player.transform, Vector3.up);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);

            transform.Translate(transform.forward * movementSpeed * Time.deltaTime);
        }
	}
}
