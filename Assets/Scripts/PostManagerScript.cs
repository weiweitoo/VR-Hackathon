using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostManagerScript : MonoBehaviour {

	public GameObject postPrefab;
	public List<string> post = new List<string>();

	void Start () {
		FloatingTextScript floatingTextScript;
		for (int y = 0; y < 1; y++) 
		{
            GameObject textObj = Instantiate(postPrefab, new Vector3(0, 0, 0), Quaternion.identity);
			floatingTextScript = textObj.GetComponent<FloatingTextScript>();
			floatingTextScript.text = "12dede3";
			Debug.Log(textObj);
        }
	}
	
	void Update () {
		
	}
}
