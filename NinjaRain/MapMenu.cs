using UnityEngine;
using System.Collections;

public class MapMenu : MonoBehaviour {
	public GameObject mapPoint, mapPointDone, mapPointGrey, mapBoss, hero;

	// Use this for initialization
	void Start () {
		int currentMap = GameController.mapNr;
		int mapCount = 0;
		for (int y = -2; y<=2; y++) {
			for (int x = -2; x<=2; x++) {
				mapCount++;
				Vector2 pos = new Vector2 (x, y);
				if(mapCount < currentMap){
					Instantiate (mapPointDone, pos, transform.rotation);
				}else if (mapCount == currentMap){
					Instantiate (mapPoint, pos, transform.rotation);
					Instantiate (hero, pos, transform.rotation);
				}else if (mapCount == 25){
					Instantiate (mapBoss, pos, transform.rotation);
				}else{
					Instantiate (mapPointGrey, pos, transform.rotation);
				}
			}
		}
		if (currentMap <= 5 || (currentMap >= 11 && currentMap <= 15) || currentMap >= 21) {
			hero.transform.localScale = new Vector2 (-2, 2);
		} else {
			hero.transform.localScale = new Vector2 (2, 2);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
