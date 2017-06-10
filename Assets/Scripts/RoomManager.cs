using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour {

	public void LoadRoom(string room) {
        SceneManager.LoadSceneAsync(room);
    }
}
