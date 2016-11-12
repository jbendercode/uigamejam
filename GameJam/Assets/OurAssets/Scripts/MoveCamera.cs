using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public float rotationSpeed = 100.0f;

	private float pitch = 9f;
	private float yaw = 270f;

	public Transform camera;

	void Update(){
		if (Input.touchCount > 0) {
			if (this.GetComponent<GUITexture>().HitTest(Input.GetTouch(0).position)) {
				OnTouchMoved ();
			}
		}
	}

	void OnTouchMoved(){
		pitch += Input.GetTouch (0).deltaPosition.y * rotationSpeed * Time.deltaTime;
		yaw += Input.GetTouch (0).deltaPosition.x * rotationSpeed * Time.deltaTime;

		pitch = Mathf.Clamp (pitch, -45, 45);
		yaw = Mathf.Clamp (yaw, 225, 315);

		camera.eulerAngles = new Vector3 (pitch, yaw, 0f);
	}

	public Vector3 GetRotationalVector(){
		return new Vector3 (pitch, yaw, 0f);
	}
}
