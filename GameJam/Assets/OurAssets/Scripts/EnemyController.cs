using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	Vector3 movement;

    public ArrayList pathList = new ArrayList();
    public float screenBoundX;
	public float screenBoundY;
	public float pathTimer = 1f;

	// Use this for initialization
	void Awake () {

	}

	// Called when physics updates instead of every frame
	void FixedUpdate () {
		getPath ();
	}

	void getPath(){

		for(int i = 0; i < pathTimer; i++)
		{
			if (Input.touchCount == 1) {
				Touch touch = Input.GetTouch (0);

				float moveX = -(screenBoundX/2) + screenBoundX * touch.position.x / Screen.width;
				float moveY = -(screenBoundY/2) + screenBoundY * touch.position.y / Screen.height;

				movement.Set (moveX, 1f, moveY);
				Debug.Log (movement);

				pathList.Add (movement);
			}
		}

		Debug.Log (pathList);
	}
}
