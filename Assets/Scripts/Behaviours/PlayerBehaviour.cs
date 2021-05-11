using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed;
    public float maxSpeed;
    public float jumpSpeed;
    public int coinsCollected;

    public Animator animator;

    public UnityEvent onCoinsChanged = new UnityEvent();

    public MovingPlatformBehaviour platform;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        App.playersTransform = transform;
        App.player = this;
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

        if(Input.GetKeyDown(KeyCode.E) && platform != null)
        {
            platform.Activate();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Coin"))
        {
            coinsCollected++;
            onCoinsChanged.Invoke();
            other.gameObject.SetActive(false);
        }
    }

    public void SetPlatform(MovingPlatformBehaviour p)
    {
        platform = p;
    }

    public void RemovePlatform()
    {
        platform = null;
    }
}
