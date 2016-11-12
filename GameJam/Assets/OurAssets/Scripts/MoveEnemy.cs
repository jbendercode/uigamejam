using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {

	Vector3 movement;
	bool isTherePath = false;
	bool isDead = false;

	public float screenBoundX;
	public float screenBoundY;
	public float speed = 1f;
	public float pathMoveDur;
    public GameObject enemyController;
    public EnemyController enemyPath;
    public GameObject deathWall;

    // Use this for initialization
    void Awake () {
        enemyController = GameObject.Find("EnemyController");
        deathWall = GameObject.Find("DeathWall");
        enemyPath = enemyController.GetComponent<EnemyController>();

		if (enemyPath != null) {
			isTherePath = true;
		}

		InvokeRepeating ("CheckPath", pathMoveDur, pathMoveDur);
			
    }

	// Called when physics updates instead of every frame
	void FixedUpdate () {
		//CheckPath ();
		transform.position = Vector3.MoveTowards (transform.position, movement, speed * Time.deltaTime);
	}

	void reversePath(){
		enemyPath.pathList.Reverse ();
	}

	IEnumerator Move ()
	{
		foreach (Vector3 i in enemyPath.pathList){
			movement.Set (i.x, i.y, i.z);
			if (transform.position != movement) {
				yield return new WaitForSeconds(pathMoveDur);
			}
		}

		movement.Set (deathWall.transform.position.x, deathWall.transform.position.y, deathWall.transform.position.z);

	}

	void CheckPath (){ 
		if (!isDead) {
			if (isTherePath) {
				StartCoroutine(Move());
			} 

			else {
				Debug.Log ("no path");
				movement.Set (deathWall.transform.position.x, deathWall.transform.position.y, deathWall.transform.position.z);
			}
		}
			
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "DeathWall")
		{
			isDead = true;
			Destroy(gameObject);
		}

		if(col.gameObject.name == "InvisibleWalls")
		{
			reversePath ();
		}
	}
		
}
