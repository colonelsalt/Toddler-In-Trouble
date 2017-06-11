using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    private static MusicPlayer instance;
    private AudioSource lightPlayer, darkPlayer;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        darkPlayer = transform.GetChild(0).GetComponent<AudioSource>();
        lightPlayer = transform.GetChild(1).GetComponent<AudioSource>();
        lightPlayer.mute = true;
    }

    public void handlePowerOff() {
        lightPlayer.mute = true;
        darkPlayer.mute = false;
    }

    public void handlePowerOn() {
        darkPlayer.mute = true;
        lightPlayer.mute = false;
    }
}
