using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int count = 0;
    //private GameObject hero;
   

	// Use this for initialization
	void Start () {
        //hero = GameObject.FindGameObjectWithTag("hero");


        GetComponent<Text>().text = "score:" + count;

    }
	
	// Update is called once per frame
	void Update () {
        //GetComponent<Text>().text = "Score:" + count * 10;
        count++;
        GetComponent<Text>().text = "Score:" + count;
        //Final
    }
}
