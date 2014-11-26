using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	public float spawnRate = 1.5f;
	public float rateVariance = 0.4f;

	public bool spawnDepth = true;
	
	void Start () {
		StartCoroutine ("SpawnEnemy");
	}

	IEnumerator SpawnEnemy() {
		while(true) {
			Vector3 spawnPos;
			if(spawnDepth) {
				spawnPos = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-6.0f, 6.0f), 15.0f);
			} else {
				Camera.main.orthographic = true;
				spawnPos = Random.insideUnitCircle.normalized * 12.0f;
			}
			GameObject enemy = (GameObject)Instantiate (enemyPrefab, spawnPos, Quaternion.identity);
			Color col = enemy.transform.GetChild(0).renderer.material.color;
			col.r += Random.Range (-0.2f, 0.1f);
			col.g += Random.Range (-0.2f, 0.1f);
			col.b += Random.Range (-0.4f, 0.1f);
			enemy.transform.GetChild(0).renderer.material.color = col;

			enemy.transform.localScale *= Random.Range(0.8f, 1.3f);

			enemy.transform.Rotate(0f, 0f, Random.Range(0f, 360f));
			enemy.transform.parent = transform;
			yield return new WaitForSeconds(Random.Range(spawnRate - rateVariance, spawnRate + rateVariance));
		}
	}
}
