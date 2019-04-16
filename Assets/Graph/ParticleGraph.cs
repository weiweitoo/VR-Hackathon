using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGraph : MonoBehaviour {

    ParticleSystem.Particle[] cloud;
    bool bPointsUpdated = false;

    [Range(10, 100)]
    public int resolution = 10;

    Vector3[] points;
    Color[] colors;

    void Awake()
    {
        float step = 2f / resolution;
        float xx;
        points = new Vector3[resolution];
        colors = new Color[resolution];
        for (int i = 0; i < points.Length; i++)
        {
            xx= (i + 0.5f) * step - 1f;
            points[i] = Vector3.right * xx;
            colors[i] = Color.red;
        }
    }

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
