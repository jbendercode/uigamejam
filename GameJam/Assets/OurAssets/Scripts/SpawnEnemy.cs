using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime;
	public Transform[] spawnPoints;
	public float enemySpawnLimit;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	// Update is called once per frame
	void Update () {

	}

	void Spawn(){

		if (enemySpawnLimit > 0) {
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			enemySpawnLimit--;
		}

	}

}
