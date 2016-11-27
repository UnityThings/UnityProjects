using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	public GameObject proj, death, dead;
	float speed =2f, shootTimer = 0.12f, fireRate;
	public int nrBullets = 20;
	List<GameObject> bullets;

	void Start(){
		bullets = new List<GameObject> ();
		for (int i = 0; i < nrBullets; i++) {
			GameObject go = Instantiate(proj) as GameObject;
			go.SetActive(false);
			bullets.Add (go);
		}
	}

	void Update () {
		Vector3 pos = transform.position;
		pos += new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0) * Time.deltaTime * speed;
		pos.x = Mathf.Clamp(pos.x,-3.5f,3.5f);
		pos.y = Mathf.Clamp(pos.y,0.15f,1.875f);
		transform.position = pos;
		fireRate += Time.deltaTime;

		if (Input.GetMouseButtonDown(0) && fireRate >= shootTimer && !GameLogic.fps) {
			fireRate = 0;
			pos.x += 0.2f;
			for(int i = 0; i<bullets.Count;i++){
				if(!bullets[i].activeInHierarchy){
					bullets[i].transform.position = pos;
					bullets[i].transform.rotation = transform.rotation;
					bullets[i].SetActive(true);
					break;
				}
			}
			//Instantiate(proj, transform.position, Quaternion.identity);
		}
		/*Vector3 mousePos = Input.mousePosition;
		mousePos.z = -4;
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
		mouseWorldPos.x *= -1;

		float AngleRad = Mathf.Atan2(transform.position.x - mouseWorldPos.x, transform.position.y - mouseWorldPos.y);
		float AngleDeg = (180 / Mathf.PI) * AngleRad;
		this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
		print (AngleDeg);*/
	}

	void OnCollisionEnter(Collision col) {
		Instantiate (dead, new Vector3(0, 2, 0), Quaternion.identity);
		Instantiate (death, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
