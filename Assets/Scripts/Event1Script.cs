using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Event1Script : MonoBehaviour,Event {

	SocketEventInterface socketEvent;

	void Start () {
		socketEvent = transform.Find("Machine").Find("Socket").transform.GetComponent<SocketEventInterface>();
	}

	public void run(){
		socketEvent.action();
	}
}
