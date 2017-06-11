using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAnimations : MonoBehaviour {

    private Animator anim;
    private Rigidbody2D mBody;
    private bool lightIsOn;

	void Start () {
        anim = GetComponent<Animator>();
        mBody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if (!lightIsOn) {
            float velX = mBody.velocity.x;
            float velY = mBody.velocity.y;

            bool xIsMax = (Mathf.Abs(velX) > Mathf.Abs(velY));

            if (velX > 0 && xIsMax) {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                anim.SetTrigger("horizontalWalkingTrigger");
            } else if (velX < 0 && xIsMax) {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                anim.SetTrigger("horizontalWalkingTrigger");
            } else if (velY < 0) {
                anim.SetTrigger("frontWalkingTrigger");
            } else if (velY > 0) {
                anim.SetTrigger("backWalkingTrigger");
            } else {
                anim.SetTrigger("standingTrigger");
            }
        }
    }

    private void handlePowerOn() {
        lightIsOn = true;
        anim.SetTrigger("powerOnTrigger");
    }

    private void handlePowerOff() {
        lightIsOn = false;
    }
}
