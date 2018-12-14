using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCenterScript : MonoBehaviour {

	public GameObject centerPoint;
	public bool alwaysEnable;
	
	void FixedUpdate () {
		if(alwaysEnable){
			LookAt();
		}
	}

	public void LookAt(){
		transform.LookAt(centerPoint.transform);
	}

}
