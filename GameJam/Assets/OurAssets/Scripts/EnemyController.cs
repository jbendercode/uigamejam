using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	Vector3 movement;
    public  ArrayList fullPathList= new ArrayList();


    private ArrayList pathList = new ArrayList();
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


				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
				Plane plane = new Plane(Vector3.up, transform.position);
				float distance = 0; 

				if (plane.Raycast (ray, out distance)) { 
					movement = ray.GetPoint (distance);
				}

				addLocationTimer = 5;
				pathList.Add (movement);
			}
            Debug.Log("Got Path");
        }

        if (Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            fullPathList.Clear();
            fullPathList.AddRange(pathList);
            pathList.Clear();
            Debug.Log("Path Clear");
        }

		if (Input.touchCount == 0 && isTouching){
			foreach (var i in pathList){
				//Debug.Log(i);
			}
			isTouching = false;
        }


	}
}
