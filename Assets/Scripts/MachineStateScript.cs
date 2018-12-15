using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineStateScript : MonoBehaviour {

	public bool online;
	public float temperature;
	public float humidity;
	public float pressure;

	public int updateRate = 3;

	SocketEventInterface socketComponent;
	Text textComponent;

	void Start () {
		socketComponent = transform.Find("Machine").Find("Socket").GetComponent<SocketEventInterface>();
	}
	
	void Update () {
		StartCoroutine("CallGetData");
	}

	IEnumerator CallGetData(){
		// socketComponent.GetData();
		// Debug.Log("Request Latest Data");
		// Assign Data
		textComponent = transform.Find("Wrapper").Find("Online").Find("Face 1").Find("Text").GetComponent<Text>();
		textComponent.text = "Online!";
		if("Online" == "Online"){
			textComponent = transform.Find("Wrapper").Find("Temperature").Find("Face 1").Find("Text").GetComponent<Text>();
			textComponent.text = "Temperature: " + 30;
			textComponent = transform.Find("Wrapper").Find("Pressure").Find("Face 1").Find("Text").GetComponent<Text>();
			textComponent.text = "Pressure: " + 40;
			textComponent = transform.Find("Wrapper").Find("Humidity").Find("Face 1").Find("Text").GetComponent<Text>();
			textComponent.text = "Humidity: " + 30;
		}

		yield return new WaitForSeconds(updateRate);
	}
}
