using UnityEngine;
using System.Collections;

public class Char_Mouth : MonoBehaviour {
	SpriteRenderer mySpriteRenderer;
	public Sprite[] mouthTypes;

	void Start () {
		mySpriteRenderer = gameObject.renderer as SpriteRenderer;
		int i = Random.Range (0, 6);
		mySpriteRenderer.sprite = mouthTypes[i];
	}

}
