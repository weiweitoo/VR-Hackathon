using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameUIEventScript : MonoBehaviour,UIEventInterface {
    public GameObject hide;
    public GameObject show;
    public GameObject player;
    SimpleCharacterController characterController;
    public void Run(){
        //SceneManager.LoadScene("outpost with snow");
        show.SetActive(true);
        hide.SetActive(false);
        player.transform.position = new Vector3(0, 3, 0);
        //characterController.walkSpeed = 14f;
        //characterController.runSpeed = 14f;
        //characterController.flySpeed = 0.5f;
    }

}
