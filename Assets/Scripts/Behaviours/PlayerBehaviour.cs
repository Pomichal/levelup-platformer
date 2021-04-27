using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed;
    public float maxSpeed;
    public float jumpSpeed;

    public Animator animator;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");

        if(rb.velocity.x != 0)
        {
            animator.SetBool("Moving", true);

            if(rb.velocity.x > 0)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
            }
            else
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
            }
        }
        else
        {
            animator.SetBool("Moving", false);
        }
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
