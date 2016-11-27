using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public Transform target;
	private Vector3 velocity = Vector3.zero;
	private float smoothTime = 0.3f, zoomSpeed = 5;

	void Update () {
		Vector3 goalPos = target.position;
		transform.position = Vector3.SmoothDamp (transform.position, goalPos, ref velocity, 0.3f);
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		if (scroll != 0.0f)
		{
			camera.orthographicSize -= scroll*zoomSpeed;
		}
	}
}
