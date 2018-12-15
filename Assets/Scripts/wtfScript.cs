using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wtfScript : MonoBehaviour {
	public GameObject obj;
	public bool wtf = false;

	void Start () {
		obj.SetActive(wtf);
	}

	void Update(){
		if(Input.GetButtonDown("CancelVideo")){
			wtf = !wtf;
			obj.SetActive(wtf);
		}
	}
}
