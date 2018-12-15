using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour {

	public GameObject destination;
	public GameObject player;
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Teleport")){
			player.transform.position = destination.transform.position;
			player.transform.LookAt(destination.transform);
			Debug.Log("Teleproed");
			// gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}
}
