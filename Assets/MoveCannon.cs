using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveCannon : MonoBehaviour
{
    protected float speed = 0.4f;
    protected Vector2 dest = Vector2.zero;

    void Start()
    {
        dest = transform.position;
    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            dest = (Vector2)transform.position + Vector2.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dest = (Vector2)transform.position - Vector2.right;
        }
        Move();
    }

    public virtual void Move()
    {
        // Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
    }

}
