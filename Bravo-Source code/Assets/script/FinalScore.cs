using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = " " + Score.count;
		Score.count = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
		
}
