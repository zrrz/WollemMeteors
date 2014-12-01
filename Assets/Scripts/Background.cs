using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Background : MonoBehaviour {

	public GameObject starPrefab;

	List<GameObject> stars;

	void Start () {
		stars = new List<GameObject> ();
		for(int i = 0; i < 300; i++) {
			GameObject star = CreateStar();
			float size = Random.Range (0.2f, 0.7f);
			star.transform.localScale *= size;
			star.rigidbody2D.velocity = Random.insideUnitCircle.normalized * .05f * size;
			stars.Add(star);
			star.transform.parent = transform;
		}

		StartCoroutine ("ShootingStar");
	}

	void Update () {
		for(int i = 0; i < stars.Count; i++) {
			Vector3 pos = stars[i].transform.position;
			if(pos.x > 12.3f)
				pos.x = -12.2f;
		   	if(pos.x < -12.3f)
			   pos.x = 12.2f;
			if (pos.y > 6.4f)
			   pos.y = -6.3f;
			if (pos.y < -6.4f)
			   pos.y = 6.3f;
			stars[i].transform.position = pos;
		}
	}

	GameObject CreateStar () {
		GameObject star = (GameObject)Instantiate (starPrefab, new Vector3 (Random.Range (-12.0f, 12.0f), Random.Range (-6.0f, 6.0f), 0f), Random.rotation);
		star.transform.LookAt (star.transform.position + Vector3.back);
		star.transform.Rotate (new Vector3 (0f, 0f, Random.Range (0f, 360f)));
		Color col = star.renderer.material.color;
		col.r += Random.Range (-0.1f, 0.1f);
		col.g += Random.Range (-0.1f, 0.1f);
		col.b += Random.Range (-0.3f, 0.1f);
		col.a += Random.Range (-0.4f, 0f);
		star.renderer.material.color = col;
		star.AddComponent<Rigidbody2D> ();
		star.rigidbody2D.gravityScale = 0f;
		star.rigidbody2D.isKinematic = false;
		return star;
	}

	IEnumerator ShootingStar() {
		while (true) {
			yield return new WaitForSeconds (Random.Range(4f, 12f));
			GameObject star = CreateStar ();
			float size = Random.Range (0.4f, 0.7f);
			star.transform.localScale *= size;

			star.transform.position = Random.insideUnitCircle.normalized * 12.0f;

			Vector2 pos = Random.insideUnitCircle * 7f;
			Vector3 dir = new Vector3 (pos.x, pos.y) - star.transform.position;

			star.rigidbody2D.velocity = dir.normalized * 8f;
	//		stars.Add (star);
	//		star.transform.parent = transform;
			Destroy(star, 8f);
		}
	}
}
