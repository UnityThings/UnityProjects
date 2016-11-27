using UnityEngine;
using System.Collections;

public class Human : MonoBehaviour {
	public GameObject die;

	void Start () {
	
	}
	
	void OnMouseDown(){
		if (GameLogic.fps) {
			GameLogic.score +=1;
			Instantiate (die, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}

	void Update(){
		Vector3 pos = transform.position;
		pos.x -= Time.deltaTime;
		transform.position = pos;
	}
}
