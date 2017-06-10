using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSprite : MonoBehaviour {

    public Sprite lightSprite, darkSprite;
    private SpriteRenderer mRend;

	void Start () {
        mRend = GetComponent<SpriteRenderer>();
	}

    private void handlePowerOff() {
        mRend.sprite = darkSprite;
    }

    private void handlePowerOn() {
        mRend.sprite = lightSprite;
    }
}
