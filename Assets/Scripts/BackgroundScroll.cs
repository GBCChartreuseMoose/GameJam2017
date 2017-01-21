using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

	[SerializeField] Transform bg1;
	[SerializeField] Transform bg2;
	[SerializeField] Transform bg3;

	[Range (0.1f,20.0f)] public float scrollSpeed = 5.0f;
	[Range(0.1f, 50.0f)] public float resetDist = 12;
	private float dist;
	private float leftBorder;


	// Use this for initialization
	void Start () {
		dist = Mathf.Abs (bg2.position.x - bg1.position.x) - 0.003f;
		bg2.position = new Vector2 (bg1.position.x+dist, bg2.position.y);
		bg3.position = new Vector2 (bg2.position.x+dist, bg3.position.y);
		leftBorder = GameObject.Find ("Main Camera").transform.FindChild ("leftBorder").transform.position.x - resetDist;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		bg1.Translate(new Vector2(-scrollSpeed*Time.deltaTime, 0));
		bg2.Translate(new Vector2(-scrollSpeed*Time.deltaTime, 0));
		bg3.Translate(new Vector2(-scrollSpeed*Time.deltaTime, 0));
		if (bg1.position.x <= leftBorder)
			
			bg1.position = new Vector2 (bg3.position.x+dist, bg1.position.y);
		if(bg2.position.x <= leftBorder)
			bg2.position = new Vector2 (bg1.position.x+dist, bg2.position.y);
		if(bg3.position.x <= leftBorder)
			bg3.position = new Vector2 (bg2.position.x+dist, bg3.position.y);
	}
}
