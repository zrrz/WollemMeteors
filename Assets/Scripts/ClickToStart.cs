using UnityEngine;
using System.Collections;

public class ClickToStart : MonoBehaviour {

	float timer = 0f;

	public float allowInputTimer = 2f;

	public float nextLevelTime = 10f;

	public string levelToLoad;

	void Start () {
		
	}

	void Update () {
		timer += Time.deltaTime;
		if(timer > allowInputTimer) {
			if(Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f || timer > nextLevelTime)
				Application.LoadLevel(levelToLoad);
		}
	}
}
