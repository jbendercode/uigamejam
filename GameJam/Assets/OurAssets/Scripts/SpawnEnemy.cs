using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SpawnEnemy : NetworkBehaviour {

	public GameObject enemy;
	public float spawnTime;
	public Transform[] spawnPoints;
	public float enemySpawnLimit;

    // Use this for initialization
      void Start () {
        Debug.Log("Spawn time");
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	// Update is called once per frame
	void Update () {

	}
    
	void Spawn(){
     
        if (enemySpawnLimit > 0) {
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			var enemyNet = (GameObject)Instantiate(enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
            NetworkServer.Spawn(enemyNet);
            enemySpawnLimit--;
		}

	}

}
