using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{

    public float moveSpeed = 10f;
    public static CarControl _instance;

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
