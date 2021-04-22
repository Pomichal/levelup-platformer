using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed;
    public float maxSpeed;
    public float jumpSpeed;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(hor * speed, rb.velocity.y);
        //rb.AddForce(new Vector2(hor * speed, 0));
        //if(Mathf.Abs(rb.velocity.x) > maxSpeed)
        //{
            //rb.velocity = new Vector2((rb.velocity.x / Mathf.Abs(rb.velocity.x)) * maxSpeed, rb.velocity.y);
        //}

        if(Input.GetButtonDown("Jump"))
        {
            //rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);

            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
}
