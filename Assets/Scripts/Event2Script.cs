using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Event2Script : MonoBehaviour,Event {

	SocketEventInterface socketEvent;

	void Start () {
		socketEvent = transform.GetComponent<SocketEventInterface>();
	}
	
	public void run(){
		Debug.Log("Event Script 2");
		socketEvent.action();
	}
}
