using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour {
	private float range = 5, speed = 3, size = 0.5f;
	private Vector3 startPos;
	public Sprite[] topics;
	private SpriteRenderer mySpriteRenderer;
	
	void Awake () {
		mySpriteRenderer = gameObject.renderer as SpriteRenderer;
	}

	void Start () {
		range = Random.Range (range, range*1.5f);
		speed = Random.Range (speed, speed*1.5f);
		float lScale = Random.Range (size, size*1.5f);
		transform.localScale = new Vector2(lScale, lScale);		
		int r = Random.Range (0, 4);
		mySpriteRenderer.sprite = topics[r];
		startPos = transform.position;
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
		gameObject.renderer.material.color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), 1.0f);
	}

	void FixedUpdate () {
		float dist = Vector3.Distance(startPos, transform.position);
		transform.Translate(Vector2.up * speed * Time.deltaTime);
		if (dist > range) 
		{
			Destroy (gameObject);
		}
	}

	void Delete(){

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Enemy") {
			//other.animator.SetBool ("hiding", true);
			//EnemyScript eS = other.GetComponent<EnemyScript>();
			//eS.TakeDamage(gameObject);
			Destroy(gameObject);
			//Destroy (other.gameObject);
		}
	}
}
