using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBehaviour : MonoBehaviour
{

    public float offset;
    public Transform eye;

    // Update is called once per frame
    void Update()
    {
        eye.position = transform.position + (App.playersTransform.position - transform.position).normalized * offset;
    }
}
