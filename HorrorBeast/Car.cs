using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	void Start () {
		Color col = new Color (Random.Range (0.8f, 1.0f), Random.Range (0.8f, 1.0f), Random.Range (0.8f, 1.0f));
		GetComponent<Renderer>().material.color = col;
		transform.localScale = new Vector3(Random.Range (0.05f, 0.1f), 0.02f, 0.02f);
	}
	
	void Update () {
	
	}
}
