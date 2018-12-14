using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    bool hold;
    GameObject holdObject;
    Camera cam;
    int x, y;

    // Use this for initialization
    void Start()
    {
        cam = GameObject.Find("Left Camera").GetComponent<Camera>();
        x = Screen.width / 4;
        y = Screen.height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (hold)
            Throw();
        else
            Pick();
    }

    private void Pick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    //Debug.Log(hit.collider.gameObject.name);
                    if(CanGrab(hit.collider.gameObject))
                    {
                        if (Vector3.Distance(hit.collider.transform.position, transform.position) < 4f)
                        {
                            hold = true;
                            holdObject = hit.transform.gameObject;
                            holdObject.GetComponent<Rigidbody>().isKinematic = true;
                            holdObject.transform.SetParent(transform);
                        }
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
            holdObject.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
            holdObject.transform.SetParent(null);
            holdObject = null;
        }
    }
}
