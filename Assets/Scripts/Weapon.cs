using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public GameObject projectile;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw ("Fire1") > 0) {
			GameObject bullet = (GameObject)Instantiate(projectile);
			bullet.transform.position = transform.position;
			Debug.Log ("Fire!");
		}
	}
}
