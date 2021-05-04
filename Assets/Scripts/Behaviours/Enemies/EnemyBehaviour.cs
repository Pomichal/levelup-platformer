using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : EnemyBaseBehaviour
{
    public Vector2 direction;
    public float speed;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        direction = GetRandomDirection();
        rb.velocity = direction * speed;
    }

    void FixedUpdate()
    {
        if(!CanGoForward(direction))
        {
            direction = GetRandomDirection();
            rb.velocity = direction * speed;
        }

        if(CanSeeThePlayer())
        {
            direction = (App.playersTransform.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
    }

    public Vector2 GetRandomDirection()
    {
        return new Vector2(Random.Range(-1f, 1), Random.Range(-1f, 1)).normalized;
    }
}
