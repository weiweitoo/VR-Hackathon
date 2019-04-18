using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class StateData {

    public float altitude;
    public float temperature;
    public float humidity;
    public float sealevel;
    public float pressure;
    public string detection;

    public static StateData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<StateData>(jsonString);
    }
}
