using UnityEngine;
using System.Collections;

public class HouseCluster : MonoBehaviour {

	void Start () {
		foreach (Transform child in transform) {
			if(Random.Range(0,3) == 0){
				child.gameObject.SetActive(false);
			}
		}
	}
}
