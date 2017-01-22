using UnityEngine;
using System.Collections;

public class ProjectileShooter : MonoBehaviour
{
    // 85 top max, 275 bottom max
    [SerializeField] private GameObject prefab;
    private GameObject bulletspawn;
    private PowerSlider sliderObj;
    public PowerSlider ps;
    private float anglespeed = 25;
    public float shotpower;
    public bool lowrange;
    public bool highrange;

    // Use this for initialization
    void Start()
    {
        bulletspawn = transform.FindChild("BulletSpawn").gameObject;
        sliderObj = GameObject.Find("Slider").GetComponent<PowerSlider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && sliderObj.launched)
        {
            Debug.Log("click");

            GameObject projectile = Instantiate(prefab, bulletspawn.transform.position, bulletspawn.transform.rotation) as GameObject;
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            shotpower = sliderObj.shotpower;
            rb.velocity = new Vector2(shotpower * 10, 0);

            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //  if ((this.transform.rotation.z <= 84 && this.transform.rotation.z >= 0) || (this.transform.rotation.z >= 269 && this.transform.rotation.z <= 360))
            

                // if((this.transform.rotation.z <= 84  && this.transform.rotation.z >= 0) || (this.transform.rotation.z >= 269 && this.transform.rotation.z <= 360))
                RotateAngle(anglespeed);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
         // if((this.transform.rotation.z <= 90  && this.transform.rotation.z >= 0) || (this.transform.rotation.z <= 275 && this.transform.rotation.z >= 360))
            RotateAngle(-anglespeed);
        }

        if (transform.rotation.z <= 84 && transform.rotation.z >= 0)
        {
            lowrange = true;
        }
        else
            lowrange = false;

        if (this.transform.rotation.z >= 269 && this.transform.rotation.z <= 360)
        {
            highrange = true;
        }
        else highrange = false;
    }

    void RotateAngle(float angle)
    {
        transform.Rotate(Vector3.forward * angle);
    }
}