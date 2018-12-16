using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour {

	void Update(){
		if (Input.GetButtonDown("Fire2")){
			SceneManager.LoadScene("outpost with snow");
		}
	}

}
