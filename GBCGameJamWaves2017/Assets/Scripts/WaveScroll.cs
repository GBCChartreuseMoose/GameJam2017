using UnityEngine;
using System.Collections;

public class WaveScroll : MonoBehaviour {

	[SerializeField] Transform water1;
	[SerializeField] Transform water2;
	[SerializeField] Transform water3;

	[Range (0.1f,20.0f)] public float scrollSpeed = 5.0f;
	[Range(0.1f, 50.0f)] public float resetDist = 12;

	private float dist;
	private float leftBorder;

	// Use this for initialization
	void Start () {
		dist = Mathf.Abs (water2.position.x - water1.position.x) - 0.003f;
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
