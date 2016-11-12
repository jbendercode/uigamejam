using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved)
		    || Input.GetMouseButton (0))) {

			Plane objPlane = new Plane (Camera.main.transform.forward, this.transform.position);

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float rayDistance;
			if (objPlane.Raycast (ray, out rayDistance)) {
				this.transform.position = ray.GetPoint (rayDistance);
			}
		}
	}
}
