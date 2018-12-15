using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MachineStateScript : MonoBehaviour {

	public bool online;
	public float temperature;
	public float humidity;
	public float pressure;

	public int updateRate = 3;
	public string url = "http://172.30.93.138:4567/getdata";

	SocketEventInterface socketComponent;
	Text textComponent;

	void Start () {
		socketComponent = transform.Find("Machine").Find("Socket").GetComponent<SocketEventInterface>();
	}
	
	void Update () {
		StartCoroutine("CallGetData");
	}

	IEnumerator CallGetData(){
		// Get data
		using (UnityWebRequest www = UnityWebRequest.Get(url))
		{
		    yield return www.Send();

		    if (www.isNetworkError || www.isHttpError)
		    {
		        Debug.Log(www.error);
		    }
		    else
		    {
		        // Show results as text
		        var response = www.downloadHandler.text;
		        Debug.Log(response);
		        MachineData machineData = MachineData.CreateFromJSON(response);
		        Debug.Log(machineData.temp);
		        
		        // Or retrieve results as binary data
		        // byte[] results = www.downloadHandler.data;

		        var wrapper = transform.Find("Wrapper");
		        textComponent = wrapper.Find("Online").Find("Face 1").Find("Text").GetComponent<Text>();
		        if(machineData.online == true){
		        	// Assign Data
		        	textComponent.text = "Online";
	        		textComponent = wrapper.Find("Temperature").Find("Face 1").Find("Text").GetComponent<Text>();
	        		textComponent.text = "Temperature: " + machineData.temp + "`C";
	        		textComponent = wrapper.Find("Pressure").Find("Face 1").Find("Text").GetComponent<Text>();
	        		textComponent.text = "Pressure: " + machineData.atm + " hPa";
	        		textComponent = wrapper.Find("Humidity").Find("Face 1").Find("Text").GetComponent<Text>();
	        		textComponent.text = "Humidity: " + machineData.humility + " w";
	        		textComponent = wrapper.Find("Enegry").Find("Face 1").Find("Text").GetComponent<Text>();
	        		textComponent.text = "Produce Enegry: " + machineData.magic + " kW/h";
		        }
		        else{
		        	textComponent.text = "Offline";
		        }
		        
		    }
		}

		yield return new WaitForSeconds(updateRate);
	}
}
