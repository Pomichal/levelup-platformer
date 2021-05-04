using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseBehaviour : MonoBehaviour
{

    public int layerMask = ~(1 << 8);
    public float checkDistance = 1;
    public float cooldown;
    public float offset;
    public Rigidbody2D projectilePrefab;
    public float projectileSpeed;
    public float timer;

    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public bool CanSeeThePlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, App.playersTransform.position - transform.position, Mathf.Infinity, layerMask);
        Debug.DrawRay(transform.position, App.playersTransform.position - transform.position);

        if(hit.collider != null && hit.collider.CompareTag("Player"))
        {
            return true;
        }
        return false;
    }

    public bool CanGoForward(Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, checkDistance, layerMask);
        Debug.DrawRay(transform.position, direction * checkDistance);

        if(hit.collider != null)
        {
            if(!hit.collider.CompareTag("Player"))
            {
                return false;
            }
        }
        return true;
    }

    public void FireProjectile()
    {
            timer = cooldown;
            Rigidbody2D projectile = Instantiate(projectilePrefab, transform.position + GetPlayerDirection() * offset, Quaternion.identity);
            projectile.AddForce(GetPlayerDirection() * projectileSpeed, ForceMode2D.Impulse);
    }

    public Vector3 GetPlayerDirection()
    {
        return (App.playersTransform.position - transform.position).normalized;
    }
}
