using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemyBehaviour : EnemyBaseBehaviour
{

    void FixedUpdate()
    {
        if(CanSeeThePlayer() && timer <=0)
        {
            FireProjectile();
        }
    }
}
