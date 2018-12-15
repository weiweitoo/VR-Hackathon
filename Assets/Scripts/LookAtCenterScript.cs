using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCenterScript : MonoBehaviour {

	public GameObject centerPoint;
	public bool alwaysEnable;
	public float rotationSpeed = 20;
	
	void FixedUpdate () {
		if(alwaysEnable){
			LookAt();
		}	
	}

	public void LookAt(){
		// Solve the bug here wtf
		// transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(centerPoint.transform.position), rotationSpeed * Time.deltaTime);
		transform.LookAt(centerPoint.transform);
		// Debug.Log(centerPoint.transform.position);
	}

}
