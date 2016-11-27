using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public Animator animator;
	private BubbleScript bubScr;
	public GameObject bubble, head, powerup;
	private float speed = 10, lastShot, shootSpeed = 8, rLimit =-81, lLimit = 40, tLimit = 42.5f, 
	bLimit = -38.5f, breather = 0, beenShot = 45, hit = 0, hitTimer = 30, storeSpeed = 0, storeShootSpeed = 0, 
	maxSpeed = 20, maxShootSpeed = 0.5f;
	public float health = 3;
	private bool hiding, imHiding;
	public bool isPaused, died;

	void Start(){
		InvokeRepeating("Evolve", 5, 20);
	}

	void Update(){
		if (Input.GetMouseButton (0)) {
			Shoot ();
		}
		if (Input.GetMouseButtonDown (1)) {
			animator.SetBool ("hiding", true);
			hiding = true;
			imHiding = true;
		}
		if (Input.GetMouseButtonUp (1)) {
			animator.SetBool ("hiding", false);
			hiding = false;
			imHiding = false;		
		}
		if(Input.GetKeyDown("escape")){
			if(!isPaused){
				Time.timeScale = 0.0f; 
				isPaused = true; 
			}else{
				Time.timeScale = 1.0f; 
				isPaused = false;
			}
		} 
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal") * speed;
		float v = Input.GetAxis("Vertical") * speed;
		Vector3 move = new Vector3 (h, v, 0.0f);
		transform.position += Vector3.ClampMagnitude(move, speed) * Time.deltaTime;  
		Vector3 newPos = transform.position;
		newPos.x = Mathf.Clamp(transform.position.x,rLimit,lLimit);
		newPos.y = Mathf.Clamp(transform.position.y,bLimit,tLimit);
		transform.position = newPos;
		if (v > 0 || h > 0 || v < 0 || h < 0) {
			animator.SetBool ("walking", true);
		} else {
			animator.SetBool("walking", false );
		}
		lastShot++;
		breather++;

		if (++hit > hitTimer) {
			hiding = false;
			if(!imHiding){
				animator.SetBool ("hiding", false);
			}
			head.renderer.material.color = Color.white;
		}
	}

	void Evolve(){
		if (speed < maxSpeed) {
			speed += 0.5f;
		}

		if (shootSpeed > maxShootSpeed) {
			speed -= 0.1f;
		}
	}

	void Shoot()
	{
		if (lastShot > shootSpeed) {
			lastShot = 0;
			GameObject bub = (GameObject)Instantiate (bubble, transform.position, transform.rotation);
			bubScr = bub.GetComponent<BubbleScript>();
		}
	}

	public void TakeDamage(){
		if (breather > beenShot) {
			head.renderer.material.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);;
			hit = 0;
			if (imHiding){
				health -=0.5f;
			}else{
				health--;
			}
			if(health <=0){
				died = true;
			}
			animator.SetBool ("hiding", true);
			hiding = true;
			breather = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other == powerup) {
			Destroy(other.gameObject);
			storeSpeed = speed;
			speed = 20;
			storeShootSpeed = shootSpeed;
			shootSpeed = 0.5f;
			//Invoke ("Restore", 5.0f);
		}
	}

	void Restore(){
		speed = storeSpeed;
		shootSpeed = storeShootSpeed;
	}
}