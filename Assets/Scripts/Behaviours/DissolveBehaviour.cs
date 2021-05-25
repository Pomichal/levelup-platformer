using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveBehaviour : MonoBehaviour
{

    Material mat;
    float timer;

    void Awake()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            timer = 3f;
            mat.SetFloat("Fade", 0);
        }

        if(timer > 0)
        {
            timer -= Time.deltaTime;
            mat.SetFloat("Fade", timer / 3f);
        }
    }
}
