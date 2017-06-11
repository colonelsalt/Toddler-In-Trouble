using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour {

    public string checkPointRoom = "01_StartRoom";

	public void LoadRoom(string room) {
        SceneManager.LoadSceneAsync(room);
    }

    public void ResetLevel() {
        Debug.Log("Level restarted!");

        SceneManager.LoadSceneAsync(checkPointRoom);
    }
}
