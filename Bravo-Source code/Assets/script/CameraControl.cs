using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private GameObject hero;
    private Transform heroTransform;
    private float heroSpeed;
    private Vector3 offset;
    bool isZoom;
    //float wheelSpeed = 2;

	// Use this for initialization
	void Start () {
        hero = GameObject.FindGameObjectWithTag("hero");
        //heroSpeed=hero.
        heroTransform = hero.transform;//position of the hero
        offset = transform.position - heroTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    //catch up with the hero
    void LateUpdate()
    {
        Camera.main.transform.position = heroTransform.position + offset;
        //Camera.main.transform.position = new Vector2(heroTransform.position.x, Camera.main.transform.position.y);

        //isZoom = HeroControl._instance.isJump;
        //if (isZoom == true)
        //{
        //    Camera.main.transform.Translate(Vector3.forward * wheelSpeed);
        //}
    }
}
