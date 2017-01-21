using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour {
	Slider slider;
	bool launched;
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!launched)
			slider.value += Time.deltaTime * 2.1f;
		if (slider.value >= 1) 
			slider.value = 0;
		if (Input.GetKeyDown (KeyCode.Space))
			launched = true;

	}
}
