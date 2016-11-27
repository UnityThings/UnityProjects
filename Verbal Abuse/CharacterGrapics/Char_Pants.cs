using UnityEngine;
using System.Collections;

public class Char_Pants : MonoBehaviour {
	Color[] pantColors;
	public GameObject leftLeg, rightLeg;

	void Start () {
		pantColors = new Color[6];
		int r = Random.Range (0, 6);
		pantColors [0] = new Color (0.1f, 0.1f, 0.1f, 1.0f);
		pantColors [1] = new Color (0.5f, 0.25f, 0.2f, 1.0f);
		pantColors [2] = new Color (0.25f, 0.25f, 0.25f, 1.0f);
		pantColors [3] = new Color (0.25f, 0.3f, 0.4f, 1.0f);
		pantColors [4] = new Color (0.15f, 0.15f, 0.35f, 1.0f);
		pantColors [5] = new Color (0.5f, 0.6f, 0f, 1.0f);
		gameObject.renderer.material.color = pantColors [r];
		leftLeg.renderer.material.color = pantColors [r];
		rightLeg.renderer.material.color = pantColors [r];
	}

}
