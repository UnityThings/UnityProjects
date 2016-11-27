using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {

	void Start () {
		Color col = new Color (Random.Range (0.8f, 1.0f), Random.Range (0.8f, 1.0f), Random.Range (0.8f, 1.0f));
		foreach (Transform child in transform) {
			Renderer rend = child.gameObject.GetComponent<Renderer>();
			rend.material.color = col;
		}

		//random scale
		float height = Random.Range (0.25f, 1);
		float width = Random.Range (0.5f, 0.75f);
		float length = Random.Range (0.5f, 0.75f);

		Renderer r = transform.GetChild(0).gameObject.GetComponent<Renderer>();
		r.material.mainTextureScale = new Vector2 (width, height*4);
		transform.GetChild(0).transform.localScale = new Vector3(width, height, length);
		transform.GetChild(1).transform.localScale = new Vector3(width, 0.1f, length);
		transform.GetChild(0).transform.position += new Vector3(0, height/2, 0);
		transform.GetChild(1).transform.position += new Vector3(0, height-0.5f, 0);
	}
}
