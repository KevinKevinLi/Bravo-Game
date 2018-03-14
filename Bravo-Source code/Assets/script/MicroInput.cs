using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroInput : MonoBehaviour {

	/*microphone*/
	public static float volume;
	AudioClip microrecord;
	string device;

	// Use this for initialization
	void Start () {
		/*microphone init*/
		device = Microphone.devices [0];
		microrecord = Microphone.Start (device,true,100,44100);
	}
	
	// Update is called once per frame
	void Update () {
		volume = GetMaxVolume ();
		//Debug.Log("volume:"+volume);
	}

	float GetMaxVolume(){
		float maxVolume = 0f;
		float[] volumeData = new float[128];
		int offset = Microphone.GetPosition(device)-128+1;
		if (offset < 0) {
			return 0;
		}
		microrecord.GetData (volumeData,offset);
		for (int i = 0; i < 128; i++) {
			float tempMax = volumeData [i]*volumeData [i]*volumeData [i]*12;
			if (maxVolume < tempMax) {
				maxVolume = tempMax;
			}
		}
		return maxVolume;
	}

}
