using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {
	public GameObject explode, boxPickup, dispPoints;
	private GameObject gameControl;
	private GameController gcScript;
	private bool lifeBox = false;

	//float radius = 5.0f, power = 10.0f;

	void Start () {
		Invoke ("Explode", 5);
		if (Random.Range (0, 5) == 1) {
			lifeBox = true;
			GetComponent<Renderer>().material.color = new Color (0.0f, 1.0f, 0.5f, 1.0f);
		} else {
			GetComponent<Renderer>().material.color = new Color (0.0f, 1.0f, 1.0f, 1.0f);
		}
	}

	void Explode(){
		Instantiate (explode, transform.position, transform.rotation);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "slash") {
			CratePickup();
		}
	}

	void OnCollisionStay2D (Collision2D other)
	{
		if (other.transform.name == "hero") {
			GetComponent<AudioSource>().Play();
			CratePickup();
		}
	}

	void CratePickup(){
		Instantiate (boxPickup, transform.position, transform.rotation);
		gameControl = UnityEngine.GameObject.Find ("GameControl");
		gcScript = gameControl.GetComponent <GameController>();
		if(lifeBox){
			gcScript.addHealth();
		}else{
			gcScript.AddScore();
			Instantiate (dispPoints, transform.position, transform.rotation);
		}
		Destroy(gameObject);
	}
}
