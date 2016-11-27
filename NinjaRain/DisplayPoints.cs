using UnityEngine;
using System.Collections;

public class DisplayPoints : MonoBehaviour {
	private float up;
	private GUIText score;
	private Color clr;
	private GameObject gameControl;
	private GameController gcScript;
	private int nrNinjas;

	void Start () {
		gameControl = UnityEngine.GameObject.Find ("GameControl");
		gcScript = gameControl.GetComponent <GameController>();
		score = gameObject.AddComponent<GUIText> ();
		Invoke ("Kill", 1);
		clr = new Color (1f, 1f, 1f, 1.0f);
		nrNinjas = gcScript.getNrNinjas();
	}

	void FixedUpdate(){
		up+=1f;
		clr.a -= 0.02f;
	}

	void OnGUI(){
		GUI.color = clr;
		Vector2 getPixelPos = Camera.main.WorldToScreenPoint (transform.position);
		getPixelPos.y = Screen.height - getPixelPos.y;
		Rect rect = new Rect (getPixelPos.x - 50f, getPixelPos.y - 20f - up, 100f, 40f);
		GUIStyle style = GUI.skin.GetStyle ("label");
		style.fontSize = 24;
		int scr = 100;
		score.text = nrNinjas + "*" + scr;
		GUI.Label (rect, score.text);
	}

	void Kill(){
		Destroy (gameObject);
	}
}
