using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{


    private static int availableBalls = 10;
    public static int AvailableBalls
    {
        get { return availableBalls; }
        set { availableBalls = value; }

    }

    public GameObject ball;
    public Transform spawnPosition;
    public GameObject crosshairs;
    private Vector3 target;
    public float ballSpeed = 50.0f;


    // Update is called once per frame
    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - this.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            Shoot(direction, rotationZ);

        }
    }


    void Shoot(Vector2 direction, float rotationZ)
    {
        if(availableBalls > 0)
        {
            GameObject b = Instantiate(ball) as GameObject;
            b.transform.position = spawnPosition.transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = direction * ballSpeed;
            availableBalls -= 1;
        }
    }

    //Function used to collect balls back
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);
            availableBalls += 1;
        }
    }
}
