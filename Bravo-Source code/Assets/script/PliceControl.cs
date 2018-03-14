using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PliceControl : MonoBehaviour
{

    public float moveSpeed = 12f;
    public static PliceControl _instance;

    // Use this for initialization
    void Start()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    public float GetSpeed()
    {
        return moveSpeed;
    }
}
