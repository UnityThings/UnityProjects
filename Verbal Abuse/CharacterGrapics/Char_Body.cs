using UnityEngine;
using System.Collections;

public class Char_Body : MonoBehaviour {
	Color[] bodyColors;

	void Start () {
		gameObject.renderer.material.color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), 1.0f);
	}

}
