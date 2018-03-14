using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour {


	Vector3 offset;
	bool down=false;
	// Use this for initialization
	void Start () {
		
		Button btn = this.GetComponent<Button> ();
		if(tag=="PlayWithKeyboard"){
			btn.onClick.AddListener (OnClick1);
		}else if(tag=="PlayWithVoice"){
			btn.onClick.AddListener (OnClick2);
		}
	}

	void OnClick1(){
		HeroControl.settype (true); 
		down = true;
	}
	void OnClick2(){
		HeroControl.settype (false);
		down = true;
	}
	// Update is called once per frame
	void Update () {
		if (down == true) {
			offset = new Vector3 (0, -0.1f, 0);
			Camera.main.transform.position = Camera.main.transform.position + offset;
			if (Camera.main.transform.position.y <= 0) {
				SceneManager.LoadScene ("level 1");
			}
		}
	}

}
