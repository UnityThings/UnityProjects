using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {
	public GameObject character;
	private int highscore;

	public void Awake(){
		highscore = PlayerPrefs.GetInt("highscore", 0); 
	}

	public void StartGame(){
		Application.LoadLevel ("Main");
	}

	public void Quit(){
		Application.Quit ();
	}

	void OnGUI() {
		GUIStyle style = GUI.skin.GetStyle ("label");
		style.fontSize = 12;
		GUI.Label (new Rect (Screen.width - 100, 0, 100, 50), "Highscore: " + highscore.ToString());
	}
}
