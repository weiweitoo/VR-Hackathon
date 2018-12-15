﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class Machine2SocketScript : MonoBehaviour,SocketEventInterface {
	private SocketIOComponent socket;
	public bool enable = false;

	public void Start() 
	{
		if(enable){
			GameObject go = GameObject.Find("SocketIO");
			socket = go.GetComponent<SocketIOComponent>();

			socket.On("open", TestOpen);
			socket.On("error", TestError);
			socket.On("close", TestClose);
			socket.On("getdata2",TestData);
		}
	}

	public void TurnOn(){		
		Debug.Log("TurnOn2");
		socket.Emit("turnon2");
	}

	public void TurnOff(){		
		Debug.Log("TurnOff2");
		socket.Emit("turnoff2");
	}

	public void GetData(){		
		Debug.Log("GetData2");
		socket.Emit("getdata2");
	}

	public void TestData(SocketIOEvent e){
		Debug.Log("[SocketIO] Data received: " + e.name + " " + e.data);
	}

	public void TestOpen(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
	}
	
	public void TestError(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
	}
	
	public void TestClose(SocketIOEvent e)
	{	
		Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
	}
}

