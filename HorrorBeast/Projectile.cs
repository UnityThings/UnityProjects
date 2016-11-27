using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	float speed= 5f;

	void OnEnable () {
		Invoke ("Destroy", 2f);
	}
	
	void Destroy(){
		gameObject.SetActive (false);
	}
	
	void OnDisable(){
		CancelInvoke ();
	}

	void Update () {
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
	}
}
