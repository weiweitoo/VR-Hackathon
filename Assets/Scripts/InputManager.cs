﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour {

    public GameObject hide;
    public GameObject show;
    public GameObject player;

    void Update(){
		if (Input.GetButtonDown("Fire2")){
            //SceneManager.LoadScene("outpost with snow");
            show.SetActive(true);   
            hide.SetActive(false);
            player.transform.position = new Vector3(0, 3, 0);
        }
	}

}
