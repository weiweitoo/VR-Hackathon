using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuHandler : MonoBehaviour {

	public void LoadGameScene(){
		SceneManager.LoadScene("outpost with snow");
	}
}
