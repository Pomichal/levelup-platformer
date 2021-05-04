using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseBehaviour : MonoBehaviour
{

    public int layerMask = ~(1 << 8);

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

    public Vector3 GetPlayerDirection()
    {
        return (App.playersTransform.position - transform.position).normalized;
    }
}
