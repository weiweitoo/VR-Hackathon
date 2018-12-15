using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameUIEventScript : MonoBehaviour {

	public void Run(){
		SceneManager.LoadScene("outpost with snow");
	}

}
