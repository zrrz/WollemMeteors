using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(GameObject.Find("BGSongMaster") != null)
			Destroy(gameObject);

		DontDestroyOnLoad (gameObject);

		gameObject.name += "Master";
	}

	void OnLevelLoad() {

	}
	
	// Update is called once per frame
	void Update () {
		if(!audio.isPlaying) {
			audio.Play();
		}
	}
}
