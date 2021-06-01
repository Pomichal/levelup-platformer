using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{

    public float scale;
    Material mat;

    void Awake()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetFloat("_OutlineWidth", Mathf.Abs(Mathf.Sin(Time.time)) * scale);
    }
}
