using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CLOVR_Plugin;

[System.Serializable]
public class ShowStateScript : MonoBehaviour {

    public GameObject cameraPivot;
    bool hold;
    GameObject holdObject;

    // private List<GameObject> = new ArrayList();

    void Start () {
		
	}
	
	void Update () {
        CallEvent();
    }

    private void CallEvent(){
        var hit = CLOVRRaycast.Cast(new Vector2(Screen.width / 2.0f, Screen.height / 2.0f));
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "EventTrigger")
            {
                var targetObj = hit.collider.gameObject.transform;
                var lighting = targetObj.Find("Selected").transform.GetComponent<Light>();
                lighting.enabled = true;
                // eventObj.run();
            }
        }
    }
}
