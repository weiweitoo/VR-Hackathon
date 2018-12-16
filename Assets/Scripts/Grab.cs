using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CLOVR_Plugin;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Grab : MonoBehaviour {

    public GameObject cameraPivot;
    bool hold;
    GameObject holdObject;
    SocketEventInterface socketEvent;
    UIEventInterface uiEvent;

    public GameObject hide;
    public GameObject show;

    // Update is called once per frame
    void Update () {
        // if (hold)
        //     Throw();
        // else
        //     Pick();
        TurnOnMachine();

        if (Input.GetButtonDown("Fire2")){
            var hit = CLOVRRaycast.Cast(new Vector2(Screen.width / 2.0f, Screen.height / 2.0f));
            if (hit.collider != null){
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.name == "Machine1"){
                    // TODO play sound
                    // SceneManager.LoadScene("GraphViewer");
                    show.SetActive(true);
                    hide.SetActive(false);
                }
            }
        }

    }

    private void TurnOnMachine(){
        if (Input.GetButtonDown("Fire1")){
            var hit = CLOVRRaycast.Cast(new Vector2(Screen.width / 2.0f, Screen.height / 2.0f));
            if (hit.collider != null){
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag == "EventTrigger"){
                    // TODO play sound
                    socketEvent = hit.collider.gameObject.transform.Find("Machine").Find("Socket").GetComponent<SocketEventInterface>();
                    socketEvent.TurnOn();
                }
                else if (hit.collider.gameObject.tag == "UITrigger"){
                    uiEvent = hit.collider.gameObject.transform.Find("Event").GetComponent<UIEventInterface>();
                    uiEvent.Run();
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
