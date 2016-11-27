using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {
	public Camera cam2;
	public GameObject roadsVer, roadsHor, house, car, grass, logo, plane, human, instr;
	List<GameObject> roads = new List<GameObject>();
	List<GameObject> houses = new List<GameObject>();
	//List<GameObject> cars = new List<GameObject>();
	//List<GameObject> carsRight = new List<GameObject>();
	float speed = 1f, length = 10;
	int nrHouses = 16;
	bool started = false;
	public static bool fps;
	public static int score = 0;
	int highscore;

	void Start () {
		highscore = PlayerPrefs.GetInt("highscore", 0); 
		score = 0;
		cam2.enabled = false;
		fps = false;
		for (int x =0; x<3; x++) {
			roads.Add(Instantiate(roadsVer, new Vector3(-length+x*length, 0, -2), Quaternion.identity) as GameObject);
			roads.Add(Instantiate(roadsHor, new Vector3(-length+x*length, 0, -1), Quaternion.identity) as GameObject);
		}
		for (int x =0; x<nrHouses; x++) {
			for (int y =0; y<5; y++) {
				if(Random.Range(0, 5)==0){
					houses.Add(Instantiate(grass, new Vector3(2*x-5*2-1, 0, 2*y-2*2-1), Quaternion.identity) as GameObject);
				}else{
					houses.Add(Instantiate(house, new Vector3(2*x-5*2-1, 0, 2*y-2*2-1), Quaternion.identity) as GameObject);
				}
			}
		}
		//InvokeRepeating ("SpawnCar", 1, 1);
		InvokeRepeating ("SpawnEnemies", 5, 5);
		InvokeRepeating ("SpawnHuman", 2, 2);
		InvokeRepeating ("CheckScores", 1, 1);
	}

	/*void SpawnCar(){
		cars.Add (Instantiate (car, new Vector3 (7, 0.01f, -6), Quaternion.identity) as GameObject);
		carsRight.Add (Instantiate (car, new Vector3 (-7, 0.01f, -6), Quaternion.identity) as GameObject);
	}*/

	void SpawnEnemies(){
		if (started) {
			for (int y = 0; y<4; y++) {
				float r = y / 4f;
				Invoke ("SpawnEnemy", r);
			}
		}
	}

	void SpawnEnemy(){
		Instantiate (plane, new Vector3 (15, 1f, -4), Quaternion.identity);
	}

	void SpawnHuman(){
		Instantiate (human, new Vector3 (15, 0.025f, Random.Range (-3f, -5f)), Quaternion.identity);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			cam2.enabled = !cam2.enabled;
			fps = !fps;
		}
		if (logo.gameObject.activeSelf) {
			if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
				started =true;
				logo.gameObject.SetActive(false);
				instr.gameObject.SetActive(false);
			}
		}
		foreach (GameObject go in roads) {
			Vector3 pos = go.transform.position;
			pos.x -= speed * Time.deltaTime;
			if (pos.x <= -length) {
				pos.x += length * 3;
			}
			go.transform.position = pos;
		}
		foreach (GameObject go in houses) {
			Vector3 pos = go.transform.position;
			pos.x -= speed * Time.deltaTime;
			if (pos.x <= -nrHouses) {
				pos.x += nrHouses * 2;
			}
			go.transform.position = pos;
		}

		/*foreach (GameObject go in cars) {
			Vector3 pos = go.transform.position;
			pos.x -= 0.06f-(speed*Time.deltaTime);
			go.transform.position = pos;
		}
		foreach (GameObject go in carsRight) {
			Vector3 pos = go.transform.position;
			pos.x += 0.06f-(speed*Time.deltaTime);
			go.transform.position = pos;
		}*/
	}

	void CheckScores(){
		StoreHighscore (score);
	}

	void StoreHighscore(int newHighscore){
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);    
		if(newHighscore > oldHighscore){
			PlayerPrefs.SetInt("highscore", newHighscore);
			highscore=score;
		}
	}

	void OnGUI() {
		GUIStyle style = GUI.skin.GetStyle ("label");
		style.fontSize = 24;
		GUI.Label (new Rect (10, 10, 200, 30), "Humans killed: " +score.ToString ());
		style.fontSize = 16;
		GUI.Label (new Rect (Screen.width - 140, 10, 140, 30), "Highscore: " + highscore.ToString ());
	}
}
