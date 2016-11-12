using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {

	Vector3 movement;
	bool isTherePath = false;

	public float screenBoundX;
	public float screenBoundY;
	public float speed = 1f;
	//ArrayList pathList = new ArrayList();
    public GameObject enemyController;
    public EnemyController enemyPath;
    public GameObject deathWall;

    // Use this for initialization
    void Awake () {
        enemyController = GameObject.Find("EnemyController");
        deathWall = GameObject.Find("DeathWall");
        enemyPath = enemyController.GetComponent<EnemyController>();
    }

	// Called when physics updates instead of every frame
	void FixedUpdate () {
		Move ();
	}

	void Move (){ 

		if (isTherePath) {
			foreach (Vector3 i in enemyPath.pathList){
				movement.Set (i.x, i.y, i.z);
				transform.position = Vector3.MoveTowards (transform.position, movement, speed * Time.deltaTime);
			}

        }

		else {
            movement.Set(deathWall.transform.position.x, deathWall.transform.position.y, deathWall.transform.position.z);
            transform.position = Vector3.MoveTowards (transform.position, movement, speed * Time.deltaTime);
		}
			
	}
		
}
