using UnityEngine;
using System.Collections;

public class CarrotMeteor : MonoBehaviour {

	GameObject player;
	Vector3 dir;
	public float speed = 3.0f;
	public float speedVariance = 0.4f;
	
	public GameObject particle;
	
	float rotSpeed;

	public GameObject carrotPrefab;
	
	void Start () {
		player = GameObject.Find ("Player");
		
		Vector2 pos = Random.insideUnitCircle * 7f;
		dir = (player.transform.position + new Vector3 (pos.x, pos.y)) - transform.position;
		
		dir.Normalize ();
		speed += Random.Range (-speedVariance, speedVariance);
		rigidbody2D.velocity = dir * speed;
		
		rotSpeed = Random.Range (-6f, 6f);
		Destroy (gameObject, 30.0f);
	}
	
	void Update () {
		if (rigidbody2D.velocity.sqrMagnitude < speed * 0.7f) {
			rigidbody2D.velocity *= 1.2f;
		}
		transform.Rotate (0f, 0f, rotSpeed);
	}
	
	void OnCollisionEnter2D(Collision2D col) {
		Instantiate(particle, col.contacts [0].point, Quaternion.LookRotation(col.contacts [0].normal, Vector3.back));
		if(col.gameObject.tag == "Player") {
			audio.Play ();
			for (int i = 0; i < 3; i++) {
				GameObject carrot = (GameObject)Instantiate (carrotPrefab, col.contacts [0].point + ((Vector2)transform.position - (Vector2)col.collider.transform.position).normalized, Quaternion.identity);
				carrot.transform.Rotate(0f, 0f, Random.Range(0f, 360f));
			}
			StartCoroutine ("DelayDestroy");
		}
	}

	IEnumerator DelayDestroy() {
		transform.GetChild(0).renderer.enabled = false;
		collider2D.enabled = false;
		yield return new WaitForSeconds (audio.clip.length);
		Destroy (gameObject);
	}
}
