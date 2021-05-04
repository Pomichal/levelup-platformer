using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemyBehaviour : EnemyBaseBehaviour
{

    public Rigidbody2D projectilePrefab;
    public float cooldown;
    public float offset;
    public float projectileSpeed;

    private float timer;

    void Update()
    {
        if(timer > 0)
        {
            timer-= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if(CanSeeThePlayer() && timer <=0)
        {
            timer = cooldown;
            Rigidbody2D projectile = Instantiate(projectilePrefab, transform.position + GetPlayerDirection() * offset, Quaternion.identity);
            projectile.AddForce(GetPlayerDirection() * projectileSpeed, ForceMode2D.Impulse);
        }
    }
}
