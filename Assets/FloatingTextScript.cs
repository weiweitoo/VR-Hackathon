using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextScript : MonoBehaviour {

	public string text;

	void Start () {
		Transform x = transform.Find("Face 1").Find("Text");
		Debug.Log(x);
		Text textComponent = x.GetComponent<Text>();
		textComponent.text = text;
	}
	
	void Update () {
		
	}
}
