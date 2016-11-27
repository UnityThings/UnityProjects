using UnityEngine;
using System.Collections;

public class EnemyBubbles : MonoBehaviour {
	private float range = 2, speed = 3;
	Vector3 startPos;
	public GameObject player;
	public Sprite[] topics;
	SpriteRenderer mySpriteRenderer;
	private PlayerScript pScript;

	void Awake () {
		mySpriteRenderer = gameObject.renderer as SpriteRenderer;
		player = UnityEngine.GameObject.Find ("Player");
		pScript = player.GetComponent <PlayerScript>();
	}

	void Start () {
		int r = Random.Range (0, 4);
		range = Random.Range (2, 15);
		speed = Random.Range (8, 12);
		float lScale = Random.Range (0.5f, 1.0f);
		transform.localScale = new Vector2(lScale, lScale);		
		mySpriteRenderer.sprite = topics[r];
		startPos = transform.position;
		transform.rotation = Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position);
		gameObject.renderer.material.color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), 1.0f);
	}

	void FixedUpdate () {
		transform.localRotation = Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position);
		float dist = Vector3.Distance(startPos, transform.position);
		transform.Translate(Vector2.up * speed * Time.deltaTime);
		if (dist > range) 
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			pScript.TakeDamage();
			Destroy (gameObject);
		}
	}
}