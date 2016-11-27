using UnityEngine;
using System.Collections;

public class MapTransition : MonoBehaviour {
	private bool textTrans;
	private int mapNr;

	void Start(){
		Time.timeScale = 1.0f;
		mapNr = GameController.mapNr;
		if (GameController.finishedMap == true){
			textTrans = false;
			Invoke ("textTransition", 2);
			GameController.finishedMap = false;
		} else {
			textTrans = true;
			Invoke ("changeLevel", 2);
		}
	}

	void OnGUI() {
		GUIStyle style = GUI.skin.GetStyle ("Label");
		style.fontSize = 48;
		int w = 300;
		style.alignment = TextAnchor.MiddleCenter;
		if (!textTrans) {
			int lastMap = mapNr-1;
			GUI.Label (new Rect (Screen.width / 2 - w/2, 200, w, 60), "Level "+lastMap, style);
			GUI.Label (new Rect (Screen.width / 2 - w/2, 300, w, 60), "Complete", style);
		} else {
			GUI.Label (new Rect (Screen.width / 2 - w/2, 200, w, 60), "Level "+mapNr, style);
			style.fontSize = 24;
			GUI.Label (new Rect (Screen.width / 2 - w/2, 300, w, 60), GameController.MapObjectives(), style);
		}
	}

	void textTransition(){
		textTrans = true;
		Invoke ("changeLevel", 2);
	}

	void changeLevel(){
		Application.LoadLevel ("Main");  
	}
}
