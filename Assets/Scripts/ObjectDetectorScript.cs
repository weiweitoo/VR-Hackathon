using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ObjectDetectorScript : MonoBehaviour {

	public string url = "895bcdc9.ngrok.io/state";
	public GameObject warningText;
	public float updateRate = 3;

	void Start () {
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
			        StateData data = StateData.CreateFromJSON(response);
			 		Debug.Log(response);
					
			        if(data.detection == "false"){
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
