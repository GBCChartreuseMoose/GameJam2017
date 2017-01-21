using UnityEngine;
using System.Collections;

public class ProjectileShooter : MonoBehaviour
{

    [SerializeField]
    private GameObject prefab;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = this.transform.position;

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(10, 1);

            Vector2 dir = rb.velocity;//transform.rigidbody2D.velocity;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateRight();
        }
    }

    void RotateLeft()
    {
        transform.Rotate(Vector3.forward * -5);
    }
   
    void RotateRight()
    {
        transform.Rotate(Vector3.forward * 5);
    }
}