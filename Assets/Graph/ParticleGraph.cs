using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PiTime
{
    public int time;
}

public class PiID
{
    public string id;
}

public class PiData
{
    public PiID id;
    public int data;
    public PiTime date;
}

public class ParticleGraph : MonoBehaviour {

    ParticleSystem.Particle[] cloud;
    bool bPointsUpdated = false;

    public string jsonFile;
    public string key;
    [Header("Transform the data")]
    public float dataTransform;
    [Header("Zoom the data")]
    public float zoom;
    [Header("Zoom the time")]
    public float timeZoom;
    [Header("Graph Z-value")]
    public float depth;

    private JObject json;
    private Vector3[] points;
    private Color[] colors;

    private const float ATMPressure = 101325;

    private void Start()
    {
        //Get json code here
        //Change to HTML request mode
        string path = Application.dataPath + jsonFile;
        string jsonString = File.ReadAllText(path);
        json = (JObject)JsonConvert.DeserializeObject(jsonString);
        //Plot points
        JArray dataArray = json[key].Value<JArray>();
        int count = dataArray.Count;
        points = new Vector3[count];
        colors = new Color[count];
        long lastTime = 0;
        float pos = 0;
        //Debug.Log(dataArray[0]["time"]["$date"]);
        for (int i = 0; i < points.Length; i++)
        {
            long currentTime = dataArray[i]["time"]["$date"].Value<long>();
            if (lastTime != 0)
            {
                pos += (float)(currentTime - lastTime) * timeZoom;
            }
            float val = (dataArray[i][key].Value<float>() - dataTransform) * zoom;
            points[i] = new Vector3(pos, val, depth);
            colors[i] = Color.red;
            lastTime = currentTime;
        }
        SetPoints(points, colors);
        GetComponent<ParticleSystem>().SetParticles(cloud, cloud.Length);
    }
    

    /*
    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Vector3 point = points[i];
            point.y = Mathf.Sin(Mathf.PI * (point.x + Time.time));
            points[i] = new Vector3(points[i].x, point.y, points[i].z);
        }
        SetPoints(points, colors);
        if (bPointsUpdated)
        {
            GetComponent<ParticleSystem>().SetParticles(cloud, cloud.Length);
            bPointsUpdated = false;
        }
    }
    */

    public void SetPoints(Vector3[] positions, Color[] colors)
    {
        cloud = new ParticleSystem.Particle[positions.Length];

        for (int ii = 0; ii < positions.Length; ++ii)
        {
            cloud[ii].position = positions[ii];
            cloud[ii].startColor = colors[ii];
            cloud[ii].startSize = 0.1f;
        }

        bPointsUpdated = true;
    }
}
