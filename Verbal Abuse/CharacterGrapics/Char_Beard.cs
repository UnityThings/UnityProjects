using UnityEngine;
using System.Collections;

public class Char_Beard : MonoBehaviour {
	SpriteRenderer mySpriteRenderer;
	public Sprite[] CharBeardstyles;

	void Start () {
		mySpriteRenderer = gameObject.renderer as SpriteRenderer;
		int i = Random.Range (0, 4);
		mySpriteRenderer.sprite = CharBeardstyles[i];
		if (i == 1) {
			transform.localPosition = new Vector3(0, -0.55f, 0);
		}
		if (i == 3) {
			transform.localPosition = new Vector3(0, -0.45f, 0);
		}
	}

}
