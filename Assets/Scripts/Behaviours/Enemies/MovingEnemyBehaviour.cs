using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyBehaviour : EnemyBaseBehaviour
{

    public float directionX;
    public float speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        directionX = 1;

    }

    void FixedUpdate()
    {
        if(!CanGoForward(new Vector2(directionX * speed, 0)))
        {
            directionX *= -1;
        }

        if(CanSeeThePlayer() && timer <= 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            FireProjectile();
        }
        else if(timer <= 0)
        {
            rb.velocity = new Vector2(directionX * speed, rb.velocity.y);
        }
    }
}
