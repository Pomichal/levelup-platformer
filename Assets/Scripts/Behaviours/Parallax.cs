using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public Transform camPosition;

    public float parallaxEffect;

    private float width;
    private float startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = camPosition.position.x * (1 - parallaxEffect);

        float dist = camPosition.position.x * parallaxEffect;

        if(temp > startPos + width)
        {
            startPos += width;
        }
        else if(temp < startPos - width)
        {
            startPos -= width;
        }
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
    }
}
