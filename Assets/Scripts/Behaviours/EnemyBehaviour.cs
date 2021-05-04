using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public float checkDistance;

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
        int layerMask = 1 << 8;
        // 10000000x2
        layerMask = ~layerMask;
        // 01111111x2

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, checkDistance, layerMask);
        Debug.DrawRay(transform.position, direction * checkDistance);

        if(hit.collider != null)
        {
            if(!hit.collider.CompareTag("Player"))
            {
                direction = GetRandomDirection();
                rb.velocity = direction * speed;
            }
            Debug.Log(hit.collider.name);
        }

        hit = Physics2D.Raycast(transform.position, App.playersTransform.position - transform.position, Mathf.Infinity, layerMask);
        Debug.DrawRay(transform.position, App.playersTransform.position - transform.position);

        if(hit.collider != null && hit.collider.CompareTag("Player"))
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
