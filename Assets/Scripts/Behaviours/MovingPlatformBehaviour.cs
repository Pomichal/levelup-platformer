using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehaviour : MonoBehaviour
{

    public Transform startPosition;
    public Transform endPosition;
    public float speed;

    public bool isActivated = false;
    private bool towardsStart = true;
    private bool isMoving = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(towardsStart && isMoving && isActivated)
        {
            transform.position += (startPosition.position - transform.position).normalized * speed;

            if((startPosition.position - transform.position).magnitude < 0.1f)
            {
                towardsStart = false;
            }
        }
        else if(isMoving && isActivated)
        {
            transform.position += (endPosition.position - transform.position).normalized * speed;
            if((endPosition.position - transform.position).magnitude < 0.1f)
            {
                towardsStart = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
            isMoving = true;
            other.gameObject.GetComponent<PlayerBehaviour>().SetPlatform(this);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
            other.gameObject.GetComponent<PlayerBehaviour>().RemovePlatform();
            isMoving = false;
        }
    }

    public void Activate()
    {
        isActivated = true;
    }
}
