using UnityEngine;
using System.Collections;

public class Debris : MonoBehaviour {
	public float waveSpeed;

	public float debrisSpeed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<Rigidbody2D> ().AddForce(new Vector2 (-debrisSpeed*1*Time.deltaTime, transform.GetComponent<Rigidbody2D>().velocity.y));
	}
}
