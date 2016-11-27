using UnityEngine;
using System.Collections;

public class Char_Eyebrowse : MonoBehaviour {
	SpriteRenderer mySpriteRenderer, otherSpriteRenderer;
	public Sprite[] EyebrowsStyles;
	public GameObject leftEyebrow;

	void Start () {
		mySpriteRenderer = gameObject.renderer as SpriteRenderer;
		otherSpriteRenderer = leftEyebrow.renderer as SpriteRenderer;
		int i = Random.Range (0, 4);
		mySpriteRenderer.sprite = EyebrowsStyles[i];
		if (i == 3) {
			otherSpriteRenderer.sprite = EyebrowsStyles [0];
		} else {
			otherSpriteRenderer.sprite = EyebrowsStyles[i];
		}
	}

}
