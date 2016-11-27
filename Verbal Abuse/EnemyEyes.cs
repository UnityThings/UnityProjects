using UnityEngine;
using System.Collections;

public class EnemyEyes : MonoBehaviour {
	private GameObject player;
	public GameObject leftPupil;
	float AngleDeg;

	void Awake () {
		player = UnityEngine.GameObject.Find ("Player");
	}

	void Update () {
		float AngleRad = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x);
		AngleDeg = (180 / Mathf.PI) * AngleRad;
		transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
		leftPupil.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
	}
}
