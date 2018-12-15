using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CLOVR_Plugin;

[System.Serializable]
public class Grab : MonoBehaviour {

    public GameObject cameraPivot;
    bool hold;
    GameObject holdObject;
    SocketEventInterface socketEvent;
	
	// Update is called once per frame
	void Update () {
        // if (hold)
        //     Throw();
        // else
        //     Pick();
        TurnOnMachine();
        TurnOffMachine();
        GetDataMachine();
    }

    private void TurnOnMachine(){
        if (Input.GetButtonDown("Fire1")){
            var hit = CLOVRRaycast.Cast(new Vector2(Screen.width / 2.0f, Screen.height / 2.0f));
            if (hit.collider != null){
                if (hit.collider.gameObject.tag == "EventTrigger"){
                    // TODO play sound
                    socketEvent = hit.collider.gameObject.transform.Find("Machine").Find("Socket").GetComponent<SocketEventInterface>();
                    socketEvent.TurnOn();
                }
            }
        }
    }

    private void TurnOffMachine(){
        if (Input.GetButtonDown("Fire2")){
            var hit = CLOVRRaycast.Cast(new Vector2(Screen.width / 2.0f, Screen.height / 2.0f));
            if (hit.collider != null){
                if (hit.collider.gameObject.tag == "EventTrigger"){
                    // TODO play sound
                    socketEvent = hit.collider.gameObject.transform.Find("Machine").Find("Socket").GetComponent<SocketEventInterface>();
                    socketEvent.TurnOff();
                }
            }
        }
    }

    private void GetDataMachine(){
        if (Input.GetButtonDown("Fire3")){
            var hit = CLOVRRaycast.Cast(new Vector2(Screen.width / 2.0f, Screen.height / 2.0f));
            if (hit.collider != null) {
                if (hit.collider.gameObject.tag == "EventTrigger"){
                    // TODO play sound
                    socketEvent = hit.collider.gameObject.transform.Find("Machine").Find("Socket").GetComponent<SocketEventInterface>();
                    socketEvent.GetData();
                }
            }
        }
    }

    private void Pick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var hit = CLOVRRaycast.Cast(new Vector2(Screen.width / 2.0f, Screen.height / 2.0f));
            if (hit.collider != null)
            {
                //Debug.Log(hit.collider.gameObject.name);
                if (CanGrab(hit.collider.gameObject))
                {
                    if (Vector3.Distance(hit.collider.transform.position, cameraPivot.transform.position) < 4f)
                    {
                        hold = true;
                        holdObject = hit.transform.gameObject;
                        holdObject.GetComponent<Rigidbody>().isKinematic = true;
                        holdObject.transform.SetParent(cameraPivot.transform);
                    }
                }
            }
        }
    }

    bool CanGrab(GameObject obj)
    {
        return obj.GetComponent<Rigidbody>() != null;
    }

    void Throw()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            hold = !hold;
            holdObject.GetComponent<Rigidbody>().isKinematic = false;
            holdObject.GetComponent<Rigidbody>().AddForce(cameraPivot.transform.forward * 1000f);
            holdObject.transform.SetParent(null);
            holdObject = null;
        }
    }
}
