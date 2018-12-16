using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {
	public GameObject prefab;
	public float maxSize = 3.0f;
	public float minSize = 1.0f;
	public float spreadRange = 80.0f;
	public float spreadCheck = 100.0f;
    public GameObject parent;

	// Use this for initialization
	void Start () {
		List<GameObject> oList = new List<GameObject>();
		List<string> prbList = new List<string>();
    

		prbList.Add("Overheat");				//1
		prbList.Add("Inner Overheat");			//2
		prbList.Add("Outer Overheat");			//3
		prbList.Add("Cracks");					//4
		prbList.Add("Transmission Faults");		//5
		prbList.Add("Power Leak");				//6
		prbList.Add("Segmental Faults");		//7
		prbList.Add("Power Spike");				//8
		prbList.Add("Fan Backstop");			//9
		prbList.Add("Cooling Systen Faults");	//10
		prbList.Add("Pipe Damaged");			//11
		prbList.Add("Power Overload");			//12
		prbList.Add("Turbine Blades Wore");		//13
		prbList.Add("Wire Coat Damaged");		//14
		prbList.Add("Wire Coat Wore");			//15

		foreach(string pbs in prbList) {
			//Randomly select a size - TEMP
			float randomScale = Random.Range(minSize,maxSize);
			bool placed = false;
			//Randomly select a color - TEMP
			Color clr = new Color(Random.Range(0.0f,1.0f), Random.Range(0.0f,1.0f), Random.Range(0.0f,1.0f), 0.5f);

			while(!placed) {
				//Width spread
				float xx = Random.Range(-spreadRange + randomScale * 4.0f, spreadRange - randomScale * 4.0f);
				float zz = Random.Range(-spreadRange + randomScale * 4.0f, spreadRange - randomScale * 4.0f);

				//Height spread
				float yy = Random.Range(-spreadRange/2, spreadRange/2);

				foreach(GameObject obj in oList) {
					float distance = Vector3.Distance(new Vector3(xx,yy,zz), obj.transform.position);
					if (distance < spreadRange + obj.transform.localScale.x * 2.0f) {
						//Debug.Log("Too close!");
						continue;
					}
				}

				//Add Sphere to scenario
				GameObject o = Object.Instantiate(prefab, new Vector3(xx,yy,zz), Quaternion.identity);
                o.transform.parent = parent.transform;
                o.GetComponent<FloatingTextScript>().text = pbs + "\n" + System.Math.Round((randomScale - minSize)/(maxSize - minSize)*100) + "%";
				o.GetComponent<RectTransform>().localScale = new Vector3(randomScale,randomScale,randomScale);
        		o.GetComponent<Renderer>().material.SetColor("_Color", clr);
				oList.Add(o);
				placed = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
