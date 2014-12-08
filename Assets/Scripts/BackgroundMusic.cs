using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {

	public int persistAmount = 0;
	int persisted = 0;

	int startLevel = -1;

	// Use this for initialization
	void Start () {
//		if(GameObject.Find("BGSongMaster") != null)
//			Destroy(gameObject);

		DontDestroyOnLoad (gameObject);

		if(startLevel == -1) {
			startLevel = Application.loadedLevel;
		}

//		gameObject.name += "Master";
	}

	void OnLevelWasLoaded(int level) {
		if(startLevel == -1) {
			startLevel = Application.loadedLevel;
		}
		if(level != startLevel) {
			persisted++;
			if(persisted > persistAmount)
				Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!audio.isPlaying) {
			audio.Play();
		}
	}
}
