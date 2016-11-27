using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	private float v, speed = 4f, jumpSpeed = 250f, shield = 100;
	private bool isGrounded, slashing = false;
	public GameObject explode, blood, sword;
	private GameObject gameControl;
	private GameController gcScript;

	void Start(){
		sword.GetComponent<Renderer>().material.color = new Color (1.0f, 1.0f, 1.0f, 0.5f);
	}

	void Update(){
		if((Input.GetKeyDown ("space") || Input.GetKeyDown ("w")) && isGrounded){
			Jump();
		}

		/*Vector3 mouse_pos = Input.mousePosition;
		mouse_pos.z = 5.23f; //The distance between the camera and object
		Vector3 object_pos = Camera.main.WorldToScreenPoint(sword.transform.position);
		mouse_pos.x = mouse_pos.x - object_pos.x;
		mouse_pos.y = mouse_pos.y - object_pos.y;
		float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		sword.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));*/

		if (Input.GetMouseButtonDown (0) && !slashing) {
			sword.GetComponent<AudioSource>().Play();
			slashing = true;
			sword.SetActive (true);
			sword.transform.Rotate(Vector2.up, 0f);
			Invoke ("sheathSword", 0.1f);
			Invoke ("canSlashAgain", 0.3f);

			Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;  
			//difference.Normalize ();       //normalizing the vector. Meaning all the sum of the vector will be equal to 1.		
			float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;

			Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);  
			if (transform.position.x < mousePos.x) {
				sword.transform.rotation = Quaternion.Euler  (0f, 0f, -rotZ);
			}else{
				sword.transform.rotation = Quaternion.Euler  (0f, 0f, rotZ + 180);
			}
		}
	}

	void FixedUpdate()
	{
		shield++;

		Vector2 vel = GetComponent<Rigidbody2D>().velocity;
		vel.x = Input.GetAxis ("Horizontal") * speed; 
		float velXRaw = Input.GetAxisRaw ("Horizontal") * speed	; 
		vel.x += velXRaw / 2;

		GetComponent<Rigidbody2D>().velocity = vel;

		Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);  
		if (transform.position.x < mousePos.x && !slashing) {
			transform.localScale = new Vector3(-1, 1, 1);
		}
		else if (!slashing){
			transform.localScale = new Vector3(1, 1, 1);
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
		if (transform.position.y < -4) {
			gameControl = UnityEngine.GameObject.Find ("GameControl");
			gcScript = gameControl.GetComponent <GameController>();
			gcScript.TakeDamage();
			shield = 0;
			if(gcScript.getHealth() > 0){
				Vector2 pos = transform.position;
				pos.y = 4;
				transform.position = pos;
			}
		}
		if (shield < 100) {
			gameObject.GetComponent<Renderer>().material.color = new Color (1, 1, 1, 0.5f);
		} else {
			gameObject.GetComponent<Renderer>().material.color = new Color (1, 1, 1, 1);
		}
	}

	void Jump(){
		GetComponent<Rigidbody2D>().AddForce (Vector2.up * jumpSpeed);
	}
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "enemy") {
			GetComponent<AudioSource>().Play();
			gameControl = UnityEngine.GameObject.Find ("GameControl");
			gcScript = gameControl.GetComponent <GameController>();
			gcScript.TakeDamage();
			if(gcScript.getHealth() == 0){
				gameObject.GetComponent<Renderer>().enabled = false;
				Instantiate (explode, transform.position, transform.rotation);
			}else{
				Instantiate (blood, transform.position, transform.rotation);
			}
			shield = 0;
		}
	}
	void OnCollisionStay2D (Collision2D other)
	{
		isGrounded = true;
	}
	
	void OnCollisionExit2D (Collision2D other)
	{
		isGrounded = false;
	}
	
	void sheathSword(){
		sword.SetActive (false);
	}

	void canSlashAgain(){
		slashing = false;
	}
}
