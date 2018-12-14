using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCenterScript : MonoBehaviour {

	public GameObject centerPoint;
	
	void FixedUpdate () {
		transform.LookAt(centerPoint.transform);
	}
}
