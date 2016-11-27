using UnityEngine;
using System.Collections;

public class PlayerEyes : MonoBehaviour {
	public GameObject leftPupil;

	void Update () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float AngleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
		float AngleDeg = (180 / Mathf.PI) * AngleRad;
		transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
		leftPupil.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);	
	}
}
