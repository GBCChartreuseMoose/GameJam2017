using UnityEngine;
using System.Collections;

public class WaveScroll : MonoBehaviour {


	[SerializeField] private GameObject waterPlane;
	GameObject w1;
	GameObject w2;
	GameObject w3;
	Transform water1;
	Transform water2;
	Transform water3;

	[Range (0.1f,20.0f)] public float scrollSpeed = 5.0f;
	[Range(0.1f, 50.0f)] public float resetDist = 12;

	private float dist;
	private float leftBorder;

	// Use this for initialization
	void Start () {

		Vector3 newDist = new Vector3 (this.transform.position.x - 10.27f, this.transform.position.y - 4.77f, -0.2f); 
		w1 = Instantiate (waterPlane, newDist, Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;
		w2 = Instantiate (waterPlane, newDist, Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;
		w3 = Instantiate (waterPlane, newDist, Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;

		w1.transform.parent = this.transform;
		w2.transform.parent = this.transform;
		w3.transform.parent = this.transform;

		water1 = w1.transform;
		water2 = w2.transform;
		water3 = w3.transform;

		dist = Mathf.Abs (12.24f - 2.23652f) - 0.009f;
		water2.position = new Vector3 (water1.position.x+dist, water2.position.y, water2.position.z);
		water3.position = new Vector3 (water2.position.x+dist, water3.position.y, water3.position.z);
		leftBorder = GameObject.Find ("Main Camera").transform.FindChild ("leftBorder").transform.position.x - resetDist;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		water1.Translate(new Vector3(-scrollSpeed*Time.deltaTime, 0, 0));
		water2.Translate(new Vector3(-scrollSpeed*Time.deltaTime, 0, 0));
		water3.Translate(new Vector3(-scrollSpeed*Time.deltaTime, 0, 0));
		if (water1.position.x <= leftBorder)
			water1.position = new Vector3 (water3.position.x+dist, water1.position.y, water1.position.z);
		if(water2.position.x <= leftBorder)
			water2.position = new Vector3 (water1.position.x+dist, water2.position.y, water2.position.z);
		if(water3.position.x <= leftBorder)
			water3.position = new Vector3 (water2.position.x+dist, water3.position.y, water3.position.z);
	}
}
