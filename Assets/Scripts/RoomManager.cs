using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour {

    public string checkPointRoom = "01_StartRoom";
    private Player player;
    private MusicPlayer musicPlayer;

    private void Awake() {
        player = FindObjectOfType<Player>();
        musicPlayer = FindObjectOfType<MusicPlayer>();
        SceneManager.sceneLoaded += EnterRoom;
    }

    private void EnterRoom(Scene previousScene, LoadSceneMode mode) {
        player.SetSpriteVisibility(true);
    }

    public void LoadRoom(string room) {
        SceneManager.LoadSceneAsync(room);
        musicPlayer.handlePowerOff();
    }

    public void ResetLevel() {
        Debug.Log("Level restarted!");

        SceneManager.LoadSceneAsync(checkPointRoom);
    }
}
