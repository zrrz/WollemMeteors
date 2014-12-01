using UnityEngine;
using System.Collections;

public class Vertical : MonoBehaviour {

	public float moveSpeed = 3f;
	public float maxSpeed = 7f;

	public GameObject upThruster, leftThruster, rightThruster, downThruster;

	public int maxHealth = 3;

	int health;

	public GameObject healthMesh;
	public GameObject scoreMesh;

	int points = 0;

	void Start () {
		health = maxHealth;
	}

	void Update () {
		Vector3 dir = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0f);
		Vector3 vel = rigidbody2D.velocity;
		if (dir != Vector3.zero) {
			rigidbody2D.AddForce (dir * moveSpeed);
		}

		if (Input.GetAxis ("Horizontal") < 0f)
			rightThruster.SetActive (true);
		else
			rightThruster.SetActive (false);

		if (Input.GetAxis ("Horizontal") > 0f)
			leftThruster.SetActive (true);
		else
			leftThruster.SetActive (false);

		if (Input.GetAxis ("Vertical") < 0f)
			upThruster.SetActive (true);
		else
			upThruster.SetActive (false);

		if (Input.GetAxis ("Vertical") > 0f)
			downThruster.SetActive (true);
		else
			downThruster.SetActive (false);

//		if(Input.GetKeyDown(KeyCode.Space)) {
//			RaycastHit2D[] hits = Physics2D.CircleCast(transform.position, 20f, Vector3.zero);
//			foreach(RaycastHit2D hit in hits) {
//				
//			}
//		}

		vel.x = Mathf.Clamp (vel.x, -maxSpeed, maxSpeed);
		vel.y = Mathf.Clamp (vel.y, -maxSpeed, maxSpeed);
		rigidbody2D.velocity = vel;

		rigidbody2D.angularVelocity = 0f;
		transform.rotation = Quaternion.identity;

		Vector3 pos = transform.position; //Sloppy, but oh well
		if (pos.x > 12.1f)
			pos.x = -12.0f;
		if (pos.x < -12.1f)
			pos.x = 12.0f;

		if (pos.y > 5.9f)
			pos.y = -5.8f;
		if (pos.y < -5.9f)
			pos.y = 5.8f;
		transform.position = pos;
	}

	void TakeDamage() {
		health--;
		healthMesh.GetComponent<TextMesh> ().text = "Health: " + health;
		if(health <= 0) {
			Application.LoadLevel(0);
		}
	}

	void GainPoint() {
		points++;
		scoreMesh.GetComponent<TextMesh> ().text = "Score:    " + points;
	}
}
