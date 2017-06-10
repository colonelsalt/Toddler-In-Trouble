using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 3f;
    private static Player instance;
    private ArrayList inventory;
    private Animator anim;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        inventory = new ArrayList();
        anim = GetComponent<Animator>();
    }

    private void Update () {

        float newX = Input.GetAxis("Horizontal");
        float newY = Input.GetAxis("Vertical");

        if (newX > 0) {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            anim.SetTrigger("horizontalWalkTrigger");
        } else if (newX < 0) {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            anim.SetTrigger("horizontalWalkTrigger");
        } else if (newY < 0) {
            anim.SetTrigger("frontWalkTrigger");
        } else if (newY > 0) {
            anim.SetTrigger("backWalkTrigger");
        } else {
            anim.SetTrigger("standTrigger");
        }


        Vector2 desiredVelocity = new Vector2 (newX, newY);

		desiredVelocity *= speed;

		Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D> ();
		rigidBody2D.velocity = desiredVelocity;
	}

    public void PickupItem(Item item) {
        if (item == Item.Gun && !inventory.Contains(item)) {
            inventory.Add(item);
        }
    }
}