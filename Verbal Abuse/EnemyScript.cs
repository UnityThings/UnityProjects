using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	private float speed, health = 3, minDist = 5, hit, hitTimer = 30, shootSpeed, defaultShootSpeed = 30, shootVar = 150, lastShot;
	private GameObject player, gC;
	public GameObject bubble, playerBubble, head, dies;
	private bool altHand = true;
	public Animator animator;
	private GameController gameCon;

	void Awake () {
		gC = GameObject.FindWithTag ("GameController");
		gameCon = gC.GetComponent <GameController>();
		player = UnityEngine.GameObject.Find ("Player");
	}

	void Start () {
		speed = Random.Range (3f, 6f);
		lastShot = 0;
	}
	
	void FixedUpdate()
	{
		lastShot++;
		if (++hit > hitTimer) {
			animator.SetBool ("hiding", false);
			head.renderer.material.color = Color.white;
		}
		Shoot ();
		if (Vector3.Distance (transform.position, player.transform.position) >= minDist) {	
			animator.SetBool ("walking", true);
			var step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, step);
		} else {
			animator.SetBool("walking", false );
		}
		shootSpeed = Random.Range (defaultShootSpeed, defaultShootSpeed + shootVar);
	}

	void Shoot()
	{
		if (lastShot > shootSpeed) {
			lastShot = 0;
			altHand = !altHand;
			if (altHand){
				Instantiate (bubble, transform.position, transform.rotation);
			}
			else{
				Instantiate (bubble, transform.position, transform.rotation);
			}
		}
	}

	public void TakeDamage(){
		head.renderer.material.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);;
		hit = 0;
		animator.SetBool ("hiding", true);
		if (--health == 0){
			gameCon.AddScore();
			Instantiate (dies, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "playerBubble") {
			TakeDamage();
		}
	}
}
