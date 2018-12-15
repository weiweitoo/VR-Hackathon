using UnityEngine;

[System.Serializable]
public class MachineData
{
	public bool ping;
    public float temp;
    public float atm;
    public float humility;
    public float distance;
    public float magic;
    public string ip;

    public static MachineData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<MachineData>(jsonString);
    }

    // Given JSON input:
    // {"name":"Dr Charles","lives":3,"health":0.8}
    // this example will return a PlayerInfo object with
    // name == "Dr Charles", lives == 3, and health == 0.8f.
}