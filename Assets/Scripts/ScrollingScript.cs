using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour {

	public GameObject centerPoint;
	public float scrollingSpeed = 20.0f;

	private LookAtCenterScript lookAtCenterScript;

	void Start(){
		lookAtCenterScript = transform.GetComponent<LookAtCenterScript>();
		lookAtCenterScript.LookAt();
	}

	void Update() {
		if (Input.GetButton("Fire1")){
			transform.RotateAround(centerPoint.transform.position, transform.up, scrollingSpeed*Time.deltaTime);
			lookAtCenterScript.LookAt();
		}
	}
}
