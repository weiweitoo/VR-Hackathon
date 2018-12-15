using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUIEventScript : MonoBehaviour,UIEventInterface {

	public GameObject input;

	public void Run(){
		Text textComponent = input.GetComponent<Text>();
		textComponent.text += "*";
		// Debug.Log(123);
	}

}
