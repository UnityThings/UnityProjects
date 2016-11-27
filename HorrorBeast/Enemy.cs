using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	float speed = 3f, time, offset;
	public GameObject explode, bullet;

	void Start () {
		offset = Random.value * (Mathf.PI / 2);
		float i = Random.Range (1f, 2f);
		InvokeRepeating ("Shoot", 3.5f, i);
	}

	void Shoot(){
		Vector3 pos = transform.position;
		Instantiate(bullet,new Vector3(pos.x-0.1f, pos.y, pos.z), Quaternion.identity);
	}

	void Update () {
		time += Time.deltaTime;
		Vector3 pos = transform.position;
		pos.x -= speed * Time.deltaTime;
		pos.y += Mathf.Sin (offset+Time.time * 2) / 60;
		transform.position = pos;
		if (transform.position.x < -5) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision col) {
		Instantiate (explode, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
