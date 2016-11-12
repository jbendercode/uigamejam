using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	Vector3 movement;

	public ArrayList pathList = new ArrayList();
	public float screenBoundX;
	public float screenBoundY;

	private int addLocationTimer = 5;
	private bool isTouching = false;

	// Use this for initialization
	void Awake () {

	}

	// Called when physics updates instead of every frame
	void FixedUpdate () {
		getPath ();
	}

	void getPath(){

		if (Input.touchCount == 1) {
			isTouching = true;
			addLocationTimer -= 1;

			if (addLocationTimer == 0){
//				Touch touch = Input.GetTouch (0);
//
//				float moveX = -(screenBoundX/2) + screenBoundX * touch.position.x / Screen.width;
//				float moveY = -(screenBoundY/2) + screenBoundY * touch.position.y / Screen.height;

				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
				Plane plane = new Plane(Vector3.up, transform.position);
				float distance = 0; 

				if (plane.Raycast (ray, out distance)) { 
					movement = ray.GetPoint (distance);
				}

				//movement.Set (moveX, 1f, moveY);
				addLocationTimer = 5;
				pathList.Add (movement);
			}
		}

		if (Input.touchCount == 0 && isTouching){
			foreach (var i in pathList){
				//Debug.Log(i);
			}
			isTouching = false;
		}


	}
}
