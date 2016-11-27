using UnityEngine;
using System.Collections;

public class menuStart : MonoBehaviour {
	public Sprite cutSprite;
	public GameObject sword;

	void OnMouseDown() {
		SpriteRenderer mySpriteRenderer = gameObject.GetComponent<Renderer>() as SpriteRenderer;
		mySpriteRenderer.sprite = cutSprite;
		sword.SetActive (true);
		Color fadeOut = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		fadeOut.a = Mathf.Lerp (1.0f, 0.0f, 0.5f);
		sword.GetComponent<Renderer>().material.color = fadeOut;
		Invoke ("changeLevel", 0.5f);
	}

	void Update(){

	}

	void hideSword(){
		sword.SetActive (false);
	}

	void changeLevel(){
		Application.LoadLevel ("MapMenu");  
	}
}
