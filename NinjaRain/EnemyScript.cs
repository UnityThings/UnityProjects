using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public GameObject explode;
	private float speed, jumpSpeed = 200f;
	private bool isGrounded, faceRight = true;
	private GameObject gameControl;
	private GameController gcScript;

	void Start () {
		gameControl = UnityEngine.GameObject.Find ("GameControl");
		gcScript = gameControl.GetComponent <GameController>();
		float scaleSize = Random.Range (0.8f, 1.5f);
		transform.localScale = new Vector2(scaleSize,scaleSize);
		if (Random.Range (0, 2) == 1) {
			faceRight = false;
		}
		if (!faceRight) {
			speed = Random.Range (5f, 10f);
			transform.localScale = new Vector3 (-1, 1, 1);
		} else {
			speed = Random.Range (-5f, -10f);
		}
		gameObject.GetComponent<Renderer>().material.color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), 1.0f);
		float nextJump = Random.Range (0f, 2f);
		InvokeRepeating ("Jump", 3, nextJump);
	}
	
	void Update () {
		if (isGrounded) {
			GetComponent<Rigidbody2D>().AddForce (Vector2.right * speed);
		}
		if (transform.position.y < -4) {
			/*if(Random.Range(0,3)==1){
				gcScript.removeNinja();
				Destroy(gameObject);
			}else{*/
				Vector2 pos = transform.position;
				pos.y = 4;
				transform.position = pos;
			//}
		}
		if (transform.position.x < -5) {
			Vector2 pos = transform.position;
			pos.x = 5;
			transform.position = pos;
		}
		if (transform.position.x > 5) {
			Vector2 pos = transform.position;
			pos.x = -5;
			transform.position = pos;
		}
	}

	void Jump(){
		if (isGrounded) {
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * jumpSpeed);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "slash") {
			GetComponent<AudioSource>().Play();
			gcScript.removeNinja();
			Instantiate (explode, transform.position, transform.rotation);
			Destroy(gameObject);
			GameController.NinjaKilled();
		}
	}

	void OnCollisionStay2D (Collision2D other)
	{
		isGrounded = true;
		//rotate ninjas to feet
		if((transform.rotation.eulerAngles - transform.rotation.eulerAngles).sqrMagnitude < 0.1) {
			transform.rotation = Quaternion.identity;
		}
	}
	
	void OnCollisionExit2D (Collision2D other)
	{
		isGrounded = false;
	}
}

