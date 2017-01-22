using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour {
	Slider slider;
	public bool launched;
    bool updown; //false = up, true = down
    public float shotpower;
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
       // slider.value = 0;
        updown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!launched)
        {
            if (updown == false)
                slider.value += Time.deltaTime * 2.1f;
            else
                slider.value -= Time.deltaTime * 2.1f;

            if (slider.value <= 0)
                updown = false;
            if (slider.value >= 1)
                updown = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                launched = true;
                shotpower = slider.value;
            }         
        }
	}
}
