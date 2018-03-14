using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGControl : MonoBehaviour
{

    private Transform herotransform;
    private float tempytransform;
    private float tempztransform;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        herotransform = GameObject.FindGameObjectWithTag("hero").transform;
        if (transform.position.x - herotransform.position.x < -30F)
        {
            tempytransform = transform.position.y;
            tempztransform = transform.position.z;
            transform.position = new Vector3(herotransform.position.x + 34.5F, tempytransform, tempztransform);
        }


    }
}