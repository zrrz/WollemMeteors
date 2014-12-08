using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject coinPrefab;
	public GameObject carrotMeteorPrefab;
	public GameObject healthPrefab;

	public float enemySpawnRate = 1.5f;
	public float coinSpawnRate = 3f;
	public float carrotMeteorSpawnRate = 5.5f;
	public float healthSpawnRate = 8.5f;
	public float rateVariance = 0.4f;
	public float healthAndCarrotMeteorVariance = 2.0f;

	public float delayTime = 2f;
	
	void Start () {
		StartCoroutine ("Wait");
		Camera.main.orthographic = true;
	}

	IEnumerator Wait() {
		yield return new WaitForSeconds (delayTime);
		StartCoroutine ("SpawnEnemy");
		StartCoroutine ("SpawnCoin");
		StartCoroutine ("SpawnCarrotMeteor");
		StartCoroutine ("SpawnHealth");
	}

	IEnumerator SpawnEnemy() {
		while(true) {
			Vector3 spawnPos = Random.insideUnitCircle.normalized * 12.0f;

			GameObject enemy = (GameObject)Instantiate (enemyPrefab, spawnPos, Quaternion.identity);
			Color col = enemy.transform.GetChild(0).renderer.material.color;
			col.r += Random.Range (-0.2f, 0.1f);
			col.g += Random.Range (-0.2f, 0.1f);
			col.b += Random.Range (-0.4f, 0.1f);
			enemy.transform.GetChild(0).renderer.material.color = col;

			enemy.transform.localScale *= Random.Range(0.8f, 1.3f);

			enemy.transform.Rotate(0f, 0f, Random.Range(0f, 360f));
			enemy.transform.parent = transform;

			yield return new WaitForSeconds(Random.Range(enemySpawnRate - rateVariance, enemySpawnRate + rateVariance));
		}
	}

	IEnumerator SpawnCoin() {
		while(true) {
			Vector3	spawnPos = Random.insideUnitCircle.normalized * 12.0f;

			GameObject enemy = (GameObject)Instantiate (coinPrefab, spawnPos, Quaternion.identity);
			
			enemy.transform.Rotate(0f, 0f, Random.Range(0f, 360f));
			enemy.transform.parent = transform;

			yield return new WaitForSeconds(Random.Range(coinSpawnRate - rateVariance, coinSpawnRate + rateVariance));
		}
	}

	IEnumerator SpawnCarrotMeteor() {
		while(true) {
			yield return new WaitForSeconds(Random.Range(carrotMeteorSpawnRate - healthAndCarrotMeteorVariance, carrotMeteorSpawnRate + healthAndCarrotMeteorVariance));

			Vector3 spawnPos = Random.insideUnitCircle.normalized * 12.0f;
			
			GameObject enemy = (GameObject)Instantiate (carrotMeteorPrefab, spawnPos, Quaternion.identity);
			Color col = enemy.transform.GetChild(0).renderer.material.color;
			col.r += Random.Range (-0.1f, 0.1f);
			col.g += Random.Range (-0.1f, 0.1f);
			col.b += Random.Range (-0.2f, 0.1f);
			enemy.transform.GetChild(0).renderer.material.color = col;
			
			enemy.transform.localScale *= Random.Range(0.8f, 1.3f);
			
			enemy.transform.Rotate(0f, 0f, Random.Range(0f, 360f));
			enemy.transform.parent = transform;
		}
	}

	IEnumerator SpawnHealth() {
		while(true) {
			yield return new WaitForSeconds(Random.Range(healthSpawnRate - healthAndCarrotMeteorVariance, healthSpawnRate + healthAndCarrotMeteorVariance));

			Vector3	spawnPos = Random.insideUnitCircle.normalized * 12.0f;
			
			GameObject enemy = (GameObject)Instantiate (healthPrefab, spawnPos, Quaternion.identity);
			
			enemy.transform.Rotate(0f, 0f, Random.Range(0f, 360f));
			enemy.transform.parent = transform;
		}
	}
}
