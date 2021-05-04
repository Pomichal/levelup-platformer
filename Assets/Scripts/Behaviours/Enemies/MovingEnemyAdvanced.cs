using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyAdvanced : MovingEnemyBehaviour
{

    public float highCheckDistance;

    public override bool CanGoForward(Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + direction, Vector3.down, highCheckDistance, layerMask);
        Debug.DrawRay(transform.position +direction, Vector3.down * highCheckDistance);

        if(hit.collider != null)
        {
            return base.CanGoForward(direction);
        }
        return false;
    }
}
