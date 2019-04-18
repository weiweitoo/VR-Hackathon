using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MachineStateScript : MonoBehaviour {

	public int updateRate = 3;
	public GameObject warningText;
	public string url = "http://172.30.93.138:4567/state";

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
				var wrapper = transform.Find("Wrapper");
				textComponent = wrapper.Find("Online").Find("Face 1").Find("Text").GetComponent<Text>();
				var currentMachine = transform.gameObject.name;

			    if (www.isNetworkError || www.isHttpError)
			    {
			        Debug.Log(www.error);
			        textComponent.text = "Device Offline";
			    }
			    else
			    {
			        // Show results as text
			        var response = www.downloadHandler.text;
			        StateData machineData = StateData.CreateFromJSON(response);
			 		// Debug.Log(response);       
			        // Or retrieve results as binary data
			        // byte[] results = www.downloadHandler.data;

			        if(currentMachine=="Machine1"){
			        	// Assign Data
			        	textComponent.text = "Online";
		        		textComponent = wrapper.Find("Temperature").Find("Face 1").Find("Text").GetComponent<Text>();
		        		textComponent.text = "Temperature: " + machineData.temperature + "`C";
		        		textComponent = wrapper.Find("Humidity").Find("Face 1").Find("Text").GetComponent<Text>();
		        		textComponent.text = "Humidity: " + machineData.humidity + " w";
		        		textComponent = wrapper.Find("Altitude").Find("Face 1").Find("Text").GetComponent<Text>();
		        		textComponent.text = "Altitude: " + machineData.altitude + " m";
		        		textComponent = wrapper.Find("Pressure").Find("Face 1").Find("Text").GetComponent<Text>();
		        		textComponent.text = "Pressure: " + machineData.pressure + " Pa";
		        		textComponent = wrapper.Find("SeaLevelPressure").Find("Face 1").Find("Text").GetComponent<Text>();
		        		textComponent.text = "Sea Level Preasure: " + machineData.sealevel + " Pa";
			        }

					 if(machineData.detection == "true"){
			        	warningText.SetActive(true);
			        }else{
						warningText.SetActive(false);
					}
			    }
			}

			yield return new WaitForSeconds(updateRate);
		}
	}
}
