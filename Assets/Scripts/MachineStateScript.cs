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
		StartCoroutine("CallGetData");
	}

	IEnumerator CallGetData(){
		// Get data
		while(true){
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
			        MachineData machineData = MachineData.CreateFromJSON(response);
			        
			        // Or retrieve results as binary data
			        // byte[] results = www.downloadHandler.data;

			        var wrapper = transform.Find("Wrapper");
			        textComponent = wrapper.Find("Online").Find("Face 1").Find("Text").GetComponent<Text>();
			        var currentMachine = transform.gameObject.name;
			        if(currentMachine=="Machine1"){
			        	// Assign Data
			        	textComponent.text = "Online";
		        		textComponent = wrapper.Find("Temperature").Find("Face 1").Find("Text").GetComponent<Text>();
		        		textComponent.text = "Temperature: " + machineData.temp + "`C";
		        		textComponent = wrapper.Find("Pressure").Find("Face 1").Find("Text").GetComponent<Text>();
		        		textComponent.text = "Pressure: " + machineData.atm + " hPa";
		        		textComponent = wrapper.Find("Humidity").Find("Face 1").Find("Text").GetComponent<Text>();
		        		textComponent.text = "Humidity: " + machineData.humility + " w";
		        		textComponent = wrapper.Find("Distance").Find("Face 1").Find("Text").GetComponent<Text>();
		        		textComponent.text = "Distance: " + machineData.distance + " cm";
		        		textComponent = wrapper.Find("Energy").Find("Face 1").Find("Text").GetComponent<Text>();
		        		textComponent.text = "Produce Enegry: " + machineData.magic + " kW/h";
			        }
			        else if(machineData.ping == true){
			        	textComponent.text = "Online";
			        }
			        else{
			        	textComponent.text = "Device Offline";
			        }
			    }
			}

			yield return new WaitForSeconds(updateRate);
		}
	}
}
