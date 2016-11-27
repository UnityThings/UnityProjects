using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	void Start () {
		Invoke ("Restart", 2);
	}

	void Restart () {
		Application.LoadLevel(0);
	}
}
