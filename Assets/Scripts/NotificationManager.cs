using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour {

	public GameObject notification;

	public void ShowNotication(){
		notification.SetActive(true);
	}
}
