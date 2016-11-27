using UnityEngine;
using System.Collections;

public class deathAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("kill", 0.2f);
	}
	
	void kill(){
		Destroy (gameObject);
	}
}
