using UnityEngine;
using System.Collections;

public class Char_Eye : MonoBehaviour {
	SpriteRenderer mySpriteRenderer, otherSpriteRenderer;
	public Sprite[] eyeTypes;
	public GameObject leftEye;

	
	void Start () {
		mySpriteRenderer = gameObject.renderer as SpriteRenderer;
		otherSpriteRenderer = leftEye.renderer as SpriteRenderer;
		int i = Random.Range (0, 4);
		mySpriteRenderer.sprite = eyeTypes[i];
		otherSpriteRenderer.sprite = eyeTypes[i];
	}

}
