using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TestStreaming : MonoBehaviour
{

    CustomWebRequest camImage;
    UnityWebRequest webRequest;
    byte[] bytes = new byte[90000];

    void Start(){
        string url = "localhost:5000/video_feed";
        webRequest = new UnityWebRequest(url);
        webRequest.downloadHandler = new CustomWebRequest(bytes);
        webRequest.Send();
    }
}