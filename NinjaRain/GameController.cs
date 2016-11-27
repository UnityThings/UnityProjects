using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public Texture2D hp, hp_empty;
	public GameObject ninja_body, box, background, platform, restart, back;
	private int highScore, shield, shieldTimer = 100, health = 3, nrNinjas = 0;
	private static int score = 0, target;
	public static int mapNr = 1;
	public static bool finishedMap = false;
	private bool gamePaused = false, levelChanging = false;
	private float alpha = 0, timer;

	void Start () {
		setObjectives ();
		Time.timeScale = 1.0f;
		highScore = PlayerPrefs.GetInt("highscore", 0); 
		InvokeRepeating ("spawnNinja", 3, 3f);
		InvokeRepeating ("spawnCrate", 5, 3f);

		//background
		GameObject[] objects = GameObject.FindGameObjectsWithTag("background");
		int mapBg = mapNr % 4;
		GameObject bg = objects [mapBg];
		bg.GetComponent<Renderer>().enabled = true;
		bg.GetComponent<Renderer>().material.color = new Color (Random.Range (0.5f, 1f), Random.Range (0.5f, 1f), Random.Range (0.5f, 1f), 1.0f);
	}

	private static void setObjectives(){
		int difMult = (mapNr-1)/4;
		if (mapNr %4 == 1) {
			target = 1000+1000*difMult;
		} else if (mapNr %4 == 2) {
			target = 30+30*difMult;
		} else if (mapNr %4 == 3) {
			target = 5+5*difMult;
		} else if (mapNr %4 == 0) {
			target = 5+5*difMult;
		}
	}

	public static string MapObjectives(){
		string str = "";
		if (mapNr %4 == 1) {
			str = "Score " + target.ToString () +" points";
		} else if (mapNr %4 == 2) {
			str = "Survive for " + target.ToString () +" seconds";
		} else if (mapNr %4 == 3) {
			str = "Kill " + target.ToString () +" enemies";
		} else if (mapNr %4 == 0) {
			str = "Collect " + target.ToString () +" crates";
		}
		return str;
	}

	public static string MapInformation(){
		string str = "";
		if (mapNr %4 == 1) {
			str = "Score: " + score.ToString () + " / "+ target.ToString () +" points";
		} else if (mapNr %4 == 2) {
			str = "Survive: " + score.ToString () + " / "+ target.ToString () +" seconds";
		} else if (mapNr %4 == 3) {
			str = "Kill: " + score.ToString () + " / "+ target.ToString () +" enemies";
		} else if (mapNr %4 == 0) {
			str = "Collect: " + score.ToString () + " / "+ target.ToString () +" crates";
		}
		return str;
	}
	
	void Update () {
		timer += Time.deltaTime;
		shield++;
		if (score >= target && !levelChanging) {
			Invoke("changeLevel", 1);
			levelChanging = true;
		}
		if (mapNr % 4 == 2) {
			score = (int)timer;
		}
		/*if(Input.GetMouseButtonDown(0)){
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Instantiate (ninja_body, mousePos, transform.rotation);
		}
		if(Input.GetMouseButtonDown(1)){
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Instantiate (box, mousePos, transform.rotation);
		}*/
	}

	void changeLevel(){
		finishedMap = true;
		score = 0;
		mapNr++;
		Application.LoadLevel ("LevelTransition");  
	}

	public int getHealth(){
		return health;
	}

	public void addHealth(){
		if (health < 3) {
			health++;
		}
	}

	public void AddScore(){
		if (mapNr % 4 == 1) {
			score += getNrNinjas () * 100;
		} else if (mapNr % 4 == 0) {
			score += 1;
		}
		//StoreHighscore (score);
	}

	public static void NinjaKilled(){
		if (mapNr % 4 == 3) {
			score ++;
		}
	}

	public void TakeDamage(){
		if (shield > shieldTimer) {
			shield = 0;
			if (--health <= 0) {
				Invoke("pauseGame", 1);
			}
		}
	}

	void pauseGame(){
		gamePaused = true;
	}

	void spawnNinja(){
		nrNinjas++;
		Vector2 pos = new Vector2 (Random.Range (-3f, 3f), 4);
		Instantiate (ninja_body, pos, transform.rotation);
	}

	public void removeNinja(){
		nrNinjas--;
	}

	public int getNrNinjas(){
		return nrNinjas;
	}

	void spawnCrate(){
		Vector2 pos = new Vector2 (Random.Range (-3f, 3f), 4);
		Instantiate (box, pos, transform.rotation);
	}

	void OnGUI() {
		int w = 300;
		GUIStyle style = GUI.skin.GetStyle ("label");
		style.fontSize = 24;

		GUI.Label (new Rect (Screen.width / 2 - w / 2, 10, w, 30), MapInformation());

		if (health > 0) {
			GUI.DrawTexture (new Rect (10, 10, 50, 50), hp);
		} else {
			GUI.DrawTexture (new Rect (10, 10, 50, 50), hp_empty);
		}
		if (health > 1) {
			GUI.DrawTexture (new Rect (60, 10, 50, 50), hp);
		} else {
			GUI.DrawTexture (new Rect (60, 10, 50, 50), hp_empty);
		}
		if (health > 2) {
			GUI.DrawTexture (new Rect (110, 10, 50, 50), hp);
		} else {
			GUI.DrawTexture (new Rect (110, 10, 50, 50), hp_empty);
		}
		style.fontSize = 12;
		GUI.Label (new Rect (Screen.width - 100, 0, 100, 50), "Level " + mapNr);
		//GUI.Label (new Rect (Screen.width - 100, 0, 100, 50), "Highscore: " + highScore.ToString());

		if(gamePaused){
			Time.timeScale = 0.0f;
			restart.SetActive(true);
			back.SetActive(true);
			/*var centeredStyle = GUI.skin.GetStyle("Label");
			centeredStyle.alignment = TextAnchor.UpperCenter;
			int buttonW = 140;
			GUI.Label (new Rect ((Screen.width)/2-120,140,240,100), "You died", centeredStyle);
			if(GUI.Button (new Rect((Screen.width)/2-buttonW/2,240,buttonW,70), restart, GUIStyle.none))
			{
				Application.LoadLevel ("Main");  
			}		
			if (GUI.Button (new Rect ((Screen.width)/2-buttonW/2, 440, buttonW, 70), back, GUIStyle.none)) {
				Application.LoadLevel ("Menu");  
			}	*/
		}
		if (levelChanging) {
			alpha += Time.deltaTime;
			Texture2D blackTexture = new Texture2D(1,1);
			blackTexture.SetPixel(0,0,new Color(0,0,0,alpha));
			blackTexture.Apply();
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTexture);
		}
	}

	void StoreHighscore(int newHighscore)
	{
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);    
		if(newHighscore > oldHighscore){
			PlayerPrefs.SetInt("highscore", newHighscore);
			highScore=score;
		}
	}

}