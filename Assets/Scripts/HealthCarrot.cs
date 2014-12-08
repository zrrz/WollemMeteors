using UnityEngine;
using System.Collections;

public class HealthCarrot : MonoBehaviour {

	GameObject player;
	Vector3 dir;
	public float speed = 1.2f;
	public float speedVariance = 0.4f;
	
	public GameObject particle;
	
	void Start () {
		player = GameObject.Find ("Player");
		
		Vector2 pos = Random.insideUnitCircle * 7f;
		dir = (player.transform.position + new Vector3 (pos.x, pos.y)) - transform.position;
		
		dir.Normalize ();
		speed += Random.Range (-speedVariance, speedVariance);
		rigidbody2D.velocity = dir * speed;
		Destroy (gameObject, 30.0f);
	}
	
	void Update () {
		if (rigidbody2D.velocity.sqrMagnitude < speed * 0.7f) {
			rigidbody2D.velocity *= 1.2f;
		}
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if(col.tag == "Player") {
			Instantiate(particle, transform.position - Vector3.back, Quaternion.identity);
			col.gameObject.SendMessage ("GainHealth", SendMessageOptions.DontRequireReceiver);
			audio.Play ();
			StartCoroutine ("DelayDestroy");
		}
	}
	
	IEnumerator DelayDestroy() {
		renderer.enabled = false;
		collider2D.enabled = false;
		yield return new WaitForSeconds (audio.clip.length);
		Destroy (gameObject);
	}
}
