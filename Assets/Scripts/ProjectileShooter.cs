using UnityEngine;
using System.Collections;

public class ProjectileShooter : MonoBehaviour
{
    // 85 top max, 275 bottom max
    [SerializeField] private GameObject prefab;
    private GameObject bulletspawn;
    private float anglespeed = 25;

    // Use this for initialization
    void Start()
    {
        bulletspawn = transform.FindChild("BulletSpawn").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("click");

            GameObject projectile = Instantiate(prefab, bulletspawn.transform.position, bulletspawn.transform.rotation) as GameObject;
            projectile.transform.position = bulletspawn.transform.position;

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = 10 * (bulletspawn.transform.position - this.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //if ((this.transform.forward.z <= 84 && this.transform.forward.z >= 0) || (this.transform.forward.z >= 269 && this.transform.forward.z <= 360))
                // if((this.transform.rotation.z <= 84  && this.transform.rotation.z >= 0) || (this.transform.rotation.z >= 269 && this.transform.rotation.z <= 360))
                RotateAngle(anglespeed);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
         // if((this.transform.rotation.z <= 90  && this.transform.rotation.z >= 0) || (this.transform.rotation.z <= 275 && this.transform.rotation.z >= 360))
            RotateAngle(-anglespeed);
        }
    }

    void RotateAngle(float angle)
    {
        transform.Rotate(Vector3.forward * angle);
    }
}