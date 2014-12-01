using UnityEngine;
using System.Collections;

public class FadeText : MonoBehaviour {

	public float delayTime = 2f;
	public float fadeTime = 1f;

	float timer = 0f;

	void Start () {
		
	}

	void Update () {
		timer += Time.deltaTime;
		if(timer > delayTime) {
			TextMesh[] meshes = GetComponentsInChildren<TextMesh> ();

			foreach(TextMesh mesh in meshes) {
				mesh.color -= new Color(0f, 0f, 0f, Time.deltaTime * fadeTime);
			}
		}
	}
}
