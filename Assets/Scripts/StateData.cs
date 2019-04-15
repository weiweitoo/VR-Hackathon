using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class StateData {

    public string detection;
    public float temperature;
    public float humidity;

    public static StateData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<StateData>(jsonString);
    }
}
