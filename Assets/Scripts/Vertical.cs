using UnityEngine;
using System.Collections;

public class Vertical : MonoBehaviour {

	public float moveSpeed = 3f;
	public float maxSpeed = 7f;

	public GameObject upThruster, leftThruster, rightThruster, downThruster;

	public int maxHealth = 3;

	int health;

	public Sprite[] healthBars;

	public GameObject scoreMesh;

	public SpriteRenderer healthBar;

	public GameObject explosionParticle;

	int points = 0;

	bool allowInput = true;

	void Start () {
		health = maxHealth;
	}

	void Update () {
		if (!allowInput)
			return;

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


		vel.x = Mathf.Clamp (vel.x, -maxSpeed, maxSpeed);
		vel.y = Mathf.Clamp (vel.y, -maxSpeed, maxSpeed);
		rigidbody2D.velocity = vel;

		rigidbody2D.angularVelocity = 0f;
		transform.rotation = Quaternion.identity;

		Vector3 pos = transform.position; //Sloppy, but oh well
		if (pos.x > 9.2f)
			pos.x = -9.1f;
		if (pos.x < -9.2f)
			pos.x = 9.1f;

		if (pos.y > 5.8f)
			pos.y = -5.7f;
		if (pos.y < -5.8f)
			pos.y = 5.7f;
		transform.position = pos;
	}

	void TakeDamage() {
		if(health > 0) {
			health--;						
			healthBar.sprite = healthBars [maxHealth - health];
			if(health <= 0) {
				Instantiate(explosionParticle, transform.position, Quaternion.identity);
				collider2D.enabled = false;
				transform.GetChild(0).renderer.enabled = false;
				allowInput = false;
				rightThruster.SetActive (false);
				leftThruster.SetActive (false);
				upThruster.SetActive (false);
				downThruster.SetActive (false);
				StartCoroutine("Lose");
			}
		}
	}

	IEnumerator Lose() {
		yield return new WaitForSeconds (1f);
		Application.LoadLevel("Lose");
	}

	void GainPoint() {
		points++;
		scoreMesh.GetComponent<TextMesh> ().text = "x " + points + "/20";

		if(points > 19) {
			Application.LoadLevel("Win");
		}
	}

	void GainHealth() {
		if(health < maxHealth) {
			health++;
			healthBar.sprite = healthBars [maxHealth - health];
		}
	}
}
