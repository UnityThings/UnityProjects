using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
	float speed= 5f;

	void OnEnable () {
		Invoke ("Destroy", 2f);
	}
	
	void Destroy(){
		Destroy(gameObject);
	}
	
	void Update () {
		Vector3 pos = transform.position;
		pos.x -= speed * Time.deltaTime;
		transform.position = pos;
	}
}
