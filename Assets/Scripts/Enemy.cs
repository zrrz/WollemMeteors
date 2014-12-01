using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject player;
	Vector3 dir;
	public float speed = 3.0f;
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

	void OnCollisionEnter2D(Collision2D col) {
		Instantiate(particle, col.contacts [0].point, Quaternion.LookRotation(col.contacts [0].normal, Vector3.back));
		col.gameObject.SendMessage ("TakeDamage", SendMessageOptions.DontRequireReceiver);
		if(col.gameObject.tag == "Player")
			audio.Play ();
	}
}
