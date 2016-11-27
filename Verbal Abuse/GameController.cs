using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject enemy, powerup;
	Vector3 spawnValues = new Vector3(65,45,0);
	private int score, highscore;
	private GameObject player;
	private PlayerScript pScript;
	private float faster;

	void Start () {
		faster = 5;
		Time.timeScale = 1.0f;
		score = 0;
		highscore = PlayerPrefs.GetInt("highscore", 0); 
		player = UnityEngine.GameObject.Find ("Player");
		pScript = player.GetComponent <PlayerScript>();

		InvokeRepeating("SpawnEnemy", 5, faster);
		//InvokeRepeating("SpawnPowerUp", 2, 12);
	}

	void SpawnEnemy(){
		Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
		gameObject.transform.position = spawnPosition;
		Instantiate (enemy, transform.position, Quaternion.identity);
		if(faster>2){
			faster-=0.05f;
		}
	}

	/*void SpawnPowerUp(){
		Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
		gameObject.transform.position = spawnPosition;
		Instantiate (powerup, transform.position, Quaternion.identity);
		if(faster>2){
			faster-=0.05f;
		}
	}*/

	public void AddScore(){
		score+=100;
		StoreHighscore (score);
	}

	void OnGUI() {
		int w = 160;
		GUIStyle style = GUI.skin.GetStyle ("label");
		style.fontSize = 24;
		GUI.Label (new Rect (Screen.width / 2 - w / 2, 10, w, 30), "Score: " + score.ToString ());
		style.fontSize = 12;
		GUI.Label (new Rect (Screen.width - 100, 0, 100, 50), "Highscore: " + highscore.ToString ());
		GUI.Label (new Rect (10, 0, 100, 50), "Tolerance: " + pScript.health);

		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;

		style.fontSize = 60;
		if (pScript.isPaused || pScript.died) {
			int buttonW = 140;
			if(!pScript.died){
				GUI.Label (new Rect ((Screen.width)/2-120,140,240,100), "Paused", centeredStyle);
				if(GUI.Button (new Rect((Screen.width)/2-buttonW/2,240,buttonW,70), "Continue"))
				{
					Time.timeScale = 1.0f;
					pScript.isPaused = false;   
				}		
			}
			if(pScript.died){
				Time.timeScale = 0.0f;
				GUI.Label (new Rect ((Screen.width)/2-120,140,240,100), "Abused", centeredStyle);
				if(GUI.Button (new Rect((Screen.width)/2-buttonW/2,240,buttonW,70), "Restart"))
				{
					Application.LoadLevel ("Main");  
				}		
			}
			if (GUI.Button (new Rect ((Screen.width) / 2 - buttonW / 2, 340, buttonW, 70), "Menu")) {
				Application.LoadLevel ("Menu");
				Time.timeScale = 1.0f;
				pScript.isPaused = false;
			}

			if (GUI.Button (new Rect ((Screen.width)/2-buttonW/2, 440, buttonW, 70), "Quit")) {
				Application.Quit ();
			}	
		}
	}

	void StoreHighscore(int newHighscore)
	{
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);    
		if(newHighscore > oldHighscore){
			PlayerPrefs.SetInt("highscore", newHighscore);
			highscore=score;
		}
	}
}
