using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using Resource;

public class LiveImage : MonoBehaviour {

	public string url = "http://192.168.1.104:8000/images/frame.jpg";
	public Image img;
	private Sprite lastImage;
	// Use this for initialization
	void Start () {
		img = GetComponent<Image>();
		StartCoroutine(UpdateImage());
		StartCoroutine(Clear());
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator UpdateImage(){
		// using (WWW www = new WWW(url)){
		// 	yield return www;
		// 	Renderer renderer = GetComponent<Renderer>();
		// 	renderer.material.mainTexture = www.texture;
		// }
		while (true){
			WWW www = new WWW(url);
			yield return www;
			if(lastImage!= null){
				Destroy(lastImage.texture);
				Destroy(lastImage);
			}
			lastImage = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
			img.sprite = lastImage;
			img.preserveAspect = true;
			yield return new WaitForSecondsRealtime(1);
		}
	}
	IEnumerator Clear(){
		while(true){
			// Resource.UnloadUnusedAssets();
			yield return new WaitForSecondsRealtime(60);
		}
	}
}
