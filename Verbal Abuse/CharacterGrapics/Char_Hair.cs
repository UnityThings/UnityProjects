using UnityEngine;
using System.Collections;

public class Char_Hair : MonoBehaviour {
	SpriteRenderer mySpriteRenderer;
	public Sprite[] CharHairstyles;
	Color[] hairColors;
	public GameObject beard, mustache, leftEyebrows, rightEyebrows;

	void Start () {
		mySpriteRenderer = gameObject.renderer as SpriteRenderer;
		int i = Random.Range (0, 5);
		mySpriteRenderer.sprite = CharHairstyles[i];
		if (i == 1) {
			transform.localPosition = new Vector3(0, 0.45f, 0);
		}
		if (i == 4) {
			transform.localPosition = new Vector3(0, 0.25f, 0);
		}

		hairColors = new Color[11];
		int r = Random.Range (0, 11);
		hairColors [0] = Color.black;
		hairColors [1] = new Color (0.25f, 0.125f, 0f, 1.0f);
		hairColors [2] = new Color (0.25f, 0.2f, 0.15f, 1.0f);
		hairColors [3] = new Color (0.375f, 0.25f, 0.2f, 1.0f);
		hairColors [4] = new Color (0.8f, 0.6f, 0f, 1.0f);
		hairColors [5] = new Color (0.875f, 0.8f, 0f, 1.0f);
		hairColors [6] = Color.gray;
		hairColors [7] = new Color (0.875f, 0.6f, 0.375f, 1.0f);
		hairColors [8] = new Color (0.6f, 0.45f, 0f, 1.0f);
		hairColors [9] = new Color (0.75f, 0f, 0f, 1.0f);
		hairColors [10] = new Color (1.0f, 0.2f, 0f, 1.0f);
		gameObject.renderer.material.color = hairColors [r];
		beard.renderer.material.color = hairColors [r];
		mustache.renderer.material.color = hairColors [r];
		leftEyebrows.renderer.material.color = hairColors [r];
		rightEyebrows.renderer.material.color = hairColors [r];

		if (Random.Range (0, 2) == 0) 
		{
			beard.renderer.enabled = true;
			if (Random.Range (0, 2) == 0) 
			{
				mustache.renderer.enabled = true;
			}
		}
		if (Random.Range (0, 10) == 0) 
		{
			mustache.renderer.enabled = true;
		}
	}
}
