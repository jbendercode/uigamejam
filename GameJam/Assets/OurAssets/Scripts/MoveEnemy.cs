using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MoveEnemy : NetworkBehaviour {

	Vector3 movement;
	bool isTherePath = false;
	bool isDead = false;
    public ArrayList thisPathList = new ArrayList();

    public float screenBoundX;
	public float screenBoundY;
	public float speed = 1f;
	public float pathMoveDur;
    public GameObject enemyController;
    public EnemyController enemyPath;
    public GameObject deathWall;
    [SyncVar]
    public bool isShot = false;

    // Use this for initialization
    void Awake () {
        enemyController = GameObject.Find("EnemyController");
        deathWall = GameObject.Find("DeathWall");
        enemyPath = enemyController.GetComponent<EnemyController>();
        thisPathList.AddRange(enemyPath.fullPathList);

		if (enemyPath != null) {
			isTherePath = true;
		}

		InvokeRepeating ("CheckPath", pathMoveDur, pathMoveDur);
			
    }

	// Called when physics updates instead of every frame
	void FixedUpdate () {
		//CheckPath ();
		transform.position = Vector3.MoveTowards (transform.position, movement, speed * Time.deltaTime);

        ShotDestroy();

    }

	void reversePath(){
        thisPathList.Reverse ();
	}

	IEnumerator Move ()
	{
		foreach (Vector3 i in thisPathList)
        {
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

    public void ShotDestroy() {
        if (isShot) {
            Debug.Log("Destroy!");
            Network.Destroy(gameObject);
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
