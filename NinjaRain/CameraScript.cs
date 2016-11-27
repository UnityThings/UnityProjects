using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	void Awake () {
		Camera.main.orthographicSize = Screen.height / 2f / 100f;
	}
}
