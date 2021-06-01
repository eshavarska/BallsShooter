using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private static int eatenBalls = 0;
    public static int EatenBalls
    {
        get { return eatenBalls; }
        set { eatenBalls = value; }

    }

    protected float speed = 0.05f;
    protected Vector2 dest;

    // Start is called before the first frame update
    void Start()
    {
       dest = new Vector2(8, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move towards one end
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
    }


    //Function used to eat balls back
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);
            eatenBalls += 1;
        }
        if(other.gameObject.tag == "SideBorder")
        {
            dest = -dest;
        }
    }

}
