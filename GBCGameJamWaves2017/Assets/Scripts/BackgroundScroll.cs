using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

	[SerializeField] Transform bg1;
	[SerializeField] Transform bg2;

	[Range (0.1f,20.0f)] public float scrollSpeed = 5.0f;

	private float dist;


	// Use this for initialization
	void Start () {
		dist = Mathf.Abs (bg2.position.x - bg1.position.x) - 0.003f;
		bg2.position = new Vector2 (bg1.position.x+dist, bg2.position.y);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		bg1.Translate(new Vector2(-scrollSpeed*Time.deltaTime, 0));
		bg2.Translate(new Vector2(-scrollSpeed*Time.deltaTime, 0));
		Debug.Log (bg1.position.x);
		if (bg1.position.x <= -21.667f)
			
			bg1.position = new Vector2 (bg2.position.x+dist, bg1.position.y);
		if(bg2.position.x <= -21.667f)
			bg2.position = new Vector2 (bg1.position.x+dist, bg2.position.y);
	}
}
