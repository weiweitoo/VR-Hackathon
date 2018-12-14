using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPlayerScript : MonoBehaviour {

	public GameObject centerPoint;
	public float rotationSpeed = 20.0f;

	void FixedUpdate() {
		transform.RotateAround(centerPoint.transform.position, transform.up, rotationSpeed*Time.deltaTime);
	}
}
