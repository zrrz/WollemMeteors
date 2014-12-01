using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	float timer = 0f;
	public float changeTime = 4.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > changeTime)
			Application.LoadLevel (Application.loadedLevel + 1);
	}
}
